using System;
using System.Web;
using System.Web.Mvc;

namespace TestRazorTemplates.Html
{
    public static class UrlHelperExtensions
    {
        public static MvcHtmlString ContentAbsolute(this UrlHelper urls, string path)
        {
            var request = urls.RequestContext.HttpContext.Request;
            var fullpath = VirtualPathUtility.ToAbsolute(path, request.ApplicationPath);

            var urlBuilder = new UriBuilder(request.Url);
            urlBuilder.Path = fullpath;
            string url = urlBuilder.Uri.ToString();
            return new MvcHtmlString(url);
        }


    }
}