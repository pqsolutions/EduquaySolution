using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing
{
    public class AddSSTestRequest
    {
        public string subjectId { get; set; }
        public string barcodeNo { get; set; }
        public int testingCHCId { get; set; }
        public bool isPositive { get; set; }
        public int createdBy { get; set; }
    }
}
