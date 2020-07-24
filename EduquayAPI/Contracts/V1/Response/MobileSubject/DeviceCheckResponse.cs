using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class DeviceCheckResponse
    {
        public bool valid { get; set; }
        public string msg { get; set; }
    }
}
