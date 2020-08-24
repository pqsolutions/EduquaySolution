using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectDetailRequest
    {
        public int userId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
