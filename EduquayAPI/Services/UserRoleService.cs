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
        private readonly IUserRoleData _userroleData;

        public UserRoleService(IUserRoleDataFactory userroleDataFactory)
        {
            _userroleData = new UserRoleDataFactory().Create();
        }
        public string Add(UserRoleRequest urdata)
        {
            var result = _userroleData.Add(urdata);
            return result;
        }

        public List<UserRole> Retreive(int code)
        {
            var userRole = _userroleData.Retreive(code);
            return userRole;
        }

        public List<UserRole> Retreive()
        {
            var allUserRoles = _userroleData.Retreive();
            return allUserRoles;
        }
    }
}
