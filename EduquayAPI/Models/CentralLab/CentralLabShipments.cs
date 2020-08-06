using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CentralLab
{
    public class CentralLabShipments
    {
        public List<CentralLabShipmentsLogs> ShipmentLog { get; set; }
        public List<CentralLabShipmentLogsDetail> ShipmentSubjectDetail { get; set; }
    }
}
