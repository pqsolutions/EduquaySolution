using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Mother
{
    public class FetchMotherRequest
    {
        public int hospitalId { get; set; }
        public string motherInput { get; set; }
    }
}
