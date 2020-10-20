using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Mail
{
    public interface IMailService
    {
        bool ForgotPasswordOTPMail(string otp, string userFullName, string userEmailId);
    }
}
