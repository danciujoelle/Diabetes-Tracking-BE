using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiabetesTrackingServer.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public MailRequest(string email, string v1, string v2)
        {
            this.ToEmail = email;
            this.Subject = v1;
            this.Body = v2;
        }


    }
}
