using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class AddSubjectSampleRequest
    {
        public string uniqueSubjectId { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDate { get; set; }
        public string sampleCollectionTime { get; set; }
        public string reason { get; set; }
        public int collectionFrom { get; set; }
        public int collectedBy { get; set; }
    }
}
