using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class ANMMobileMTPFollowUp
    {
        public List<MTPFollowupDetail> postMtpFollowUp { get; set; }
        public List<MTPFirstFollowup> firstFollowUp { get; set; }
        public List<MTPSecondFollowup> secondFollowUp { get; set; }
        public List<MTPThirdFollowup> thirdFollowUp { get; set; }
    }
}
