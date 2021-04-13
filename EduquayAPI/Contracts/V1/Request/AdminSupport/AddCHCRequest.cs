using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.AdminSupport
{
    public class AddCHCRequest
    {
        public int districtId { get; set; }
        public int blockId { get; set; }
        public string hninId { get; set; }
        public string chcGovCode { get; set; }
        public string name { get; set; }
        public bool isTestingFacility { get; set; }
        public int testingCHCId { get; set; }
        public int centralLabId { get; set; }
        public string pincode { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int userId { get; set; }
    }
}
