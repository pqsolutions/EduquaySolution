using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing
{
    public class AddCBCTestRequest
    {
        public string subjectId { get; set; }
        public string barcodeNo { get; set; }
        public int testingCHCId { get; set; }
        public string mcv { get; set; }
        public string rdw { get; set; }
        public string testCompleteOn { get; set; }
        public string sampleDateTime { get; set; }
        public int createdBy { get; set; }
    }
}
