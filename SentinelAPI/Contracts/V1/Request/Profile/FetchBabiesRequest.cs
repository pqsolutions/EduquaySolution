using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Profile
{
    public class FetchBabiesRequest
    {
        public int hospitalId { get; set; }
        public string babyInput { get; set; }
    }
}
