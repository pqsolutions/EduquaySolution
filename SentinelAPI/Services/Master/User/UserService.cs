using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.DataLayer.Master;
using SentinelAPI.Models.Masters.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Master.User
{
    public class UserService : IUserService
    {

        private readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<UserIdentityResult> AddNewUserAsync(AddUserRequest addUser, string password)
        {
            try
            {
                var userId = await _userData.AddNewUserAsync(addUser, password);

                return new UserIdentityResult
                {
                    Id = userId,
                    Succeeded = true,
                    Errors = null
                };
            }
            catch (Exception e)
            {
                return new UserIdentityResult
                {
                    Id = 0,
                    Succeeded = false,
                    Errors = new[] { e.Message }
                };
            }
        }

        public async Task<bool> CheckPasswordAsync(Users user, string password)
        {
            try
            {
                if (user == null)
                {
                    return false;
                }
                var userPassword = await _userData.CheckPasswordAsync(user);
                if (userPassword.Count <= 0) return false;
                // check a password
                var validPassword = BCrypt.Net.BCrypt.Verify(password, userPassword[0].Password);
                return validPassword;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Users> FindByUsernameAsync(string userName)
        {
            try
            {
                var users = await _userData.FindByUsernameAsync(userName);
                if (users.Count > 0)
                {
                    return users[0];
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
