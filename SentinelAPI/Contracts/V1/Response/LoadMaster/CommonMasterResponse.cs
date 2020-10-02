using SentinelAPI.Models.Masters.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.LoadMaster
{
    public class CommonMasterResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<LoadCommonMaster> data { get; set; }
    }
}
