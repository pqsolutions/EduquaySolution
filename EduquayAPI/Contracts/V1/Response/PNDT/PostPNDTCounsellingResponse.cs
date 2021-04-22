using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.PNDT
{
    public class PostPNDTCounsellingResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PostPNDTCounsellingANWDetail> data { get; set; }
    }

    public class PostPNDTCounsellingANWDetail
    {
        public int pndTestId { get; set; }
        public string anwSubjectId { get; set; }
        public string subjectName { get; set; }
        public string spouseSubjectId { get; set; }
        public string spouseName { get; set; }
        public string rchId { get; set; }
        public string contactNo { get; set; }
        public int age { get; set; }
        public int spouseAge { get; set; }
        public string ecNumber { get; set; }
        public decimal ga { get; set; }
        public string obstetricScore { get; set; }
        public string lmpDate { get; set; }
        public string anwCBCTestResult { get; set; }
        public string anwSSTestResult { get; set; }
        public string anwHPLCTestResult { get; set; }
        public string spouseCBCTestResult { get; set; }
        public string spouseSSTestResult { get; set; }
        public string spouseHPLCTestResult { get; set; }
        public string prePNDTCounsellingDateTime { get; set; }
        public string prePNDTCounsellorName { get; set; }
        public string prePNDTCounsellingRemarks { get; set; }
        public string prePNDTCounsellingStatus { get; set; }
        public string schedulePrePNDTDate { get; set; }
        public string schedulePrePNDTTime { get; set; }
        public string pndtDateTime { get; set; }
        public string pndtObstetrician { get; set; }
        public string pndtCounsellorName { get; set; }
        public int postPNDTCounsellorId { get; set; }
        public string postPNDTCounsellorName { get; set; }
        public int postPNDTSchedulingId { get; set; }
        public string postPNDTCounsellingDateTime { get; set; }
        public string anwMCV { get; set; }
        public string anwRDW { get; set; }
        public string anwRBC { get; set; }
        public string anwHbA0 { get; set; }
        public string anwHbA2 { get; set; }
        public string anwHbF { get; set; }
        public string anwHbS { get; set; }
        public string anwHbD { get; set; }
        public string spouseMCV { get; set; }
        public string spouseRDW { get; set; }
        public string spouseRBC { get; set; }
        public string spouseHbA0 { get; set; }
        public string spouseHbA2 { get; set; }
        public string spouseHbF { get; set; }
        public string spouseHbS { get; set; }
        public string spouseHbD { get; set; }
        public List<PNDTFoetusDetail> foetusDetail { get; set; }
    }

}
