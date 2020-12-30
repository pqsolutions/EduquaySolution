using EduquayAPI.Models.ANMReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMReport
{
    public class ANMReportResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<ANMReports> data { get; set; }
    }
}
