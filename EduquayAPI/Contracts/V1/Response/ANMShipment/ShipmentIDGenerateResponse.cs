using EduquayAPI.Models.ANMShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMShipment
{
    public class ShipmentIDGenerateResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMShipmentID> ShipmentID { get; set; }
    }
}
