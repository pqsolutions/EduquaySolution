using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;
using Exception = System.Exception;

namespace EduquayAPI.Services
{
    public class UsersService : IUsersService
    {

        private readonly IUsersData _usersData;

        public UsersService(IUsersData usersData)
        {
            _usersData = usersData;
        }
        public async Task<UserIdentityResult> AddNewUserAsync(AddUserRequest addUser, string password)
        {
            try
            {
                if (addUser.isActive.ToLower() != "true")
                {
                    addUser.isActive = "false";
                }
                var userId = await _usersData.AddNewUserAsync(addUser, password);

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

        public async Task<User> FindByEmailAsync(string email)
        {
            try
            {
                var users = await _usersData.FindByEmailAsync(email);
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

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            try
            {
                if (user == null)
                {
                    return false;
                }
                var userPassword = await _usersData.CheckPasswordAsync(user);
                if (userPassword.Count <= 0) return false;
                // check a password
                var validPassword = BCrypt.Net.BCrypt.Verify(password, userPassword[0].password);
                return validPassword;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> FindByUsernameAsync(string userName)
        {
            try
            {
                var users = await _usersData.FindByUsernameAsync(userName);
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

        public List<User> FindByUserRole(int userRoleId)
        {
            var users = _usersData.RetrieveByUserRole(userRoleId);
            return users;
        }

        public List<User> FindByUserType(int userTypeId)
        {
            var users = _usersData.RetrieveByUserType(userTypeId);
            return users;
        }

        public List<User> Retrieve(int code)
        {
            var users = _usersData.Retrieve(code);
            return users;
        }

        public List<User> Retrieve()
        {
            var users = _usersData.Retrieve();
            return users;
        }

        public List<User> RetrieveByEmail(string email)
        {
            var users = _usersData.RetrieveByEmail(email);
            return users;
        }

        public List<User> RetrieveByUsername(string username)
        {
            var users = _usersData.RetrieveByUsername(username);
            return users;
        }

        public async Task<MobileLogin> CheckMobileLogin(int userId, string userName, string deviceId)
        {
            var checkStatus = await _usersData.CheckMobileLogin(userId, userName, deviceId);
            return checkStatus;
        }

        public async Task<MobileLogin> ResetLogin(string userName)
        {
            var reset = await _usersData.ResetLogin(userName);
            return reset;
        }

        public async Task<LogoutResponse> Logout(int anmId)
        {
            try
            {
                var logout = await _usersData.Logout(anmId);
                var allow = logout.allow;
                var msg = logout.msg;
                if (allow == true)
                {
                    return new LogoutResponse
                    {
                        Success = "true",
                        Message = msg,
                    };
                }
                else
                {
                    return new LogoutResponse
                    {
                        Success = "false",
                     Errors = new[] { msg }
                    };
                }
            }
            catch (Exception e)
            {
                return new LogoutResponse
                {
                    Success = "false",
                     Errors = new[] { e.Message }
                };
            }
        }

        public async Task<WebLogin> CheckWebLogin(int userId, string userName)
        {
            var checkStatus = await _usersData.CheckWebLogin(userId, userName);
            return checkStatus;
        }
    }
}





