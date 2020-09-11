using EduquayAPI.Models.DiscrictCoordinator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.DistrictCoordinator
{
    public class DCNotificationSampleResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<NotificationSamples> Samples { get; set; }
    }
}
