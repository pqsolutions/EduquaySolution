using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing
{
    public class AddCBCTestResultRequest
    {
        public string subjectId { get; set; }
        public int confirmStatus { get; set; }
        public int testingCHCId { get; set; }
        public int testedId { get; set; }
        public int userId { get; set; }
    }
}
