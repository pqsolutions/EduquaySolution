using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MolecularLab
{
    public class MolecularLabReceipts
    {
        public List<MolecularLabReceiptsLog> ReceiptLog { get; set; }
        public List<MolecularLabReceiptDetail> ReceiptDetail { get; set; }
    }
}
