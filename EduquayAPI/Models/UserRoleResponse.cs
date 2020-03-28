using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class UserRoleResponse
    {
        public string Status { get; set; }
        public string Message { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
