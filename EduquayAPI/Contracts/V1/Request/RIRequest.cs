using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class RIRequest
    {
        public int testingCHCId { get; set; }
        public int phcId { get; set; }
        public int scId { get; set; }
        public string riGovCode { get; set; }
        public string riSite { get; set; }
        public string pincode { get; set; }
        public int ilrId { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }

    }
}
