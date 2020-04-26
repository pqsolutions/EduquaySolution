using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.Contracts.V1.Response
{
    public class ClinicalDiagnosisResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ClinicalDiagnosis> Diagnosis { get; set; }

    }
}
