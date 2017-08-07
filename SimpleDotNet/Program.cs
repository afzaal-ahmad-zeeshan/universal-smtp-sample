using Microsoft.Cognitive.LUIS;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDotNet
{
    class Program
    {
        static void Main(string[] args)
        {
            var credentials = new System.Net.NetworkCredential("<username>", "<password>");
            using (var client = SmtpClientFactory.GetClient(SmtpClientFactory.ClientType.SendGrid, credentials, true))
            {
                var message = new MailMessage("John Doe <john.doe@example.com>", "Johanna Doe <johanna.doe@example.com>", "Special Subject", "The body of email goes here.");

                client.Client.SendCompleted += Client_SendCompleted;
                client.Send(message);

                // Just to pause the application.
                Console.Read();
            }
        }

        private static void Client_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Email sent.");
        }
    }
}
