using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Caching;
using System.Web.Routing;

namespace NonHttpRuntimeRazorSupport
{
    /// <summary>
    /// Implementation of HttpResponseBase used to support execution of WebViewPages 
    /// outside of the context of an HTTP request
    /// </summary>
    internal class OfflineHttpResponse : HttpResponseBase
    {
        private readonly HttpCookieCollection cookies = new HttpCookieCollection();

        public override string ApplyAppPathModifier(string virtualPath)
        {
            return virtualPath;
        }

        public override HttpCookieCollection Cookies
        {
            get { return cookies; }
        }

        #region Not supported members

        private const string NotSupportedMessage =
            "This implementation of HttpResponseBase is used to execute precompiled MVC views outside of the context of an active HttpRuntime. All members that are known to be required while executing templates have been implemented. If the view being executed needs to access other members, consider adding implementation to BackgroundHttpResponse";

        public override void AddCacheItemDependency(string cacheKey)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddCacheItemDependencies(ArrayList cacheKeys)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddCacheItemDependencies(string[] cacheKeys)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddCacheDependency(params CacheDependency[] dependencies)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddFileDependency(string filename)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddFileDependencies(ArrayList filenames)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddFileDependencies(string[] filenames)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddHeader(string name, string value)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AppendCookie(HttpCookie cookie)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AppendHeader(string name, string value)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AppendToLog(string param)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override IAsyncResult BeginFlush(AsyncCallback callback, object state)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void BinaryWrite(byte[] buffer)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Clear()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void ClearContent()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void ClearHeaders()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Close()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void DisableKernelCache()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void DisableUserCache()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void End()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void EndFlush(IAsyncResult asyncResult)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Flush()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Pics(string value)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Redirect(string url)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Redirect(string url, bool endResponse)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoute(object routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoute(string routeName)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoute(RouteValueDictionary routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoute(string routeName, object routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoute(string routeName, RouteValueDictionary routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoutePermanent(object routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoutePermanent(string routeName)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoutePermanent(RouteValueDictionary routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectToRoutePermanent(string routeName, object routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage); ;
        }

        public override void RedirectToRoutePermanent(string routeName, RouteValueDictionary routeValues)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectPermanent(string url)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RedirectPermanent(string url, bool endResponse)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RemoveOutputCacheItem(string path)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RemoveOutputCacheItem(string path, string providerName)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void SetCookie(HttpCookie cookie)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void TransmitFile(string filename)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void TransmitFile(string filename, long offset, long length)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Write(char ch)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Write(char[] buffer, int index, int count)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Write(object obj)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void Write(string s)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void WriteFile(string filename)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void WriteFile(string filename, bool readIntoMemory)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void WriteFile(string filename, long offset, long size)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void WriteFile(IntPtr fileHandle, long offset, long size)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void WriteSubstitution(HttpResponseSubstitutionCallback callback)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override bool Buffer
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { base.Buffer = value; }
        }

        public override bool BufferOutput
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override HttpCachePolicyBase Cache
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string CacheControl
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string Charset
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override CancellationToken ClientDisconnectedToken
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Encoding ContentEncoding
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string ContentType
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override int Expires
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override DateTime ExpiresAbsolute
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Stream Filter
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override NameValueCollection Headers
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Encoding HeaderEncoding
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsClientConnected
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsRequestBeingRedirected
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override TextWriter Output
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); ; }
        }

        public override Stream OutputStream
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string RedirectLocation
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string Status
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override int StatusCode
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string StatusDescription
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override int SubStatusCode
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool SupportsAsyncFlush
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool SuppressContent
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool SuppressFormsAuthenticationRedirect
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool TrySkipIisCustomErrors
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        #endregion
    }
}