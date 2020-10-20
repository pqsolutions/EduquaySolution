using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Master
{
    public class OTPRequest
    {
        public string userName { get; set; }
        public string otp { get; set; }
    }
}
