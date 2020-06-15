using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;


namespace EduquayAPI.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IUserRoleData _userRoleData;

        public UserRoleService(IUserRoleDataFactory userRoleDataFactory)
        {
            _userRoleData = new UserRoleDataFactory().Create();
        }
        public string Add(UserRoleRequest urData)
        {
            try
            {
                if (urData.isActive.ToLower() != "true")
                {
                    urData.isActive = "false";
                }
                if (urData.userTypeId <= 0)
                {
                    return "Invalid UserType Id";
                }
                var result = _userRoleData.Add(urData);
                return string.IsNullOrEmpty(result) ? $"Unable to add user role data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add user role data - {e.Message}";
            }
        }

        public List<UserRole> Retrieve(int code)
        {
            var userRole = _userRoleData.Retrieve(code);
            return userRole;
        }

        public List<UserRole> Retrieve()
        {
            var allUserRoles = _userRoleData.Retrieve();
            return allUserRoles;
        }
    }
}
