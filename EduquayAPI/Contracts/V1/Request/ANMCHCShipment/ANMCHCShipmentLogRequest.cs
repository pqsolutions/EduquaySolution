using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMCHCShipment
{
    public class ANMCHCShipmentLogRequest
    {
        public int userId { get; set; }
        public string shipmentFrom { get; set; }
    }
}
