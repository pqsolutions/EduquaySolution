using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.PNDTC
{
    public class AddSchedulingRequest
    {
        public string anwsubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public int counsellorId { get; set; }
        public string counsellingDateTime { get; set; }
        public int userId { get; set; }

    }
}
