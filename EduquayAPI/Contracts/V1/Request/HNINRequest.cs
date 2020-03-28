using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class HNINRequest
    {
       
        public int Facilitytype_ID { get; set; }       
        public string Facility_name { get; set; }
        public string NIN2HFI { get; set; }
        public int StateId { get; set; }       
        public int DistrictId { get; set; }       
        public string Taluka { get; set; }
        public int BlockId { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Landline { get; set; }
        public string Incharge_name { get; set; }
        public string Incharge_contactno { get; set; }
        public string Incharge_EmailId { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

    }
}
