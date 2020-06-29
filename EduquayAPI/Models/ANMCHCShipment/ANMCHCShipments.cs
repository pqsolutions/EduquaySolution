using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMCHCShipment
{
    public class ANMCHCShipments
    {

        public List<ANMCHCShipmentLogs> ShipmentLog { get; set; }
        public List<ANMCHCShipmentLogsDetail> ShipmentSubjectDetail { get; set; }
    }
}
