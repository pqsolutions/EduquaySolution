using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMNotifications
{
    public class AddFollowUpStatus
    {
        public int mtpId { get; set; }
        public int followUpNo { get; set; }
        public int followUpStatusId { get; set; }
        public int userId { get; set; }
    }
}
