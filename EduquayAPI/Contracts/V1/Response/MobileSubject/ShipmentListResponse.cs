using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.MobileSubject
{
    public class ShipmentListResponse
    {
        public string Status { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
        public List<ShipmentIdDetail> ShipmentIds { get; set; }
    }
}
