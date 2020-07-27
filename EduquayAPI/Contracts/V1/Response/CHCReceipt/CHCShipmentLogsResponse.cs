using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CHCReceipt
{
    public class CHCShipmentLogsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CHCShipmentLog> ShipmentLogs { get; set; }
    }
    public class CHCShipmentLog
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string labTechnicianName { get; set; }
        public string testingCHC { get; set; }
        public string receivingCentralLab { get; set; }
        public string logisticsProviderName { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string contactNo { get; set; }
        public string shipmentDateTime { get; set; }
        public List<CHCShipmentLogsDetail> SamplesDetail { get; set; }
    }
}
