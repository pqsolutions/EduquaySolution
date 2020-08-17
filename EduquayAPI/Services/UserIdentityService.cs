using EduquayAPI.Models;
using EduquayAPI.Contracts.V1.Request;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using EduquayAPI.Options;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using BCrypt.Net;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.DataLayer;
using EduquayAPI.Models.MobileSubject;

namespace EduquayAPI.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUsersService _usersService;
        private readonly JwtSettings _jwtSettings;
        private readonly IUsersData _usersData;

        public UserIdentityService(IUsersService usersService, JwtSettings jwtSettings, IUsersData usersData)
        {
            _usersService = usersService;
            _jwtSettings = jwtSettings;
            _usersData = usersData;
        }

       

        public async Task<AuthenticationResult> AddNewRegisterAsync(AddUserRequest users, string password)
        {
            var user = await _usersService.FindByUsernameAsync(users.userName);
            if (user != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this username already exist" }
                };
            }

            var userEmail = await _usersService.FindByEmailAsync(users.email);
            if (userEmail != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email already exist" }
                };
            }
                       

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var createUser = await _usersService.AddNewUserAsync(users, hashPassword);
            var newUser = new User()
            {
                email = users.email,
                userName = users.userName,
            };
            if (!createUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createUser.Errors.Select(x => x)
                };
            }

            newUser.id = createUser.Id;
            return GenerateAuthenticationResult(newUser);
        }

        private AuthenticationResult GenerateAuthenticationResult(User user)
        {
            var expiryDateTime = DateTime.UtcNow.AddHours(2);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.email),
                    new Claim("ID", user.id.ToString()),
                }),
                Expires = expiryDateTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                Created = DateTime.UtcNow,
                Expiry = expiryDateTime,               
                Errors = null
            };
        }


        private AuthenticationResult GenerateMobileAuthenticationResult(User user)
        {
           // var expiryDateTime = DateTime.UtcNow.AddHours(2);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.userName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.email),
                    new Claim("ID", user.id.ToString()),
                }),
              //  Expires = expiryDateTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                Created = DateTime.UtcNow,
               // Expiry = null,
                Errors = null
            };
        }

        public async Task<AuthenticationResult> LoginAsync(string userName, string password)
        {
            try
            {

                var user = await _usersService.FindByUsernameAsync(userName);
                if (user == null)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { "User with this Username does not exist" }
                    };
                }

                var validPassword = await _usersService.CheckPasswordAsync(user, password);
                if (!validPassword)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { $"Incorrect password!" }
                    };
                }
                var anmId = user.id;
                var userType = user.userType;
                if (userType.ToUpper() == "ANM")
                {
                    var checkmobile = await _usersService.CheckWebLogin(anmId, userName);
                    var allow = checkmobile.allow;
                    var msg = checkmobile.msg;
                    if (allow == false)
                    {
                        return new AuthenticationResult
                        {
                            Errors = new[] { msg }
                        };
                    }
                }
                _usersData.AddLoginDetails(user.id, userName, "", "PC");

                return GenerateAuthenticationResult(user);
            }
            catch (Exception e)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Token = null,
                    Errors = new[] { e.Message }
                };
            }
        }

        public async Task<AuthenticationResult> MobileLoginAsync(string userName, string password, string deviceId)
        {
            try
            {

                var user = await _usersService.FindByUsernameAsync(userName);
                if (user == null)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { "User with this username does not exist" }
                    };
                }

                var validPassword = await _usersService.CheckPasswordAsync(user, password);
                if (!validPassword)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { $"Incorrect password!" }
                    };
                }
                var anmId = user.id;
                var userType = user.userType;
                if(userType.ToUpper() != "ANM")
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] { $"This user not an ANM user!" }
                    };
                }
                else
                {
                    var checkmobile = await _usersService.CheckMobileLogin(anmId, userName, deviceId);
                    var allow = checkmobile.allow;
                    var msg = checkmobile.msg;
                    if(allow == false)
                    {
                        return new AuthenticationResult
                        {
                            Errors = new[] { msg }
                        };
                    }
                }
                _usersData.AddLoginDetails(user.id, userName, deviceId, "TABLET");
                return GenerateMobileAuthenticationResult(user);
            }
            catch (Exception e)
            {
                return new AuthenticationResult
                {
                    Success = false,
                    Token = null,
                    Errors = new[] { e.Message }
                };
            }
        }

        public async Task<LoginResetResponse> ResetLogin(string userName, string password)
        {
            try
            {

                var user = await _usersService.FindByUsernameAsync(userName);
                if (user == null)
                {
                    return new LoginResetResponse 
                    {
                        Errors = new[] { "User with this username does not exist" }
                    };
                }

                var validPassword = await _usersService.CheckPasswordAsync(user, password);
                if (!validPassword)
                {
                    return new LoginResetResponse
                    {
                        Errors = new[] { $"Incorrect password!" }
                    };
                }
                var reset = await _usersService.ResetLogin(userName);
                var allow = reset.allow;
                var msg = reset.msg;
                if (allow == true)
                {
                    return new LoginResetResponse
                    {
                        Success = true,
                        Message = msg,
                    };
                }
                else
                {
                    return new LoginResetResponse
                    {
                        Success = false,
                        Message = msg,
                    };
                }
            }

            catch (Exception e)
            {
                return new LoginResetResponse 
                {
                    Success = false,
                    Errors = new[] { e.Message }
                };
            }
        }
    }
}
