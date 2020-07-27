using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCNotifications
{
    public class CHCPositiveSamplesRequest
    {
        public int chcId { get; set; }
        public int registeredFrom { get; set; }
    }
}
