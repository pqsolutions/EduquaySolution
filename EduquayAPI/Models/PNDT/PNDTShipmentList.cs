using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDT
{
    public class PNDTShipmentList
    {
        public List<PNDTShipmentLogs> ShipmentLog { get; set; }
        public List<PNDTShipmentLogsDetail> ShipmentSubjectDetail { get; set; }
    }
}
