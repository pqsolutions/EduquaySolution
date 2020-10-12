using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class OTPRequest
    {
        public string userName { get; set; }
        public string otp { get; set; }
    }
}
