using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;
using Exception = System.Exception;

namespace EduquayAPI.Services
{
    public class UserService: IUserService
    {
        private readonly IUserData _userData;

        public UserService(IUserData userData)
        {
            _userData = userData;
        }    
        public async Task<UserModel> FindByEmailAsync(string email)
        {
            try
            {
                var userModel = await _userData.FindByEmailAsync(email);
                if (userModel.Count > 0)
                {
                    return userModel[0];
                }
                return null;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<UserIdentityResult> CreateAsync(UserModel userModel, string password)
        {
            try
            {
                var userId = await _userData.CreateUserAsync(userModel, password);

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
                    Errors = new []{e.Message}
                };
            }
        }

        public async Task<bool> CheckPasswordAsync(UserModel user, string password)
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
    }
}
