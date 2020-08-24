using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Mobile
{
    public class AcknowledgementBarocdeRequest
    {
        public string deviceId { get; set; }
        public AcknowledgementBarcode data { get; set; }
    }

    public class AcknowledgeBarcode
    {
        public string barcodeNo { get; set; }
        public int userId { get; set; }
    }

    public class AcknowledgementBarcode
    {
        public List<AcknowledgeBarcode> AcknowledgementRequest { get; set; }
    }
}