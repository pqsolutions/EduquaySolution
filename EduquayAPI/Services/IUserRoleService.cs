using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IUserRoleService
    {
        string Add(UserRoleRequest urdata);
        List<UserRole> Retreive(int code);
        List<UserRole> Retreive();
    }
}
