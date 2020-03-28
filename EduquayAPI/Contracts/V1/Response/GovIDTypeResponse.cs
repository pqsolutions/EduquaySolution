using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class GovIDTypeResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<GovIDType> GovIDTypes { get; set; }
    }
}
