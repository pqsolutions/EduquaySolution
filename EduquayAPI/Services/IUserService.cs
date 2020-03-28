using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public interface IUserService
    {
        Task<UserModel> FindByEmailAsync(string email);
        Task<UserIdentityResult> CreateAsync(UserModel userModel, string password);
        Task<bool> CheckPasswordAsync(UserModel user, string password);
    }
}
