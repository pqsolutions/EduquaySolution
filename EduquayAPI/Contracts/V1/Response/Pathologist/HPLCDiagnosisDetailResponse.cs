using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Pathologist
{
    public class HPLCDiagnosisDetailResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<HPLCDiagnosisDetail> SubjectDetails { get; set; }
    }
    public class HPLCDiagnosisDetail
    {
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string barcodeNo { get; set; }
        public string rchId { get; set; }
        public string ga { get; set; }
        public string dateOfTest { get; set; }
        public string district { get; set; }
        public string testingCHC { get; set; }
        public string riPoint { get; set; }
        public int age { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public string spouseName { get; set; }
        public string spouseContact { get; set; }
        public string lmpDate { get; set; }
        public string obstetricsScore { get; set; }
        public string sstResult { get; set; }
        public string cbcResult { get; set; }
        public string mcv { get; set; }
        public string rdw { get; set; }
        public string rbc { get; set; }
        public string hbF { get; set; }
        public string hbA0 { get; set; }
        public string hbA2 { get; set; }
        public string hbC { get; set; }
        public string hbD { get; set; }
        public string hbS { get; set; }
        public bool isNormal { get; set; }
        public int hplcTestResultId { get; set; }
        public string agingOfTest { get; set; }
        public string clinicalDiagnosisId { get; set; }
        public bool isConsultSeniorPathologist { get; set; }
        public string seniorPathologistName { get; set; }
        public string seniorPathologistRemarks { get; set; }
        public string hplcResultMasterId { get; set; }
        public string othersResult { get; set; }
        public string diagnosisSummary { get; set; }
        public string graphFileName { get; set; }
        public string othersDiagnosis { get; set; }

    }
}
