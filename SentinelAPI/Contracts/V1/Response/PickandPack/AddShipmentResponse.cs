using SentinelAPI.Models.PickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.PickandPack
{
    public class AddShipmentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public ShipmentsId Shipment { get; set; }
    }
}
