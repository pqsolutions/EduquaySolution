using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class TestTypeRequest
    {
        public string testTypeName { get; set; }
        public string isactive { get; set; }
        public string comments { get; set; }
        public int createdby { get; set; }
        public int updatedby { get; set; }
    }
}
