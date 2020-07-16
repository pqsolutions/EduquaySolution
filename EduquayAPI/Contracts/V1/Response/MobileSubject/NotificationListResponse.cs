using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class NotificationListResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MobileNotificationSamples> DamagedSamples { get; set; }
        public List<MobileNotificationSamples> TimeoutExpirySamples { get; set; }

    }
}
