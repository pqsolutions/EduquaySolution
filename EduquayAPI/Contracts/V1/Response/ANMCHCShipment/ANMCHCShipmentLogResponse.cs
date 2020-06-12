using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMCHCShipment
{
    public class ANMCHCShipmentLogResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMCHCShipmentLogs> ShipmentList { get; set; }
    }
}
