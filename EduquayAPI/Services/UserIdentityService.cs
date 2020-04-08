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

namespace EduquayAPI.Services
{
    public class UserIdentityService : IUserIdentityService
    {
        private readonly IUsersService _usersService;
        private readonly JwtSettings _jwtSettings;

        public UserIdentityService(IUsersService usersService, JwtSettings jwtSettings)
        {
            _usersService = usersService;
            _jwtSettings = jwtSettings;
        }

       

        public async Task<AuthenticationResult> AddNewRegisterAsync(AddUserRequest users, string password)
        {
            var user = await _usersService.FindByUsernameAsync(users.Username);
            if (user != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this Username already exist" }
                };
            }

            var userEmail = await _usersService.FindByEmailAsync(users.Email);
            if (userEmail != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this Email already exist" }
                };
            }
                       

            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var createUser = await _usersService.AddNewUserAsync(users, hashPassword);
            var newUser = new User()
            {
                Email = users.Email,
                Username = users.Username,
            };
            if (!createUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createUser.Errors.Select(x => x)
                };
            }

            newUser.ID = createUser.Id;
            return GenerateAuthenticationResult(newUser);
        }

        private AuthenticationResult GenerateAuthenticationResult(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("ID", user.ID.ToString()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
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
                        Errors = new[] { $"Incorrect Password!" }
                    };
                }

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
    }
}
