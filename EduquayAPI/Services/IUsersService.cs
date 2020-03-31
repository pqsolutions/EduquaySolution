using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;
using EduquayAPI.Contracts.V1.Request;

namespace EduquayAPI.Services
{
    public interface IUsersService
    {
        Task<User> FindByEmailAsync(string email);
        Task<User> FindByUsernameAsync(string userName);
        Task<UserIdentityResult> AddNewUserAsync(AddUserRequest addUser, string password);
        Task<bool> CheckPasswordAsync(User user, string password);
        List<User> Retrieve(int code);
        List<User> Retrieve();
        List<User> RetrieveByEmail(string email);
        List<User> RetrieveByUsername(string username);
        List<User> FindByUserType(int userTypeId);
        List<User> FindByUserRole(int userRoleId);

    }
}
