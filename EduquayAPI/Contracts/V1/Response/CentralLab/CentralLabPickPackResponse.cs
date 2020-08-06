using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.CentralLab
{
    public class CentralLabPickPackResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<CentralLabPickandPack> PickandPack { get; set; }
    }
}
