using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.SampleCollection
{
    public class AddSampleCollectionRequest
    {
        public string babySubjectId { get; set; }
        public int hospitalId { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDate { get; set; }
        public string sampleCollectionTime { get; set; }
        public int collectedBy { get; set; }
    }
}
