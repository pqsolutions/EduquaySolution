using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MolecularLab
{
    public class AddMolecularLabReceiptRequest
    {
        public List<AddMolecularReceiptRequest> shipmentReceivedRequest { get; set; }
    }
}
