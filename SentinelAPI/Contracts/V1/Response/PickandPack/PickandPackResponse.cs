using SentinelAPI.Models.PickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.PickandPack
{
    public class PickandPackResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public List<PickandPackDetails> pickandPackList { get; set; }
    }
}
