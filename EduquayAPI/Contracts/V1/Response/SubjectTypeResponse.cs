using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectTypeResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<SubjectType> SubjectTypes { get; set; }
    }
}
