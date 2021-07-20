using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CHCReceipt
{
    public class CHCReciptReportResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<CHCReceiptReportDetails> data { get; set; }
    }
}
