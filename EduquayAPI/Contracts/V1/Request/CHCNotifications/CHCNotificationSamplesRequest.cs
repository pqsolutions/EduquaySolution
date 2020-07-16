using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCNotifications
{
    public class CHCNotificationSamplesRequest
    {
        public int userId { get; set; }
        public int collectionFrom { get; set; }
        public int notification { get; set; }
    }
}
