using EduquayAPI.Models.ANMCHCPickandPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMCHCPickandPack
{
    public class ANMCHCPickandPackResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMCHCPickandPackSample> SampleList { get; set; }
    }

    public class ANMCHCPickandPackSample
    {
        public string uniqueSubjectId { get; set; }
        public int sampleCollectionId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string sampleDateTime { get; set; }
        public string gestationalAge { get; set; }
        public string sampleAging { get; set; }

    }
}
