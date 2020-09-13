using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Obstetrician
{
    public class AddMTPTestRequest
    {
        public int postPNDTCounsellingId { get; set; }
        public string anwsubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public string mtpDateTime { get; set; }
        public int counsellorId { get; set; }
        public int obstetricianId { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public string procedureOfTesting { get; set; }
        public string mtpComplecationsId { get; set; }
        public int dischargeConditionId { get; set; }
        public int userId { get; set; }
    }
}
