using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class SubjectDetails
    {
        public List<SubjectPrimaryDetail> PrimarySubjectList { get; set; }
        public List<SubjectAddresDetail> AddressSubjectList { get; set; }
        public List<SubjectPregnancyDetail> PregnancySubjectList { get; set; }
        public List<SubjectParentDetail> ParentSubjectList { get; set; }
    }
}
