using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Response.Authentication;
using SentinelAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Login
{
    public interface ILoginUserService
    {
        Task<AuthenticationResult> AddNewRegisterAsync(AddUserRequest user, string password);
        Task<AuthenticationResult> LoginAsync(string userName, string password);
    }
}
