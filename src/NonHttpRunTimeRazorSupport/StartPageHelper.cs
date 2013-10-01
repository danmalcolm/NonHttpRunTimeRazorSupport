using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web;
using System.Web.WebPages;

namespace NonHttpRuntimeRazorSupport
{
    /// <summary>
    /// Alternative implementation of System.Web.WebPages.StartPage modified to support execution of _ViewStart
    /// templates outside of a web application
    /// </summary>
    internal class StartPageHelper
    {
        /// <summary>
        /// Returns either the root-most init page, or the provided page itself if no init page is found
        /// </summary>
        public static WebPageRenderingBase GetStartPage(WebPageRenderingBase page, string fileName, IEnumerable<string> supportedExtensions)
        {
            if (page == null)
            {
                throw new ArgumentNullException("page");
            }
            if (String.IsNullOrEmpty(fileName))
            {
                throw new ArgumentException(String.Format(CultureInfo.CurrentCulture, "Cannot be null or empty", "fileName"), "fileName");
            }
            if (supportedExtensions == null)
            {
                throw new ArgumentNullException("supportedExtensions");
            }

            // Use the page's VirtualPathFactory if available
            return GetStartPage(page, page.VirtualPathFactory, HttpRuntime.AppDomainAppVirtualPath, fileName, supportedExtensions);
        }

        internal static WebPageRenderingBase GetStartPage(WebPageRenderingBase page, IVirtualPathFactory virtualPathFactory, string appDomainAppVirtualPath,
                                                          string fileName, IEnumerable<string> supportedExtensions)
        {
            // Build up a list of pages to execute, such as one of the following:
            // ~/somepage.cshtml
            // ~/_pageStart.cshtml --> ~/somepage.cshtml
            // ~/_pageStart.cshtml --> ~/sub/_pageStart.cshtml --> ~/sub/somepage.cshtml
            WebPageRenderingBase currentPage = page;
            var pageDirectory = VirtualPathUtility.GetDirectory(page.VirtualPath);

            // Start with the requested page's directory, find the init page,
            // and then traverse up the hierarchy to find init pages all the
            // way up to the root of the app.
            while (!string.IsNullOrEmpty(pageDirectory))
            {
                // Go through the list of supported extensions
                foreach (var extension in supportedExtensions)
                {
                    var virtualPath = VirtualPathUtility.Combine(pageDirectory, fileName + "." + extension);

                    // Can we build a file from the current path?
                    if (virtualPathFactory.Exists(virtualPath))
                    {
                        var parentStartPage = virtualPathFactory.CreateInstance(virtualPath) as StartPage;
                        parentStartPage.VirtualPath = virtualPath;
                        parentStartPage.ChildPage = currentPage;
                        parentStartPage.VirtualPathFactory = virtualPathFactory;
                        currentPage = parentStartPage;
                        break;
                    }
                }
                
                pageDirectory = pageDirectory == "~/" 
                    ? null
                    : VirtualPathUtility.GetDirectory(pageDirectory);
            }

            // At this point 'currentPage' is the root-most StartPage (if there were
            // any StartPages at all) or it is the requested page itself.
            return currentPage;
        } 
    }
}