using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class SubjectAddressDetailRequest
    {
      
        public int religionId { get; set; }
        public int casteId { get; set; }
        public int communityId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string pincode { get; set; }
        public string stateName { get; set; }
        public int updatedBy { get; set; }
    }
}
