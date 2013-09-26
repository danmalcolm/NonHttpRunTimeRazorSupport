using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using System.Web.WebPages;
using NonHttpRuntimeRazorSupport;

namespace NonHttpRunTimeRazorSupport
{
    public class PrecompiledView : IView
    {
        private readonly string virtualPath;
        private readonly Type type;
        private readonly IVirtualPathFactory virtualPathFactory;
        private readonly IViewPageActivator viewPageActivator;
        
        public PrecompiledView(
            string virtualPath,
            Type type,
            bool runViewStartPages,
            IEnumerable<string> fileExtensions,
            IVirtualPathFactory virtualPathFactory,
            IViewPageActivator viewPageActivator)
        {
            this.type = type;
            this.virtualPathFactory = virtualPathFactory;
            this.virtualPath = virtualPath;
            RunViewStartPages = runViewStartPages;
            ViewStartFileExtensions = fileExtensions;
            this.viewPageActivator = viewPageActivator;
        }

        public bool RunViewStartPages
        {
            get;
            private set;
        }

        public IEnumerable<string> ViewStartFileExtensions
        {
            get;
            private set;
        }

        public string VirtualPath
        {
            get { return virtualPath; }
        }

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            var webViewPage = viewPageActivator.Create(viewContext.Controller.ControllerContext, type) as WebViewPage;

            if (webViewPage == null)
            {
                throw new InvalidOperationException("Invalid view type");
            }

            webViewPage.VirtualPath = virtualPath;
            webViewPage.ViewContext = viewContext;
            webViewPage.ViewData = viewContext.ViewData;
            webViewPage.InitHelpers();
            webViewPage.VirtualPathFactory = virtualPathFactory;

            WebPageRenderingBase startPage = null;
            if (this.RunViewStartPages)
            {
                startPage = StartPageHelper.GetStartPage(webViewPage, "_ViewStart", ViewStartFileExtensions);
            }

            var pageContext = new WebPageContext(viewContext.HttpContext, webViewPage, startPage);
            webViewPage.ExecutePageHierarchy(pageContext, writer, startPage);
        }
    }
}
