using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.PNDTC
{
    public class AddPrePNDTCounsellingRequest
    {
        public int prePNDTSchedulingId { get; set; }
        public string anwsubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public int counsellorId { get; set; }
        public string counsellingRemarks { get; set; }
        public int assignedObstetricianId { get; set; }
        public bool isPNDTAgreeYes { get; set; }
        public bool isPNDTAgreeNo { get; set; }
        public bool isPNDTAgreePending { get; set; }
        public string schedulePNDTDate { get; set; }
        public string schedulePNDTTime { get; set; }
        public int userId { get; set; }
        public string fileName { get; set; }
        public string fileLocation { get; set; }

    }
}
