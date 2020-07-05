using SentinelAPI.Models.Infant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Infant
{
    public class InfantMotherResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<InfantMom> MotherDetail { get; set; }
    }

    public class InfantMom
    {
        public int motherId { get; set; }
        public string motherSubjectId { get; set; }
        public string rchId { get; set; }
        public string MothersName { get; set; }
        public int districtId { get; set; }
        public int hospitalId { get; set; }
        public List<MotherInfant> InfantDetail { get; set; }

    }
}
