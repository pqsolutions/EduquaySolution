using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;
using EduquayAPI.Models.Subjects;

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
        public SubjectPrePNDTCounselling prePndtCounselling { get; set; }
        public SubjectPNDTTesting pndtTesting { get; set; }
        public SubjectPostPNDTCounselling postPndtCounselling { get; set; }
        public SubjectMTPService mtpService { get; set; }

    }
}
