using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.CentralLab
{
    public class HPLCTestAddRequest
    {
        public List<AddHPLCTestRequest> HPLCTestRequest { get; set; }
    }
}
