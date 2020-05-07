using EduquayAPI.Models.ANMShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMShipment
{
    public class ANMPickandPackResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMPickandPackSamples> SampleList { get; set; }
    }
}
