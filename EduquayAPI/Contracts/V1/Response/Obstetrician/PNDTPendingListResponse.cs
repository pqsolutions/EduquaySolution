using EduquayAPI.Models.PNDTObstetrician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.Obstetrician
{
    public class PNDTPendingListResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<PNDTPending> data { get; set; }
    }
}
