using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.PNDTC
{
    public class AddPNDTShipmentRequest
    {
        public string pndtFoetusId { get; set; }
        public string senderName { get; set; }
        public string senderContact { get; set; }
        public string sendingLocation { get; set; }
        public int receivingMolecularLabId { get; set; }
        public string shipmentDateTime { get; set; }
        public int pndtLocationId { get; set; }
        public int userId { get; set; }
    }
}
