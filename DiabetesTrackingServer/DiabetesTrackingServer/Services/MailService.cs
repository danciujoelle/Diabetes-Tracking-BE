using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Repositories;
using DiabetesTrackingServer.ViewModels;
using Microsoft.Extensions.Options;
using System;
using System.Net.Mail;
namespace DiabetesTrackingServer.Services
{
    public class MailService : IEmailService
    {
        private readonly MailSettings _mailSettings;
        private IUserRepository _userRepository;
        public MailService(IOptions<MailSettings> mailSettings, IUserRepository userRepository)
        {
            _mailSettings = mailSettings.Value;
            _userRepository = userRepository;
        }
        public async void SendEmail(MailRequest mailRequest)
        {
            SmtpClient client = new SmtpClient("smtp-mail.outlook.com");

            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            System.Net.NetworkCredential credentials =
                new System.Net.NetworkCredential(_mailSettings.Mail, _mailSettings.Password);
            client.EnableSsl = true;
            client.Credentials = credentials;

            try
            {
                var mail = new MailMessage(new MailAddress(_mailSettings.Mail), new MailAddress(mailRequest.ToEmail));
                mail.Subject = mailRequest.Subject;
                mail.Body = mailRequest.Body;
                client.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw ex;
            }
        }

        public async void SendEmailForReminders()
        {
            var allUsers = await _userRepository.GetAllUsers();
            foreach (User user in allUsers)
            {
                var emailRequest = new MailRequest(user.Email, "Diabetes Tracking App", "Please log in your glucose levels!");
                SendEmail(emailRequest);
            }
        }
    }

}
