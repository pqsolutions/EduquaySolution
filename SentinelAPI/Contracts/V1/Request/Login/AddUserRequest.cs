using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Contracts.V1.Request.Login
{
    public class AddUserRequest
    {
        public int userRoleId { get; set; }
        public int hospitalId { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public int districtId { get; set; }
        public int stateId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public int createdBy { get; set; }
        public string comments { get; set; }

    }
}
