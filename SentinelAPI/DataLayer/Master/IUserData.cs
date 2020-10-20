using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Request.Master;
using SentinelAPI.Models.Masters.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Master
{
    public interface IUserData
    {
        Task<List<Users>> FindByUsernameAsync(string userName);
        Task<int> AddNewUserAsync(AddUserRequest addUser, string password);
        Task<List<UserPassword>> CheckPasswordAsync(Users user);
        MsgDetail SendOTP(string userName, string otp);
        MsgDetail ValidateOTP(OTPRequest oData);
        MsgDetail ChangePassword(string userName, string password);
    }
}
