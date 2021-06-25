using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.Support
{
    public class UpdateSSTRequest
    {
        public int sstId { get; set; }
        public string subjectId { get; set; }
        public string barcode { get; set; }
        public string oldSST { get; set; }
        public bool newSST { get; set; }
        public string remarks { get; set; }
        public int userId { get; set; }
    }
}
