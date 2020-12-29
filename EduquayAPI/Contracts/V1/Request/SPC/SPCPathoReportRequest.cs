using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.SPC
{
    public class SPCPathoReportRequest
    {
      
        public int districtId { get; set; }
        public int blockId { get; set; }
        public int chcId { get; set; }
        public int anmId { get; set; }
        public int sampleStatus { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }

    }
}
