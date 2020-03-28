using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IUserTypeData
    {
        string Add(UserTypeRequest utdata);
        List<UserType> Retreive(int code);
        List<UserType> Retreive();
    }
    public interface IUserTypeDataFactory
    {
        IUserTypeData Create();
    }
    public class UserTypeDataFactory : IUserTypeDataFactory
    {
        public IUserTypeData Create()
        {
            return new UserTypeData();
        }
    }
}
