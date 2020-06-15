using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class DistrictRequest
    {
       
        public int stateId { get; set; }      
        public string districtGovCode { get; set; }
        public string districtName { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
    }
}
