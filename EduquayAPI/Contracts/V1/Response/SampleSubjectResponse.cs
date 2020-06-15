using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response
{
    public class SampleSubjectResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<SampleSubject> SubjectDetail { get; set; }
    }
}
