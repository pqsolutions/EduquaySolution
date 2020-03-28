using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response
{
    public class AuthSuccessResponse
    {
        public bool Status { get; set; }
        public string Token { get; set; }
    }
}
