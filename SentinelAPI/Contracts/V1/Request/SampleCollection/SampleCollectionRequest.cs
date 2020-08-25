using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.SampleCollection
{
    public class SampleCollectionRequest
    {
        public int hospitalId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
