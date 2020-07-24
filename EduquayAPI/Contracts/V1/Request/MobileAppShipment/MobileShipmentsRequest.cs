using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppShipment
{
    public class MobileShipmentsRequest
    {
        public string deviceId { get; set; }
        public AddMobileShipmentRequest data { get; set; }
    }

    public class shipRequest
    {
        public MobileShipmentRequest shipment { get; set; }
    }

    public class AddMobileShipmentRequest
    {
        public List<shipRequest> ShipmentsRequest { get; set; }
    }
}
