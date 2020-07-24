using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration
{
    public class AddSubjectRequest
    {
        public string deviceId { get; set; }
        public AddSubjectDataRequest data { get; set; }
    }

    public class AddSubjectDataRequest
    {
        public List<SubjectRegRequest> subjectsRequest { get; set; }

    }
}
