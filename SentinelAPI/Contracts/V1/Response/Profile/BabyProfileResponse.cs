using SentinelAPI.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Profile
{
    public class BabyProfileResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<BabyProfile> data { get; set; }
    }
}
