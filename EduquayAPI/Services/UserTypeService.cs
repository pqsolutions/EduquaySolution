using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
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
        public string Add(UserTypeRequest utData)
        {
            try
            {
                if (utData.IsActive.ToLower() != "true")
                {
                    utData.IsActive = "false";
                }
                var result = _userTypeData.Add(utData);
                return string.IsNullOrEmpty(result) ? $"Unable to add user type data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add user type data - {e.Message}";
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
