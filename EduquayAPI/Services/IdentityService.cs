using EduquayAPI.Models;
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
    public class IdentityService: IIdentityService
    {
        private readonly IUserService _userService;
        private readonly JwtSettings _jwtSettings;

        public IdentityService(IUserService userService, JwtSettings jwtSettings)
        {
            _userService = userService;
            _jwtSettings = jwtSettings;
        }
        public async Task<AuthenticationResult> RegisterAsync(string email, string password)
        {
            var user = await _userService.FindByEmailAsync(email);
            if (user != null)
            {
                return new AuthenticationResult
                {
                    Errors = new[] { "User with this email already exist"}
                };
            }

            var newUser = new UserModel()
            {
                Email = email,
                Username = email,
            };
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(password);
            var createUser = await _userService.CreateAsync(newUser, hashPassword);

            if (!createUser.Succeeded)
            {
                return new AuthenticationResult
                {
                    Errors = createUser.Errors.Select(x => x)
                };
            }

            newUser.Id = createUser.Id;
            return GenerateAuthenticationResult(newUser);
        }

        public async Task<AuthenticationResult> LoginAsync(string email, string password)
        {
            try
            {

                var user = await _userService.FindByEmailAsync(email);
                if (user == null)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] {"User with this email does not exist"}
                    };
                }

                var validPassword = await _userService.CheckPasswordAsync(user, password);
                if (!validPassword)
                {
                    return new AuthenticationResult
                    {
                        Errors = new[] {$"Incorrect Password!"}
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
                    Errors = new[] {e.Message}
                };
            }
        }

        private AuthenticationResult GenerateAuthenticationResult(UserModel user)
        {
            var expiryDateTime = DateTime.UtcNow.AddMinutes(2);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim("id", user.Id.ToString()),
                }),
                //Expires = DateTime.UtcNow.AddHours(2),
                Expires = expiryDateTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return new AuthenticationResult
            {
                Success = true,
                Token = tokenHandler.WriteToken(token),
                Username = user.Email,
                Created = DateTime.UtcNow,
                Expiry = expiryDateTime,
                Errors = null

            };
        }
    }
}
