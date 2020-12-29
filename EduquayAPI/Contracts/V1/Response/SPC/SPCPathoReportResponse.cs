using EduquayAPI.Models.SPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.SPC
{
    public class SPCPathoReportResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<SPCPathoReports> Subjects { get; set; }
    }
}
