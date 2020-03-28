using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response
{
    public class AuthFailedResponse
    {
        public bool Status { get; set; }
        public IEnumerable<string> Errors { get; set; }

    }
}
