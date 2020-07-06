using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMCHCShipment
{
    public class AddShipmentCHCCHCRequest
    {
        public string barcodeNo { get; set; }
        public int shipmentFrom { get; set; }
        public int chcUserId { get; set; }
        public int collectionCHCId { get; set; }
        public int logisticsProviderId { get; set; }
        public string deliveryExecutiveName { get; set; }
        public string executiveContactNo { get; set; }
        public int testingCHCId { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public int createdBy { get; set; }
        public string source { get; set; }
    }
}
