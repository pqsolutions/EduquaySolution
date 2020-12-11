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
    public class UserTypeService : IUserTypeService
    {
        private readonly IUserTypeData _userTypeData;

        public UserTypeService(IUserTypeDataFactory usertypeDataFactory)
        {
            _userTypeData = new UserTypeDataFactory().Create();
        }
        public async Task<AddEditResponse> Add(UserTypeRequest utData)
        {
            var response = new AddEditResponse();
            try
            {
                if (utData.isActive.ToLower() != "true")
                {
                    utData.isActive = "false";
                }
                if (string.IsNullOrEmpty(utData.userTypeName))
                {
                    response.Status = "false";
                    response.Message = "Please enter user type name";
                }
                else
                {
                    var addEditResponse = _userTypeData.Add(utData);
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

        public List<UserType> Retrieve(int code)
        {
            var userType = _userTypeData.Retrieve(code);
            return userType;
        }

        public List<UserType> Retrieve()
        {
            var allUserTypes = _userTypeData.Retrieve();
            return allUserTypes;
        }
    }
}
