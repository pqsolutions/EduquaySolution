using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMNotifications
{
    public class NotificationUpdateStatusRequest
    {
        public int sampleCollectionId { get; set; }
        public int status { get; set; }
        public int anmId { get; set; }
    }
}
