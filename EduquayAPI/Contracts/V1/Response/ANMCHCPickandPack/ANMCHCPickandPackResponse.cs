using EduquayAPI.Models.ANMCHCPickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMCHCPickandPack
{
    public class ANMCHCPickandPackResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMCHCPickandPackSamples> SampleList { get; set; }
    }
}
