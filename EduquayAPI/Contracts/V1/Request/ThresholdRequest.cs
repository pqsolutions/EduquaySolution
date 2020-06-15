using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class ThresholdRequest
    {
        public int testTypeID { get; set; }
        public string testName { get; set; }
        public decimal thresholdValue { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
    }
}
