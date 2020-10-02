using SentinelAPI.Models.Shipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Shipments
{
    public class ShipmentLogResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ShipmentLogs> ShipmentLogs { get; set; }
    }

    public class ShipmentLogs
    {
        public int id { get; set; }
        public string generatedShipmentId { get; set; }
        public string sentinelHospitalName { get; set; }
        public string receivingMolecularLab { get; set; }
        public string senderName { get; set; }
        public string contactNo { get; set; }
        public string shipmentDateTime { get; set; }
        public List<ShipmentDetail> samplesDetail { get; set; }
    }
}
