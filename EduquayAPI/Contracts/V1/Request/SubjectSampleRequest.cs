using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectSampleRequest
    {
        public int ANMID { get; set; }
        public string FromDate { get; set; }
        public string ToDate { get; set; }
        public int SubjectType { get; set; }
    }
}
