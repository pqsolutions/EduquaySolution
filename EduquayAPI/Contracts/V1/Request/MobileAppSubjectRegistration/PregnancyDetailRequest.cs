using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration
{
    public class PregnancyDetailRequest
    {
        public string uniqueSubjectId { get; set; }
        public string rchId { get; set; }
        public string ecNumber { get; set; }
        public string lmpDate { get; set; }
       // public decimal gestationalPeriod { get; set; }
        public int g { get; set; }
        public int p { get; set; }
        public int l { get; set; }
        public int a { get; set; }
        public int updatedBy { get; set; }
    }
}
