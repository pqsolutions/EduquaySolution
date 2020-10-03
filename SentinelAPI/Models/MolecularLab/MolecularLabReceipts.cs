using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class MolecularLabReceipts
    {
        public List<MolecularReceiptsLog> ReceiptLog { get; set; }
        public List<MolecularLabReceiptDetail> ReceiptDetail { get; set; }
    }
}
