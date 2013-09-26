using System;
using System.Collections.Concurrent;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using NonHttpRunTimeRazorSupport;

namespace NonHttpRuntimeRazorSupport
{
    /// <summary>
    /// Manages execution of MvcViewPages (created from RazorGenerator precompiled templates)
    /// outside of the context of a web application, allowing templates to be used within a Windows 
    /// service, console app or any other "offline" application.
    /// 
    /// Creating more than one instance of MvcViewPageExecutor to executed precompiled views from 
    /// different assemblies hasn't been fully tested. It is likely to result in views from 
    /// different assemblies being used when rendering partials and layouts. If you really need to
    /// do this, each assembly's views should be nested within a uniquely named folder so that view
    /// paths do not overlap, e.g. ~/Views/Something/MyView1.cshtml (Assembly1), 
    /// ~/Views/SomethingElse/MyView1.cshtml (Assembly2) etc.
    /// </summary>
    public class MvcViewPageExecutor
    {
        private static readonly ConcurrentDictionary<Assembly, MvcViewPageExecutor> Cache
            = new ConcurrentDictionary<Assembly, MvcViewPageExecutor>();

        /// <summary>
        /// Gets instance of MvcViewPageExecutor for executing views in the specified Assembly 
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        public static MvcViewPageExecutor ForAssembly(Assembly assembly)
        {
            return Cache.GetOrAdd(assembly, a =>
            {
                var viewEngine = new PrecompiledViewEngine(a);
                ViewEngines.Engines.Insert(0, viewEngine);
                return new MvcViewPageExecutor(viewEngine);
            });
        }

        private readonly PrecompiledViewEngine viewEngine;
        
        public MvcViewPageExecutor(PrecompiledViewEngine viewEngine)
        {
            this.viewEngine = viewEngine;
        }

        public string Execute<T>(object model, Uri baseUri)
            where T : WebViewPage
        {
            var attribute = typeof(T).GetCustomAttribute<PageVirtualPathAttribute>();
            if (attribute == null)
            {
                throw new ArgumentException(string.Format("{0} does not appear to be a pre-compiled view. The PageVirtualPathAttribute could not be found", typeof(T)));
            }
            string virtualPath = attribute.VirtualPath;
            return Execute(virtualPath, model, baseUri);
        }

        public string Execute(string virtualPath, object model, Uri baseUri)
        {
            var view = viewEngine.CreateViewInstance(virtualPath);
            if (view == null)
                throw new ArgumentException("Unable to find view with virtual path " + virtualPath, "virtualPath");

            var writer = new StringWriter();
            var viewContext = CreateViewContext(view, baseUri, virtualPath, model, writer);
            view.Render(viewContext, writer);
            return writer.ToString();
        }

        private static ViewContext CreateViewContext(IView view, Uri baseUri, string virtualPath, object model, StringWriter writer)
        {
            var httpContext = new OfflineHttpContext(baseUri, virtualPath);

            var routeData = new RouteData();
            routeData.Values["controller"] = "Placeholder";
            routeData.Values["action"] = "Execute";
            var controller = new PlaceholderController();
            var controllerContext = new ControllerContext(httpContext, routeData, controller);

            var viewData = new ViewDataDictionary(model);
            return new ViewContext(controllerContext, view, viewData, new TempDataDictionary(), writer);
        }
    }
}