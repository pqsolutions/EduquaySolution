using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CentralLab
{
    public class CentralLabReceiptResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CentralLabReceiptLog> CentralLabReceipts { get; set; }
    }
    public class CentralLabReceiptLog
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string labTechnicianName { get; set; }
        public string shipmentDateTime { get; set; }
        public string district { get; set; }
        public string testingCHC { get; set; }
        public string centralLabName { get; set; }

        public List<CentralLabReceiptDetail> ReceiptDetail { get; set; }
    }
}
