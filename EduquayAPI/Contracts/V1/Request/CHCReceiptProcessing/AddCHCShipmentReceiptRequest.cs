using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing
{
    public class AddCHCShipmentReceiptRequest
    {
        public List<AddReceivedShipmentRequest> shipmentReceivedRequest { get; set; }
    }
}
