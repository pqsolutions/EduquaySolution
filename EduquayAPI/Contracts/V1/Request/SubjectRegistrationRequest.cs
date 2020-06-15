using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectRegistrationRequest
    {   
       
        public SubjectPrimaryDetailRequest subjectPrimaryRequest { get; set; }
        public SubjectAddressDetailRequest subjectAddressRequest { get; set; }
        public SubjectPregnancyDetailRequest subjectPregnancyRequest { get; set; }
        public SubjectParentDetailRequest subjectParentRequest { get; set; }
    }
}
