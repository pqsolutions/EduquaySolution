using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing
{
    public class AddCHCShipmentRequest
    {
        public string barcodeNo { get; set; }
        public string labTechnicianName { get; set; }
        public int chcUserId { get; set; }
        public int testingCHCId { get; set; }
        public int receivingCentralLabId { get; set; }
        public int logisticsProviderId { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string executiveContactNo { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public int createdBy { get; set; }
        public string source { get; set; }
    }
}
