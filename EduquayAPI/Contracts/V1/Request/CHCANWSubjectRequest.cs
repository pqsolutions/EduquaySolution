using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class CHCANWSubjectRequest
    {
        public int chcId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
