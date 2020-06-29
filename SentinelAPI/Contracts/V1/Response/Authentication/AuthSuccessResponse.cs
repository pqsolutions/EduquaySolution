using SentinelAPI.Models.Masters;
using SentinelAPI.Models.Masters.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Authentication
{
    public class AuthSuccessResponse
    {
        public bool status { get; set; }
        public string username { get; set; }
        public string token { get; set; }
        public string created { get; set; }
        public string expiry { get; set; }
        public Users userDetail { get; set; }
    }
}
