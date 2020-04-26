using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class TestTypeRequest
    {
        public string TestTypeName { get; set; }
        public string Isactive { get; set; }
        public string Comments { get; set; }
        public int Createdby { get; set; }
        public int Updatedby { get; set; }
    }
}
