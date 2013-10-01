using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using EmailDemo.Notifications;
using EmailDemoTemplates.Models;

namespace EmailDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"
This a very simple demo of how the NonHttpRunTimeRazorSupport library 
might be used to send emails outside of the context of a running
web application.

This app is configured to drop .eml files in the C:\temp folder (see 
app.config). These files can be viewed in an email client, or on a
web site like http://www.encryptomatic.com/viewer/Default.aspx");
            var settings = new NotificationSettings(new Uri("http://www.facepack.com/"));
            var service = new EmailNotificationService(settings);
            do
            {
                var from = new MailAddress("test@example.com");
                var to = new MailAddress("test@example.com");
                var model = new WelcomeModel
                {
                    Name = "Dave"
                };
                service.Send(from, to, model);
                Console.WriteLine("Message sent. Press a key to resend, or q to exit");
            } while (Console.ReadKey().KeyChar != 'q');
        }
    }
}
