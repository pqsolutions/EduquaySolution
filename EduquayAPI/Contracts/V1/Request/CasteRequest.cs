using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class CasteRequest
    {
        public string Castename { get; set; }
        public string IsActive { get; set; }
        public string Comments { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
    }
}
