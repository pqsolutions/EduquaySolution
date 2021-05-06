using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.PNDTC
{
    public class AddPostPNDTCounsellingRequest
    {
        public int postPNDTSchedulingId { get; set; }
        public string anwsubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public int counsellorId { get; set; }
        public string counsellingRemarks { get; set; }
        public int assignedObstetricianId { get; set; }
        public bool isMTPAgreeYes { get; set; }
        public bool isMTPAgreeNo { get; set; }
        public bool isMTPAgreePending { get; set; }
        public string scheduleMTPDate { get; set; }
        public string scheduleMTPTime { get; set; }
        public int userId { get; set; }
        public string fileName { get; set; }
        public string fileLocation { get; set; }
    }
}
