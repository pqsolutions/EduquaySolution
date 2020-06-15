using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class HNINRequest
    {
       
        public int facilityTypeId { get; set; }       
        public string facilityName { get; set; }
        public string nin2hfi { get; set; }
        public int stateId { get; set; }       
        public int districtId { get; set; }       
        public string taluka { get; set; }
        public int blockId { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public string landline { get; set; }
        public string inchargeName { get; set; }
        public string inchargeContactNo { get; set; }
        public string inchargeEmailId { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

    }
}
