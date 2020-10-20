using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Profile
{
    public class FetchAllMotherRequest
    {
        public int hospitalId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }

    }
}
