using SentinelAPI.Models.Mother;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Response.Mother
{
    public class AddMotherResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public string MotherSubjectId { get; set; }
    }
}
