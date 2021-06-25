using EduquayAPI.Models.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Support
{
    public class BarcodeErrorReportResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<BarcodeErrorReportDetail> data { get; set; }
    }
}
