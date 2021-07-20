using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CentralLab
{
    public class CLReportResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<CentralLabReportdetails> data { get; set; }
    }
}
