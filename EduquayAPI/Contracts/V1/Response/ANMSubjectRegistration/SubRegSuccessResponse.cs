using EduquayAPI.Models.ANMSubjectRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration
{
    public class SubRegSuccessResponse
    {
        public string Status { get; set; }
        public bool Valid { get; set; }
        public string Message { get; set; }
        public List<UniqueSubjectIdDetail> SuccessIds { get; set; }
    }
}
