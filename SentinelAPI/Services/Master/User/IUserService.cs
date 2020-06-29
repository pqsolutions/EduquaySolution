using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Models.Masters.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SentinelAPI.Services.Master.User
{
    public interface IUserService
    {
        Task<Users> FindByUsernameAsync(string userName);
        Task<UserIdentityResult> AddNewUserAsync(AddUserRequest addUser, string password);
        Task<bool> CheckPasswordAsync(Users user, string password);
    }
}
