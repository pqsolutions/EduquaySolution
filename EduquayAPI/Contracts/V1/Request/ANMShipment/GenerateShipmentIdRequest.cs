using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMShipment
{
    public class GenerateShipmentIdRequest
    {
        public int senderId { get; set; }
        public string source { get; set; }
        public string shipmentFrom { get; set; }
    }
}
