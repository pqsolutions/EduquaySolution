using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMReports
{
    public class ANMReportRequest
    {
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int userId { get; set; }
        public int riId { get; set; }
        public int subjectTypeId { get; set; }
        public int searchSection { get; set; }
        public int status { get; set; }
    }
}
