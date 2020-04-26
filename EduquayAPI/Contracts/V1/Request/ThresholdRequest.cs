using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class ThresholdRequest
    {
        public int TestTypeID { get; set; }
        public string TestName { get; set; }
        public decimal ThresholdValue { get; set; }
        public string Isactive { get; set; }
        public string Comments { get; set; }
        public int Createdby { get; set; }
        public int Updatedby { get; set; }
    }
}
