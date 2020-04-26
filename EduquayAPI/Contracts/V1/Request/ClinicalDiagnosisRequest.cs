using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class ClinicalDiagnosisRequest
    {
        public string DiagnosisName { get; set; }
        public int Createdby { get; set; }
        public int Updatedby { get; set; }
        public string Comments { get; set; }
        public string Isactive { get; set; }
    }
}
