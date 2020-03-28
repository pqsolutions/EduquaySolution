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
        private readonly IUserTypeData _usertypeData;

        public UserTypeService(IUserTypeDataFactory usertypeDataFactory)
        {
            _usertypeData = new UserTypeDataFactory().Create();
        }
        public string Add(UserTypeRequest utdata)
        {
            var result = _usertypeData.Add(utdata);
            return result;
        }

        public List<UserType> Retreive(int code)
        {
            var userType = _usertypeData.Retreive(code);
            return userType;
        }

        public List<UserType> Retreive()
        {
            var allUserTypes = _usertypeData.Retreive();
            return allUserTypes;
        }
    }
}
