using Microsoft.AspNetCore.Routing.Constraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Response.PNDT
{
    public class FileDetails
    {
        public string fileName { get; set; }
        public string fileLocation { get; set; }
    }
}
