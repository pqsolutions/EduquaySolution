using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Support
{
    public class UpdateRCHIDRequest
    {
        public string rchId { get; set; }
        public string revisedRCHID { get; set; }
        public int userId { get; set; }
    }
}
