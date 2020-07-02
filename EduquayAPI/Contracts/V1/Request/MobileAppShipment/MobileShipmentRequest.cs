using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppShipment
{
    public class MobileShipmentRequest
    {
        public string shipmentId { get; set; }
        public string barcodeNo { get; set; }
        public int shipmentFrom { get; set; }
        public int anmId { get; set; }
        public int riId { get; set; }
        public int ilrId { get; set; }
        public int avdId { get; set; }
        public string avdContactNo { get; set; }
        public int testingCHCId { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public int createdBy { get; set; }
        public string source { get; set; }
    }
}
