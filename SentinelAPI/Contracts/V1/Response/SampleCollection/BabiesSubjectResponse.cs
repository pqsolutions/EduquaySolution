using SentinelAPI.Models.SampleCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.SampleCollection
{
    public class BabiesSubjectResponse
    {
        public string status { get; set; }
        public string message { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public List<SampleCollectionList> data { get; set; }
    }
}
