using Microsoft.IdentityModel.Tokens;
using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Response.Authentication;
using SentinelAPI.Models.Masters;
using SentinelAPI.Options;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using BCrypt.Net;
using SentinelAPI.Services.Master.User;
using SentinelAPI.Models.Masters.User;

namespace SentinelAPI.Services.Login
{
    public class LoginUserService : ILoginUserService
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public LoginUserService(IUserService userService, JwtSettings jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
        }

        public async Task<AuthenticationResult> AddNewRegisterAsync(AddUserRequest user, string password)
        {
            var users = await _userService.FindByUsernameAsync(user.userName);
            if (users != null)
            {
                return new AuthenticationResult
                {
                    errors = new[] { "User with this Username / Email already exist" }
                };
            }

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var createUser = await _userService.AddNewUserAsync(user, hashPassword);

            var newUser = new Users()
            {
                email = user.email,
                userName = user.userName,
            };
            if (!createUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    errors = createUser.Errors.Select(x => x)
                };
            }

            newUser.id = createUser.Id;
            return GenerateAuthenticationResult(newUser);
        }

        public async Task<AuthenticationResult> LoginAsync(string userName, string password)
        {
            try
            {

                var user = await _userService.FindByUsernameAsync(userName);
                if (user == null)
                {
                    return new AuthenticationResult
                    {
                        errors = new[] { "User with this Username / Email does not exist" }
                    };
                }

                var validPassword = await _userService.CheckPasswordAsync(user, password);
                if (!validPassword)
                {
                    return new AuthenticationResult
                    {
                        errors = new[] { $"Incorrect Password!" }
                    };
                }

                return GenerateAuthenticationResult(user);
            }
            catch (Exception e)
            {
                return new AuthenticationResult
                {
                    success = false,
                    token = null,
                    errors = new[] { e.Message }
                };
            }
        }

        private AuthenticationResult GenerateAuthenticationResult(Users user)
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
                success = true,
                token = tokenHandler.WriteToken(token),
                created = DateTime.UtcNow,
                expiry = expiryDateTime,
                errors = null
            };
        }
    }
}
