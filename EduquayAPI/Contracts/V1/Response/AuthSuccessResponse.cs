using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response
{
    public class AuthSuccessResponse
    {
        public string Status { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
        public string Created { get; set; }
        public string Expiry { get; set; }
        public User userDetail { get; set; }
    }
}
