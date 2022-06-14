using DiabetesTrackingServer.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public class MailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public void SendEmail(MailRequest mailRequest)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");
            client.Port = _mailSettings.Port;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            NetworkCredential credential = new NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            client.EnableSsl = true;
            client.Credentials = credential;

            MailMessage message = new MailMessage(_mailSettings.Mail, mailRequest.ToEmail);
            message.Subject = mailRequest.Subject;
            message.Body = mailRequest.Body;
            client.Send(message);
        }

        public Task SendEmailAsync(MailRequest mailRequest)
        {
            throw new NotImplementedException();
        }
    }
}
