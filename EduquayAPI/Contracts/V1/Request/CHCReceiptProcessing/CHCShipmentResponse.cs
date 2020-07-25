using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing
{
    public class CHCShipmentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public CHCShipmentID Shipment { get; set; }
    }
}
