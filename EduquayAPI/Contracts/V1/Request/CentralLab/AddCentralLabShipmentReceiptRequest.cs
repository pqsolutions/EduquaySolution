using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class AddCentralLabShipmentReceiptRequest
    {
        public List<AddCentralShipmentRequest> shipmentReceivedRequest { get; set; }
    }
}
