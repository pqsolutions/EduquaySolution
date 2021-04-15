using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request.AdminSupport
{
    public class UpdateILRRequest
    {
        public int id { get; set; }
        public string name { get; set; }
        public string ilrCode { get; set; }
        public int chcId { get; set; }
        public bool isActive { get; set; }
        public string comments { get; set; }
        public int userId { get; set; }
    }
}
