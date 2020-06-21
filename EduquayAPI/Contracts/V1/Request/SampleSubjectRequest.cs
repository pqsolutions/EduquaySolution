using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SampleSubjectRequest
    {
        public string uniqueSubjectId { get; set; }
        public string sampleType { get; set; }
    }
}
