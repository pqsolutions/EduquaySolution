using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MolecularLab
{
    public class MolPNDTReceiptResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<MolPNDTLabReceiptLogs> MolecularLabReceipts { get; set; }
    }
    public class MolPNDTLabReceiptLogs
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string shipmentDateTime { get; set; }
        public string senderName { get; set; }
        public string senderContact { get; set; }
        public string senderLocation { get; set; }
        public string receivingMolecularLab { get; set; }
        public string pndtLocation { get; set; }
        public List<MolPNDTReceiptDetail> ReceiptDetail { get; set; }
    }
}
