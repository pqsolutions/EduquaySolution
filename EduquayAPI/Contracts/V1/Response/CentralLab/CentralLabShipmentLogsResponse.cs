using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CentralLab
{
    public class CentralLabShipmentLogsResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CLShipmentLog> ShipmentLogs { get; set; }
    }
    public class CLShipmentLog
    {
        public int id { get; set; }
        public string shipmentId { get; set; }
        public string labTechnicianName { get; set; }
        public string centralLabName { get; set; }
        public string receivingMolecularLab { get; set; }
        public string logisticsProviderName { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string contactNo { get; set; }
        public string shipmentDateTime { get; set; }
        public List<CentralLabShipmentLogsDetail> SamplesDetail { get; set; }
    }
}
