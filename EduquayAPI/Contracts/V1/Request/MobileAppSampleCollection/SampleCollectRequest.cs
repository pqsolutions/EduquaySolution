using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection
{
    public class SampleCollectRequest
    {
        public string deviceId { get; set; }
        public AddSampleCollectionRequest data { get; set; }
    }

    public class sampleRequest
    {
        public SampleCollectionsRequest samples { get; set; }
    }

    public class AddSampleCollectionRequest
    {
        public List<sampleRequest> SampleCollectionsRequest { get; set; }
    }
}
