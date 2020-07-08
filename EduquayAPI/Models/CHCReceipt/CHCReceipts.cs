using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CHCReceipt
{
    public class CHCReceipts
    {
        public List<CHCReceiptLog> ReceiptLog { get; set; }
        public List<CHCReceiptDetail> ReceiptDetail { get; set; }
    }
}
