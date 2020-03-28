using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SCRequest
    {

      
        public int CHCId { get; set; }      
        public int PHCId { get; set; }      
        public int HNIN_ID { get; set; }       
        public string SC_gov_code { get; set; }
        public string SCname { get; set; }
        public string Pincode { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
