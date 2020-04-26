using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response
{
    public class ANMShipmentResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMPickandPackSamples> SampleList { get; set; }
    }
}
