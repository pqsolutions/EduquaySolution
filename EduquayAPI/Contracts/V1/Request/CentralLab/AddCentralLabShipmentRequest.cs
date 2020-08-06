using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class AddCentralLabShipmentRequest
    {
        public string barcodeNo { get; set; }
        public string labTechnicianName { get; set; }
        public int centralLabUserId { get; set; }
        public int centralLabId { get; set; }
        public string centralLabLocation { get; set; }
        public int receivingMolecularLabId { get; set; }
        public string logisticsProviderName { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string executiveContactNo { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public string source { get; set; }
    }
}
