using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileMetricsDetail
    {
        public MobileFieldMetrics fieldMetrics { get; set; }
        public MobileGAatReg gaAtReg { get; set; }
        public MobileCurrentGA criticalGA { get; set; }
        public MobileTestMetrics testMetrics { get; set; }
        public MobilePNDTObsMetrics pndtObsMetrics { get; set; }
        public MobileMTPObsMetrics mtpObsMetrics { get; set; }
        public MobilePostMTPMetrics postMTPMetrics { get; set; }
    }
}
