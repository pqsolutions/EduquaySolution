using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Login
{
    public class LoginRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
    }
}
