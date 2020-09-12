using EduquayAPI.Models.ANMNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMNotifications
{
    public class ANMPNDTResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMPNDTReferal> Samples { get; set; }
    }
}
