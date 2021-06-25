using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Support
{
    public class UpdateLMPRequest
    {
        public string subjectId { get; set; }
        public string oldLMP { get; set; }
        public string newLMP { get; set; }
        public string remarks { get; set; }
        public int userId { get; set; }
    }
}
