using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppShipment
{
    public class MobileShipmentsRequest
    {
        public List<shipRequest> ShipmentsRequest { get; set; }
    }

    public class shipRequest
    {
        public MobileShipmentRequest shipment { get; set; }
    }
}
