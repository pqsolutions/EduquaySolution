using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.MolecularLab
{
    public class FetchMolecularReportsRequest
    {
       public int sampleStatus { get; set; }
        public int molecularLabId { get; set; }
        public int hospitalId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
