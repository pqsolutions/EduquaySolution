using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using SentinelAPI.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;



namespace SentinelAPI.Services.Mail
{
    public class MailService : IMailService
    {
        private readonly IConfiguration _config;
        public MailService(IOptions<ForgotPasswordMailTemplate> fpmt, IConfiguration config)
        {
            _config = config;
        }
        public bool ForgotPasswordOTPMail(string otp, string userFullName, string userEmailId)
        {
            try
            {
                var mailBody = _config.GetSection("ForgotPasswordSMTP").GetSection("body").Value.Replace("#OTP", otp).Replace("#RecipientName", userFullName);
                var recipients = userEmailId + _config.GetSection("ForgotPasswordSMTP").GetSection("recipients").Value;
                var from = _config.GetSection("ForgotPasswordSMTP").GetSection("from").Value;
                var subject = _config.GetSection("ForgotPasswordSMTP").GetSection("subject").Value;
                var host = _config.GetSection("ForgotPasswordSMTP").GetSection("host").Value; 
                var port = _config.GetSection("ForgotPasswordSMTP").GetSection("port").Value;
                var username = _config.GetSection("ForgotPasswordSMTP").GetSection("username").Value;
                var password = _config.GetSection("ForgotPasswordSMTP").GetSection("password").Value;
                var mailMessage = new MailMessage(from, recipients, subject, mailBody);
                mailMessage.IsBodyHtml = true;
                var client = new SmtpClient(host, int.Parse(port))
                {
                    Credentials = new NetworkCredential(username, password),
                    EnableSsl = true
                };
                client.Send(mailMessage);
                return true;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
