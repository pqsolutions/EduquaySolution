using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SCRequest
    {

      
        public int chcId { get; set; }      
        public int phcId { get; set; }      
        public string hninId { get; set; }       
        public string scGovCode { get; set; }
        public string scName { get; set; }
        public string scAddress { get; set; }
        public string pincode { get; set; }
        public string isActive { get; set; }
        public string comments { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
    }
}
