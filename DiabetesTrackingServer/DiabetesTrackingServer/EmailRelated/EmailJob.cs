using DiabetesTrackingServer.Models;
using DiabetesTrackingServer.Services;
using DiabetesTrackingServer.ViewModels;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.EmailRelated
{
    public class EmailJob : IJob
    {
        private readonly IUserService userService;
        private readonly IEmailService emailService;

        public EmailJob(IUserService _userService, IEmailService _emailService)
        {
            userService = _userService;
            emailService = _emailService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            var allUsers = await userService.GetUsersForGlucoseRemider();
            foreach(User user in allUsers)
            {
                var emailRequest = new MailRequest(user.Email, "Diabetes Tracking App", "Please log in your glucose levels!");
                emailService.SendEmail(emailRequest);
            }
        }
    }
}
