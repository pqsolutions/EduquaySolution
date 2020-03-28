using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface IUserTypeService
    {
        string Add(UserTypeRequest utData);
        List<UserType> Retrieve(int code);
        List<UserType> Retrieve();
    }
}
