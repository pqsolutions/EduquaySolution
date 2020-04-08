using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectRegistrationRequest
    {   
       
        public SubjectPrimaryDetailRequest SubjectPrimaryRequest { get; set; }
        public SubjectAddressDetailRequest SubjectAddressRequest { get; set; }
        public SubjectPregnancyDetailRequest SubjectPregnancyRequest { get; set; }
        public SubjectParentDetailRequest SubjectParentRequest { get; set; }
    }
}
