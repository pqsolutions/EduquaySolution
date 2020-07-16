using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMCHCShipment
{
    public class ANMCHCShipmentLogsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ShipmentLogs> ShipmentLogs { get; set; }

    }

    public class ShipmentLogs
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string anmName { get; set; }
        public string testingCHC { get; set; }
        public string avdName { get; set; }
        public string contactNo { get; set; }
        public string alternateAVD { get; set; }
        public string alternateAVDContactNo { get; set; }
        public string ilrPoint { get; set; }
        public string riPoint { get; set; }
        public string shipmentDateTime { get; set; }
        public List<ANMCHCShipmentLogsDetail> SamplesDetail { get; set; }
    }
}