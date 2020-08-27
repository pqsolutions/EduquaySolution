using EduquayAPI.Models.PMMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.PMMasters
{
    public class PMMasterResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PMMaster> data { get; set; }
    }
}
