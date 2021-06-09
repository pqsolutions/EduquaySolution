using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.MolecularLab
{
    public class MolLabReportIndividualRequest
    {
        public int molecularLabId { get; set; }
        public string input { get; set; }
    }
}
