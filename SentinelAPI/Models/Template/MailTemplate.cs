using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Template
{
    public class MailTemplate
    {
        private readonly IOptions<ForgotPasswordMailTemplate> _fpmt;

        public MailTemplate(IOptions<ForgotPasswordMailTemplate> fpmt)
        {
            _fpmt = fpmt;
        }

        public void ForgotPasswordOTPMail(string otp, string userFullName, string userEmailId)
        {
            try
            {
                string mailBody = _fpmt.Value.body.Replace("#OTP", otp).Replace("#RecipientName", userFullName);
                string recipients = userEmailId + _fpmt.Value.recipients;
                var mailMessage = new MailMessage(_fpmt.Value.from, recipients, _fpmt.Value.subject, mailBody);
                mailMessage.IsBodyHtml = true;
                var client = new SmtpClient(_fpmt.Value.host, int.Parse(_fpmt.Value.port))
                {
                    Credentials = new NetworkCredential(_fpmt.Value.username, _fpmt.Value.password),
                    EnableSsl = true
                };
                client.Send(mailMessage);
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
