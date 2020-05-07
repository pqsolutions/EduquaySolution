using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMShipment
{
    public class ShipmentIDGenerateRequest
    {
        public int SenderId { get; set; }
        public string Source { get; set; }
        public string ShipmentFrom { get; set; }
    }
}
