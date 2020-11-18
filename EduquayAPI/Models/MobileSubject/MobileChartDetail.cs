using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileChartDetail
    {
        public List<MobileCharts> registration { get; set; }
        public List<MobileCharts> sampleCollection { get; set; }
        public List<MobileCharts> chcsstPositive { get; set; }
        public List<MobileCharts> hplcPositive { get; set; }
        public List<MobileCharts> pndtAccepted { get; set; }
        public List<MobileCharts> pndtCompleted { get; set; }
        public List<MobileCharts> mtpReffered { get; set; }
        public List<MobileCharts> mtpCompleted { get; set; }
    }
}
