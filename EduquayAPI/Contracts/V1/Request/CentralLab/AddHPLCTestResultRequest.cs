using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class AddHPLCTestResultRequest
    {
        public string subjectId { get; set; }
        public int centralLabId { get; set; }
        public int testId { get; set; }
        public int userId { get; set; }
    }
}
