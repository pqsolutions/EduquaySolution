using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMNotifications
{
    public class ANMUnsentSamplesResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<ANMUnsentSample> UnsentSamplesDetail { get; set; }
    }
    public class ANMUnsentSample
    {
        public string uniqueSubjectId { get; set; }
        public int sampleCollectionId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string sampleDateTime { get; set; }
        public string contactNo { get; set; }
        public string gestationalAge { get; set; }
        public string sampleAging { get; set; }

    }
}
