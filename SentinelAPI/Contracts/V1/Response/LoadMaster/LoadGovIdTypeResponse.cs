using SentinelAPI.Models.Masters.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.LoadMaster
{
    public class LoadGovIdTypeResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LoadGovIdType> GovIdType { get; set; }
    }
}
