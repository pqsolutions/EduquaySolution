using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class CentralLabReportRequest
    {
        public int sampleStatus { get; set; }
        public int centralLabId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int anmId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
