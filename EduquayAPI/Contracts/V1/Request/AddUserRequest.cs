using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class AddUserRequest
    {

      
        public int UserType_ID { get; set; }
        public int UserRole_ID { get; set; }
        public string User_gov_code { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int StateID { get; set; }
        public int DistrictID { get; set; }
        public int BlockID { get; set; }
        public int CHCID { get; set; }
        public int PHCID { get; set; }
        public int SCID { get; set; }
        public int RIID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string Email { get; set; }
        public int GovIDType_ID { get; set; }
        public string GovIDDetails { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string Comments { get; set; }
        public string IsActive { get; set; }
       // public string DigitalSignature { get; set; }

    }
}
