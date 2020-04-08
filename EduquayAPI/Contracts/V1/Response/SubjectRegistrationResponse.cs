using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.Contracts.V1.Response
{
    public class SubjectRegistrationResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<SubjectPrimaryDetail> primaryDetail { get; set; }
        public List<SubjectAddresDetail> addressDetail { get; set; }
        public List<SubjectPregnancyDetail> pregnancyDetail { get; set; }
        public List<SubjectParentDetail> parentDetail { get; set; }
    }
}
