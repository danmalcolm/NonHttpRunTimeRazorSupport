using System.Web;

namespace NonHttpRuntimeRazorSupport
{
    internal class OfflineBrowserCapabilities : HttpBrowserCapabilitiesBase
    {
        public override bool IsMobileDevice
        {
            get
            {
                return false;
            }
        }   

        // TODO - overrides with useful exception message
    }
}