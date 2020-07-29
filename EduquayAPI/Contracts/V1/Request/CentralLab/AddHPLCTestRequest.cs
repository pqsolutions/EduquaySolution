using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class AddHPLCTestRequest
    {
        public string subjectId { get; set; }
        public string barcodeNo { get; set; }
        public int centralLabId { get; set; }
        public string HbF { get; set; }
        public string HbA0 { get; set; }
        public string HbA2 { get; set; }
        public string HbS { get; set; }
        public string HbC { get; set; }
        public string HbD { get; set; }
        public int createdBy { get; set; }
    }
}
