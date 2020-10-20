using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Template
{
    public class ForgotPasswordMailTemplate
    {
        public string host { get; set; }
        public string port { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string from { get; set; }
        public string recipients { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
    }
}
