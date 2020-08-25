using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Infant
{
    public class GetMotherRequest
    {
        public int hospitalId { get; set; }
        public string motherUniqueSubjectId { get; set; }
    }
}
