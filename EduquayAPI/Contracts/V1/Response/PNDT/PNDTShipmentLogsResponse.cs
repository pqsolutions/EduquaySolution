using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.PNDT
{
    public class PNDTShipmentLogsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PNDTShipmentLog> ShipmentLogs { get; set; }
    }
    public class PNDTShipmentLog
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string shipmentDateTime { get; set; }
        public string senderName { get; set; }
        public string senderContact { get; set; }
        public string senderLocation { get; set; }
        public string receivingMolecularLab { get; set; }
        public string pndtLocation { get; set; }
        public List<PNDTShipmentLogsDetail> SamplesDetail { get; set; }
    }
}
