using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IUserRoleData
    {
        string Add(UserRoleRequest urdata);
        List<UserRole> Retreive(int code);
        List<UserRole> Retreive();
    }
    public interface IUserRoleDataFactory
    {
        IUserRoleData Create();
    }
    public class UserRoleDataFactory : IUserRoleDataFactory
    {
        public IUserRoleData Create()
        {
            return new UserRoleData();
        }
    }
}
