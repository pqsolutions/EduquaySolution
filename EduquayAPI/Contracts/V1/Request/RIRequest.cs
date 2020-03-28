using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class RIRequest
    {
        public int PHCId { get; set; }
        public int SCId { get; set; }
        public string RI_gov_code { get; set; }
        public string RIsite { get; set; }
        public string Pincode { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
