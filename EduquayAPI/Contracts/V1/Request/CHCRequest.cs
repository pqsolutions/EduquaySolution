using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class CHCRequest
    {
        public int districtId { get; set; }
        public int blockId { get; set; }
        public string hninId { get; set; }
        public string chcGovCode { get; set; }
        public string chcName { get; set; }
        public string isTestingFacility { get; set; }
        public int testingCHCId { get; set; }
        public int centralLabId { get; set; }
        public string pincode { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

    }
}
