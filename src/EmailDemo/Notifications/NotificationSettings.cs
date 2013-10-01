using System;

namespace EmailDemo.Notifications
{
    public class NotificationSettings
    {
        public NotificationSettings(Uri baseUri)
        {
            BaseUri = baseUri;
        }

        public Uri BaseUri { get; private set; }
    }
}