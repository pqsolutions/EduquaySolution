using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class ANMMobileShipment
    {
        public List<MobileShipment> ShipmentLog { get; set; }
        public List<MobileShipmentSample> ShipmentSubjectDetail { get; set; }
    }
}
