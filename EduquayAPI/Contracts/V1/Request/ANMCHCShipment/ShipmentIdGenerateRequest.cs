using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMCHCShipment
{
    public class ShipmentIdGenerateRequest
    {
        public int sendingFromId { get; set; }
        public string source { get; set; }
        public int shipmentFrom { get; set; }
    }
}
