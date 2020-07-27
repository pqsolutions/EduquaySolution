using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CHCReceipt
{
    public class CHCShipments
    {
        public List<CHCShipmentLogs> ShipmentLog { get; set; }
        public List<CHCShipmentLogsDetail> ShipmentSubjectDetail { get; set; }
    }
}
