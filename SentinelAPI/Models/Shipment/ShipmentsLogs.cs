using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Shipment
{
    public class ShipmentsLogs
    {
        public List<ShipmentLogs> ShipmentLog { get; set; }
        public List<ShipmentDetail> ShipmentSubjectDetail { get; set; }
    }
}
