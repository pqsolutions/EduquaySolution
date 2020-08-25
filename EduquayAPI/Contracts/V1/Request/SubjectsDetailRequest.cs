using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectsDetailRequest
    {
        public int userId { get; set; }
        public string userInput { get; set; }
    }
}
