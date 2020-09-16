using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class AddUpdateFollowupStatusRequest
    {
        public string uniqueSubjectId { get; set; }
        public int followUpNo { get; set; }
        public int followUpStatusId { get; set; }
        public string followUpStatusDetail { get; set; }
        public int userId { get; set; }
    }
}
