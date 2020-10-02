using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.PickandPack
{
    public class AddPickandPackRequest
    {
        public string barcodeNo { get; set; }
        public int hospitalId { get; set; }
        public int molecularLabId { get; set; }
        public string senderName { get; set; }
        public string contactNo { get; set; }
        public string dateOfShipment { get; set; }
        public string timeOfShipment { get; set; }
        public int userId { get; set; }
    }
}
