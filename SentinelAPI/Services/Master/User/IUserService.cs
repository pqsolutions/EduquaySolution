using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Request.Master;
using SentinelAPI.Contracts.V1.Response;
using SentinelAPI.Contracts.V1.Response.LoadMaster;
using SentinelAPI.Models.Masters.User;
using SentinelAPI.Models.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SentinelAPI.Services.Master.User
{
    public interface IUserService
    {
        Task<Users> FindByUsernameAsync(string userName);
        Task<UserIdentityResult> AddNewUserAsync(AddUserRequest addUser, string password);
        Task<bool> CheckPasswordAsync(Users user, string password);
        Task<OTPResponse> SendOTP(SendOTPRequest oData);
        Task<OTPResponse> ValidateOTP(OTPRequest oData);
        Task<ServiceResponse> ChangePassword(LoginRequest lData);
    }
}
