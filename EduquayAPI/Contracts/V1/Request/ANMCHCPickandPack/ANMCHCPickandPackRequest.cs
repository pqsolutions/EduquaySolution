using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack
{
    public class ANMCHCPickandPackRequest
    {
        public int userId { get; set; }
        public string registeredFrom { get; set; }
    }
}
