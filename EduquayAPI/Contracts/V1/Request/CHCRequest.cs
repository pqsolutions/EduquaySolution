using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class CHCRequest
    {
        public int DistrictId { get; set; }
        public int BlockId { get; set; }
        public string HNIN_ID { get; set; }
        public string CHC_gov_code { get; set; }
        public string CHCname { get; set; }
        public string Istestingfacility { get; set; }
        public string Pincode { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
