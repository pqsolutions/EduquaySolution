using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobilePNDTReferal
    {
        public List<MobilePNDTSubject> subject { get; set; }
        public List<MobilePNDTSpouse> spouse { get; set; }
        public List<NotificationPrePNDTCounselling> prePndtCounselling { get; set; }
        public List<NotificationPNDTesting> pndtTesting { get; set; }
    }
}
