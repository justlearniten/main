using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mainweb.Services
{
    // This class is used by the application to send Email and SMS
    // when you turn on two-factor authentication in ASP.NET Identity.
    // For more details see this link https://go.microsoft.com/fwlink/?LinkID=532713
    public class AuthMessageSender : IEmailSender, ISmsSender
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            String source = "no-reply@justlearnit.ru";// "justlearniten@gmail.com";   
            String recipient = email;
            var oDestination = new Destination
            {
                ToAddresses = new List<string>() { recipient }
            };

            var oSubject = new Content
            {
                Data = subject
            };

            var oTextBody = new Content
            {
                Data = message
            };
            var oBody = new Body
            {
                Html = oTextBody
            };

            var oMessage = new Message
            {
                Subject = oSubject,
                Body = oBody
            };

            var request = new SendEmailRequest
            {
                Source = source,
                Destination = oDestination,
                Message = oMessage
            };
            using (var client = new AmazonSimpleEmailServiceClient(RegionEndpoint.EUWest1))
            {
               return client.SendEmailAsync(request);
            }
            //return Task.FromResult(0);
        }

        public Task SendSmsAsync(string number, string message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }
}
