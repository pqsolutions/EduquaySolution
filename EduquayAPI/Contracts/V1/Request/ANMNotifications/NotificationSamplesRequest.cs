using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMNotifications
{
    public class NotificationSamplesRequest
    {
        public int anmId { get; set; }
        public int notification { get; set; }
    }
}
