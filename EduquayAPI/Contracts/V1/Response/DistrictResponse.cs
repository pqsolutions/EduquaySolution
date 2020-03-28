using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class DistrictResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<District> Districts { get; set; }
    }
}
