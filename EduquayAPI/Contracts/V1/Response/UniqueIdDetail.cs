using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response
{
    public class UniqueIdDetail
    {
        public bool status { get; set; }
        public string message { get; set; }
        public string uniqueSubjectId { get; set; }
    }
}
