using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileMTPReferal
    {
        public List<MobileMTPSubject> subject { get; set; }
        public List<MobileMTPSpouse> spouse { get; set; }
        public List<NotificationPostPNDTCounselling> postPndtCounselling { get; set; }
        public List<NotificationMTPService> mtpService { get; set; }
    }
}
