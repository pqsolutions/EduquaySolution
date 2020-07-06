using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMCHCShipment
{
    public class CHCCHCShipmentLogsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CHC2CHCShipmentLog> ShipmentLogs { get; set; }
    }
    public class CHC2CHCShipmentLog
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string collectionCHCName { get; set; }
        public string chcLabTechnicianName { get; set; }
        public string testingCHC { get; set; }
        public string logisticsProviderName { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string contactNo { get; set; }
        public string shipmentDateTime { get; set; }
        public List<CHCCHCShipmentLogsDetail> SamplesDetail { get; set; }
    }
}
