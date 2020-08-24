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

        public List<SubjectsDetail> SubjectsDetail { get; set; }

    }

    public class SubjectsDetail
    {
        public SubjectPrimaryDetail PrimaryDetail { get; set; }
        public SubjectAddresDetail AddressDetail { get; set; }
        public SubjectPregnancyDetail PregnancyDetail { get; set; }
        public SubjectParentDetail ParentDetail { get; set; }

    }
}
