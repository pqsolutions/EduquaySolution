using EduquayAPI.Models.CHCReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CHCReport
{
    public class CHCReportsResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<CHCReports> data { get; set; }
    }
}
