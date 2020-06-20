using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response
{
    public class SubjectSampleResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public List<SubjectSamples> SubjectList { get; set; }
    }
}
