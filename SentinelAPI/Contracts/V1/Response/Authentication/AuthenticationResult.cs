using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Authentication
{
    public class AuthenticationResult
    {
        public string token { get; set; }
        public bool success { get; set; }
        public IEnumerable<string> errors { get; set; }
        public string username { get; set; }
        public DateTime created { get; set; }
        public DateTime expiry { get; set; }
    }
}
