using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMCHCShipment
{
    public class CHCCHCShipments
    {
        public List<CHCCHCShipmentLogs> ShipmentLog { get; set; }
        public List<CHCCHCShipmentLogsDetail> ShipmentSubjectDetail { get; set; }
    }
}
