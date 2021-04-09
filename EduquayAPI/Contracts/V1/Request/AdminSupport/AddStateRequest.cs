using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.AdminSupport
{
    public class AddStateRequest
    {
        public string stateGovCode { get; set; }
        public string name { get; set; }
        public string shortName { get; set; }
        public string comments { get; set; }
        public int userId { get; set; }
    }
}
