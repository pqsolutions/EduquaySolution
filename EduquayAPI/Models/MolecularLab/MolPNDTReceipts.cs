using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolPNDTReceipts
    {
        public List<MolPNDTReceiptsLog> ReceiptLog { get; set; }
        public List<MolPNDTReceiptDetail> ReceiptDetail { get; set; }
    }
}
