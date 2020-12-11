using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
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
        public async Task<AddEditResponse> Add(UserRoleRequest urData)
        {
            var response = new AddEditResponse();
            try
            {
                if (urData.isActive.ToLower() != "true")
                {
                    urData.isActive = "false";
                }
                if (urData.userTypeId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid UserType Id";
                }
                else if (string.IsNullOrEmpty(urData.userRoleName))
                {
                    response.Status = "false";
                    response.Message = "Please enter user role name";
                }
                else
                {
                    var addEditResponse = _userRoleData.Add(urData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
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
