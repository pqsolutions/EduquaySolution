using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Obstetrician
{
    public class AddPNDTRequest
    {
        public int prePNDTCounsellingId { get; set; }
        public string anwsubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public string pndtDateTime { get; set; }
        public int counsellorId { get; set; }
        public int obstetricianId { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public int procedureOfTestingId { get; set; }
        public string othersProcedureofTesting { get; set; }
        public string pndtComplecationsId { get; set; }
        public string othersComplecations { get; set; }
        public bool motherVoided { get; set; }
        public bool motherVitalStable { get; set; }
        public bool foetalHeartRateDocumentScan { get; set; }
        public int userId { get; set; }
        public int pregnancyType { get; set; }
        public string sampleRefId { get; set; }
        public string foetusName { get; set; }
        public string cvsSampleRefId { get; set; }
        public int pndtLocationId { get; set; }
        public string assistedBy { get; set; }
    }
}
