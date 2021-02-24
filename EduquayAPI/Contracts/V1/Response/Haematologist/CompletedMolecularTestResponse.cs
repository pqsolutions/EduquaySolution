using EduquayAPI.Models.Haematologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Haematologist
{
    public class CompletedMolecularTestResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CompletedMolTestANWDetail> data { get; set; }
    }
    public class CompletedMolTestANWDetail
    {
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
        public string anwHPLCDiagnosis { get; set; }
        public string spouseCBCTestResult { get; set; }
        public string spouseSSTestResult { get; set; }
        public string spouseHPLCTestResult { get; set; }
        public string spouseHPLCDiagnosis { get; set; }
        public int prePNDTCounsellingId { get; set; }
        public int schedulingId { get; set; }
        public string counsellingDateTime { get; set; }
        public int counsellorId { get; set; }
        public string counsellorName { get; set; }
        public int obstetricianId { get; set; }
        public string obstetricianName { get; set; }
        public string schedulePNDTDate { get; set; }
        public string schedulePNDTTime { get; set; }
        public string counsellingRemarks { get; set; }
        public string counsellingStatus { get; set; }
        public int pndTestId { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public string procedureofTesting { get; set; }
        public string pndtComplecations { get; set; }
        public string motherVoided { get; set; }
        public string motherVitalStable { get; set; }
        public string foetalHeartRateDocumentScan { get; set; }
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
        public string anwPathoRemarks { get; set; }
        public string spousePathoRemarks { get; set; }
        public List<CompletedFoetusMolTestDetail> foetusDetail { get; set; }
    }
}
