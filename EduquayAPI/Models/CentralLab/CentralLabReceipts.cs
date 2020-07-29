using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CentralLab
{
    public class CentralLabReceipts
    {
        public List<CentralLabReceiptsLog> ReceiptLog { get; set; }
        public List<CentralLabReceiptDetail> ReceiptDetail { get; set; }
    }
}
