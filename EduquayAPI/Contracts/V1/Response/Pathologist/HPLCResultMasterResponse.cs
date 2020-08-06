using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Pathologist
{
    public class HPLCResultMasterResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<HPLCResult> hplcResults { get; set; }
    }
}
