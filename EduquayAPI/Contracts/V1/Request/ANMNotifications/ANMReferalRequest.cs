using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMNotifications
{
    public class ANMReferalRequest
    {
        public string referalId { get; set; }
        public int userId { get; set; }
    }
}
