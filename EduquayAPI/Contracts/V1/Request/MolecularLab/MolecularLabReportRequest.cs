using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MolecularLab
{
    public class MolecularLabReportRequest
    {
        public int molecularLabId { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int districtId { get; set; }
        public int chcId { get; set; }
    }
}
