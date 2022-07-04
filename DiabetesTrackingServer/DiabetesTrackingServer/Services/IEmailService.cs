using DiabetesTrackingServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Services
{
    public interface IEmailService
    {
        //Task SendEmailAsync(MailRequest mailRequest);
        void SendEmail(MailRequest mailRequest);
        void SendEmailForReminders();
    }
}
