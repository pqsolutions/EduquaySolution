using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectAddressDetailRequest
    {
      
        public int Religion_Id { get; set; }
        public int Caste_Id { get; set; }
        public int Community_Id { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Pincode { get; set; }
        public int UpdatedBy { get; set; }
    }
}
