using System;
using System.Collections.Specialized;
using System.IO;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Routing;

namespace NonHttpRuntimeRazorSupport
{
    /// <summary>
    /// Implementation of HttpRequestBase used to support execution of WebViewPages 
    /// outside of the context of an HTTP request.
    /// </summary>
    internal class OfflineHttpRequest : HttpRequestBase
    {
        private readonly Uri uri;

        private readonly HttpCookieCollection cookies = new HttpCookieCollection();

        private readonly NameValueCollection serverVariables = new NameValueCollection();

        private readonly HttpBrowserCapabilitiesBase browserCapabilities = new OfflineBrowserCapabilities(); 

        public OfflineHttpRequest(Uri uri)
        {
            this.uri = uri;
        }

        public override bool IsLocal
        {
            get { return false; }
        }

        public override string ApplicationPath
        {
            get { return "/"; }
        }

        public override NameValueCollection ServerVariables
        {
            get
            {
                return serverVariables;
            }
        }

        public override string RawUrl
        {
            get { return Url.ToString(); }
        }

        public override Uri Url
        {
            get { return uri; }
        }

        public override HttpCookieCollection Cookies
        {
            get { return cookies; }
        }

        public override HttpBrowserCapabilitiesBase Browser
        {
            get { return browserCapabilities; }
        }

        public override string UserAgent
        {
            get
            {
                return "background";
            }
        }

        #region Not supported members

        private const string NotSupportedMessage =
            "This implementation of HttpRequestBase is used to execute precompiled MVC views outside of the context of an active HttpRuntime. All members that are known to be required while executing templates have been implemented. If the view being executed needs to access other members, consider adding implementation to BackgroundHttpRequest";

        public override string this[string key]
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override NameValueCollection QueryString
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override NameValueCollection Headers
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string UserHostName
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string UserHostAddress
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string[] UserLanguages
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Uri UrlReferrer
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override UnvalidatedRequestValuesBase Unvalidated
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override void Abort()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override byte[] BinaryRead(int count)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override Stream GetBufferedInputStream()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override Stream GetBufferlessInputStream()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override Stream GetBufferlessInputStream(bool disableMaxRequestLength)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void InsertEntityBody()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void InsertEntityBody(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override int[] MapImageCoordinates(string imageFieldName)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override double[] MapRawImageCoordinates(string imageFieldName)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override string MapPath(string virtualPath)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override string MapPath(string virtualPath, string baseVirtualDir, bool allowCrossAppMapping)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void ValidateInput()
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override void SaveAs(string filename, bool includeHeaders)
        {
            throw new NotSupportedException(NotSupportedMessage);
        }

        public override string[] AcceptTypes
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string AnonymousID
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string AppRelativeCurrentExecutionFilePath
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override ChannelBinding HttpChannelBinding
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override HttpClientCertificate ClientCertificate
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

        public override int ContentLength
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string CurrentExecutionFilePath
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string CurrentExecutionFilePathExtension
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string FilePath
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override HttpFileCollectionBase Files
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override Stream Filter
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override NameValueCollection Form
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string HttpMethod
        {
            get { return "GET"; }
        }

        public override Stream InputStream
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsAuthenticated
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override WindowsIdentity LogonUserIdentity
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override bool IsSecureConnection
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override NameValueCollection Params
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string Path
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string PathInfo
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string PhysicalApplicationPath
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string PhysicalPath
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override ReadEntityBodyMode ReadEntityBodyMode
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override string RequestType
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override RequestContext RequestContext
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
            set { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override CancellationToken TimedOutToken
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        public override int TotalBytes
        {
            get { throw new NotSupportedException(NotSupportedMessage); }
        }

        #endregion
    }
}