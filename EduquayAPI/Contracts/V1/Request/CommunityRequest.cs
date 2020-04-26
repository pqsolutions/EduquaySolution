using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class CommunityRequest
    {
        public int CasteID { get; set; }
        public string Communityname { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
