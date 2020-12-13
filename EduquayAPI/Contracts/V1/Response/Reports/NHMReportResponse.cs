using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Reports
{
    public class NHMReportResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<NHMReports> data { get; set; }
    }
}
