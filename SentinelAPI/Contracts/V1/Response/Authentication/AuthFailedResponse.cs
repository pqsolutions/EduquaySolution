using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Authentication
{
    public class AuthFailedResponse
    {
        public bool status { get; set; }
        public IEnumerable<string> errors { get; set; }
    }
}
