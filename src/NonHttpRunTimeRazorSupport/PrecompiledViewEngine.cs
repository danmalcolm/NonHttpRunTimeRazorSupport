using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;

namespace NonHttpRunTimeRazorSupport
{
    // This is based on the PrecompiledMvcEngine class from the RazorGenerator.Mvc project:
    // http://razorgenerator.codeplex.com/SourceControl/latest#RazorGenerator.Mvc/PrecompiledMvcEngine.cs
    // Support for non-compiled views has been removed - only precompiled templates are supported

    public class PrecompiledViewEngine : VirtualPathProviderViewEngine, IVirtualPathFactory
    {
        private readonly IDictionary<string, Type> mappings;
        private readonly string baseVirtualPath;
        private readonly IViewPageActivator viewPageActivator = new ViewPageActivator();

        public PrecompiledViewEngine(Assembly assembly)
            : this(assembly, null)
        {
        }
        
        public PrecompiledViewEngine(Assembly assembly, string baseVirtualPath)
        {
            this.baseVirtualPath = NormalizeBaseVirtualPath(baseVirtualPath);

            base.AreaViewLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml", 
            };

            base.AreaMasterLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml", 
            };

            base.AreaPartialViewLocationFormats = new[] {
                "~/Areas/{2}/Views/{1}/{0}.cshtml", 
                "~/Areas/{2}/Views/Shared/{0}.cshtml", 
            };
            base.ViewLocationFormats = new[] {
                "~/Views/{1}/{0}.cshtml", 
                "~/Views/Shared/{0}.cshtml", 
            };
            base.MasterLocationFormats = new[] {
                "~/Views/{1}/{0}.cshtml", 
                "~/Views/Shared/{0}.cshtml", 
            };
            base.PartialViewLocationFormats = new[] {
                "~/Views/{1}/{0}.cshtml", 
                "~/Views/Shared/{0}.cshtml", 
            };
            base.FileExtensions = new[] {
                "cshtml", 
            };

            mappings = (from type in assembly.GetTypes()
                         where typeof(WebPageRenderingBase).IsAssignableFrom(type)
                         let pageVirtualPath = type.GetCustomAttributes(inherit: false).OfType<PageVirtualPathAttribute>().FirstOrDefault()
                         where pageVirtualPath != null
                         select new KeyValuePair<string, Type>(CombineVirtualPaths(this.baseVirtualPath, pageVirtualPath.VirtualPath), type)
                         ).ToDictionary(t => t.Key, t => t.Value, StringComparer.OrdinalIgnoreCase);
            this.viewPageActivator = new ViewPageActivator();
        }

        protected override bool FileExists(ControllerContext controllerContext, string virtualPath)
        {
            return Exists(virtualPath);
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath)
        {
            return CreateViewInternal(partialPath, masterPath: null, runViewStartPages: false);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath)
        {
            if(masterPath != null)
                throw new ArgumentException("Using a custom master template path is not supported - see http://razorgenerator.codeplex.com/SourceControl/latest#RazorGenerator.Mvc/PrecompiledMvcView.cs for possible implementation if you need it");
            return CreateViewInternal(viewPath, masterPath, runViewStartPages: true);
        }

        private IView CreateViewInternal(string viewPath, string masterPath, bool runViewStartPages)
        {
            Type type;
            if (mappings.TryGetValue(viewPath, out type))
            {
                return new PrecompiledView(viewPath, type, runViewStartPages, FileExtensions,  this, viewPageActivator);
            }
            return null;
        }

        public object CreateInstance(string virtualPath)
        {
            Type type;
            if (mappings.TryGetValue(virtualPath, out type))
            {
                return viewPageActivator.Create((ControllerContext)null, type);
            }
            return null;
        }

        public IView CreateViewInstance(string virtualPath)
        {
            Type type;
            if (mappings.TryGetValue(virtualPath, out type))
            {
                return new PrecompiledView(virtualPath, type, true, FileExtensions, this, viewPageActivator);
            }
            return null;
        }

        public bool Exists(string virtualPath)
        {
            return mappings.ContainsKey(virtualPath);
        }
        
        private static string NormalizeBaseVirtualPath(string virtualPath)
        {
            if (!String.IsNullOrEmpty(virtualPath))
            {
                // For a virtual path to combine properly, it needs to start with a ~/ and end with a /.
                if (!virtualPath.StartsWith("~/", StringComparison.Ordinal))
                {
                    virtualPath = "~/" + virtualPath;
                }
                if (!virtualPath.EndsWith("/", StringComparison.Ordinal))
                {
                    virtualPath += "/";
                }
            }
            return virtualPath;
        }

        private static string CombineVirtualPaths(string baseVirtualPath, string virtualPath)
        {
            if (!String.IsNullOrEmpty(baseVirtualPath))
            {
                return VirtualPathUtility.Combine(baseVirtualPath, virtualPath.Substring(2));
            }
            return virtualPath;
        }
    }
}
