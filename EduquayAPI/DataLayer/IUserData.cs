using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface IUserData
    {
        Task<List<UserModel>> FindByEmailAsync(string email);
        Task<int> CreateUserAsync(UserModel user, string password);
        Task<List<UserPassword>> CheckPasswordAsync(UserModel user);

    }
}
