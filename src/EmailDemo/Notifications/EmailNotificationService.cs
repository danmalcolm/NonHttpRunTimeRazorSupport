using System;
using System.Net.Mail;
using System.Net.Mime;
using EmailDemoTemplates.Models;
using NonHttpRuntimeRazorSupport;

namespace EmailDemo.Notifications
{
    public class EmailNotificationService
    {
        private readonly ViewRenderer viewRenderer = ViewRenderer.ForAssemblyOf<INotificationModel>();
        private static readonly ContentType PlainTextContentType = new ContentType(MediaTypeNames.Text.Plain);
        private static readonly ContentType HtmlTextContentType = new ContentType(MediaTypeNames.Text.Html);
        private readonly NotificationSettings settings;
        
        public EmailNotificationService(NotificationSettings settings)
        {
            this.settings = settings;
        }

        public void Send<T>(MailAddress @from, MailAddress to, T model)
            where T: INotificationModel
        {
            // Razor templates generate all email content, including the subject (nice 
            // if you want to use dynamic content, e.g. "Hey Mr Jones, Your order ABC123 is ready")
            string subject = RenderSubject(model);
            string plain = RenderContent(model, EmailContentPart.PlainTextBody);
            string html = RenderContent(model, EmailContentPart.HtmlBody);

            var message = new MailMessage(@from, to) { Subject = subject };
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(plain, PlainTextContentType));
            message.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, HtmlTextContentType));
            using(var client = new SmtpClient())
            {
                client.Send(message);
            }
        }

        private string RenderSubject(object model)
        {
            string content = RenderContent(model, EmailContentPart.Subject);
            content = content.Replace(Environment.NewLine, "");
            return content;
        }

        private string RenderContent(object model, EmailContentPart contentPart)
        {
            string templatePath = GetTemplatePath(model, contentPart);
            string content = viewRenderer.RenderView(templatePath, model, settings.BaseUri);
            return content;
        }

        private string GetTemplatePath(object model, EmailContentPart contentPart)
        {
            // By convention, the template for each content element is located in a folder
            // based on the name of the model
            const string modelSuffix = "Model";
            string folder = model.GetType().Name;
            if (folder.EndsWith(modelSuffix))
                folder = folder.Substring(0, folder.Length - modelSuffix.Length);
            return string.Format("~/Views/{0}/{1}.cshtml", folder, contentPart);
        }
    }
}