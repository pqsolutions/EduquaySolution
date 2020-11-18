using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class UpdateStagingRequest
    {
        public string HbF { get; set; }
        public string HbA0 { get; set; }
        public string HbA2 { get; set; }
        public string HbS { get; set; }
        public string HbD { get; set; }
        public int testId { get; set; }
        public int userId { get; set; }
    }
}
