using EduquayAPI.Models.AdminiSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.AdminSupport
{
    public class SADistrictResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<DistrictDetail> data { get; set; }
    }
}
