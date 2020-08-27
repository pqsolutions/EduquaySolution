using EduquayAPI.Models.PNDT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.PNDT
{
    public class PrePNDTScheduledResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PrePNDTScheduled> data { get; set; }
    }
}
