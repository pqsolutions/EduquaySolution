using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class MobileLoginRequest
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string deviceId { get; set; }
    }
}
