using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Configuration;
using System.Web.Instrumentation;
using System.Web.Profile;
using System.Web.SessionState;
using System.Web.WebSockets;

namespace NonHttpRuntimeRazorSupport
{
    /// <summary>
    /// Implementation of HttpContextBase used to support execution of WebViewPages 
    /// outside of the context of an HTTP request (when HttpContext.Current is null).
    /// </summary>
    internal class OfflineHttpContext : HttpContextBase
    {
        private readonly OfflineHttpRequest request;
        private readonly OfflineHttpResponse response;
        private readonly Hashtable items = new Hashtable();

        public OfflineHttpContext(Uri baseUri, string virtualPath)
        {
            var builder = new UriBuilder(baseUri);
            builder.Path = virtualPath;
            var uri = builder.Uri;
            request = new OfflineHttpRequest(uri);
            response = new OfflineHttpResponse();
        }

        public override HttpRequestBase Request
        {
            get { return request; }
        }

        public override HttpResponseBase Response
        {
            get { return response; }
        }

        public override IDictionary Items
        {
            get { return items; }
        }

        #region Not supported members

        private const string NotSupportedMessage =
            "This implementation of HttpContextBase is used to execute precompiled MVC views outside of the context of an active HttpRuntime. All members that are known to be required while executing templates have been implemented. If the current view needs to access other members, consider adding implementation to BackgroundHttpContext";

        public override ISubscriptionToken AddOnRequestCompleted(Action<HttpContextBase> callback)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override IList<string> WebSocketRequestedProtocols
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string WebSocketNegotiatedProtocol
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override IPrincipal User
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override TraceContext Trace
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool ThreadAbortOnTimeout
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override DateTime Timestamp
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool SkipAuthorization
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override HttpSessionStateBase Session
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override HttpServerUtilityBase Server
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override ProfileBase Profile
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override PageInstrumentationService PageInstrumentation
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override IHttpHandler PreviousHandler
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsWebSocketRequestUpgrading
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsWebSocketRequest
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsPostNotification
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsDebuggingEnabled
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsCustomErrorEnabled
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override IHttpHandler Handler
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Exception Error
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override RequestNotification CurrentNotification
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override IHttpHandler CurrentHandler
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Cache Cache
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override AsyncPreloadModeFlags AsyncPreloadMode
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override HttpApplication ApplicationInstance
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override HttpApplicationStateBase Application
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool AllowAsyncDuringSyncStages
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Exception[] AllErrors
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override object GetService(Type serviceType)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void SetSessionStateBehavior(SessionStateBehavior sessionStateBehavior)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RewritePath(string filePath, string pathInfo, string queryString, bool setClientFilePath)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RewritePath(string filePath, string pathInfo, string queryString)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RewritePath(string path, bool rebaseClientPath)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RewritePath(string path)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void RemapHandler(IHttpHandler handler)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override object GetSection(string sectionName)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override object GetLocalResourceObject(string virtualPath, string resourceKey, CultureInfo culture)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override object GetLocalResourceObject(string virtualPath, string resourceKey)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override object GetGlobalResourceObject(string classKey, string resourceKey, CultureInfo culture)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override object GetGlobalResourceObject(string classKey, string resourceKey)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override ISubscriptionToken DisposeOnPipelineCompleted(IDisposable target)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void ClearError()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AddError(Exception errorInfo)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AcceptWebSocketRequest(Func<AspNetWebSocketContext, Task> userFunc, AspNetWebSocketOptions options)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void AcceptWebSocketRequest(Func<AspNetWebSocketContext, Task> userFunc)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        #endregion
    }
}