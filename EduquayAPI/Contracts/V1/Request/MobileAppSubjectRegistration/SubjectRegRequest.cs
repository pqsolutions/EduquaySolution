using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration
{
    public class SubjectRegRequest
    {
        public PrimaryDetailRequest subjectPrimaryRequest { get; set; }
        public AddressDetailRequest subjectAddressRequest { get; set; }
        public PregnancyDetailRequest subjectPregnancyRequest { get; set; }
        public ParentDetailRequest subjectParentRequest { get; set; }
    }
}
