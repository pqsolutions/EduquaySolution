using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Pathologist
{
    public class AddHPLCDiagnosisResultRequest
    {
        public string uniqueSubjectId { get; set; }
        public string barcodeNo { get; set; }
        public int centralLabId { get; set; }
        public int hplcTestResultId { get; set; }
        public string clinicalDiagnosisId { get; set; }
        public string hplcResultMasterId { get; set; }
        public bool isNormal { get; set; }
        public string diagnosisSummary { get; set; }
        public bool isConsultSeniorPathologist { get; set; }
        public string seniorPathologistName { get; set; }
        public string seniorPathologistRemarks { get; set; }
        public int userId { get; set; }
        public bool isDiagnosisComplete { get; set; }
        public string othersResult { get; set; }
        public string othersDiagnosis { get; set; }

    }
}
