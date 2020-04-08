using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectPregnancyDetailRequest
    {
      
        public string RCHID { get; set; }
        public string ECNumber { get; set; }
        public string LMP_Date { get; set; }
        public decimal Gestational_period { get; set; }
        public int G { get; set; }
        public int P { get; set; }
        public int L { get; set; }
        public int A { get; set; }
        
        public int UpdatedBy { get; set; }
    }
}
