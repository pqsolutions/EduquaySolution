using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Contracts.V1.Request
{
    public class AddUserRequest
    {
        public int userTypeId { get; set; }
        public int userRoleId { get; set; }
        public string userGovCode { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int stateId { get; set; }
        public int districtId { get; set; }
        public int blockId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int scId { get; set; }
        public string  riId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string contactNo1 { get; set; }
        public string contactNo2 { get; set; }
        public string email { get; set; }
        public int govIdTypeId { get; set; }
        public string govIdDetails { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public string comments { get; set; }
        public string isActive { get; set; }
       // public string DigitalSignature { get; set; }

    }
}
