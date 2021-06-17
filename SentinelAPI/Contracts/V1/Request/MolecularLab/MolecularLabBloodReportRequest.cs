using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.MolecularLab
{
    public class MolecularLabBloodReportRequest
    {
        public int molecularLabId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
    }
}
