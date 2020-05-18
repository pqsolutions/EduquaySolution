using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMNotifications
{
    public class NotificationUpdateStatusRequest
    {
        public int ID { get; set; }
        public int Status { get; set; }
        public int ANMID { get; set; }
    }
}
