using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MailTemplate
{
    public class ForgetPassword
    {
        public string RecipientName { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
