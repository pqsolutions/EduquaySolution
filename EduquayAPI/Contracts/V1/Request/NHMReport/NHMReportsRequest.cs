using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.NHMReport
{
    public class NHMReportsRequest
    {
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int districtId { get; set; }
        public int blockId { get; set; }
        public int chcId { get; set; }
        public int anmId { get; set; }
        public int searchSection { get; set; }
        public int status { get; set; }
    }
}
