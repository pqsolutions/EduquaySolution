using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class SubjectRegDetail
    {
        public List<SubjectPrimary> PrimarySubjectList { get; set; }
        public List<SubjectAddress> AddressSubjectList { get; set; }
        public List<SubjectPregnancy> PregnancySubjectList { get; set; }
        public List<SubjectParent> ParentSubjectList { get; set; }
        public List<TestResult> Results { get; set; }
        public List<MobilePrePNDTCounselling> prePndtCounselling { get; set; }
        public List<MobilePNDTesting> pndtTesting { get; set; }
        public List<MobilePostPNDTCounselling> postPndtCounselling { get; set; }
        public List<MobileMTPService> mtpService { get; set; }
    }
}
