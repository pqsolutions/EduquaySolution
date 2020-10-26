using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Request.Master;
using SentinelAPI.Contracts.V1.Response;
using SentinelAPI.Contracts.V1.Response.LoadMaster;
using SentinelAPI.DataLayer.Master;
using SentinelAPI.Models.Masters.User;
using SentinelAPI.Models.Template;
using SentinelAPI.Services.Mail;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Master.User
{
    public class UserService : IUserService
    {

        private readonly IUserData _userData;
        private readonly IMailService _mailService;

        public UserService(IUserData userData,IMailService mailService)
        {
            _userData = userData;
            _mailService = mailService;
        }
        public async Task<UserIdentityResult> AddNewUserAsync(AddUserRequest addUser, string password)
        {
            try
            {
                var userId = await _userData.AddNewUserAsync(addUser, password);

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

        public async Task<bool> CheckPasswordAsync(Users user, string password)
        {
            try
            {
                if (user == null)
                {
                    return false;
                }
                var userPassword = await _userData.CheckPasswordAsync(user);
                if (userPassword.Count <= 0) return false;
                // check a password
                var validPassword = BCrypt.Net.BCrypt.Verify(password, userPassword[0].Password);
                return validPassword;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Users> FindByUsernameAsync(string userName)
        {
            try
            {
                var users = await _userData.FindByUsernameAsync(userName);
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

        public static string GenerateOTPNumber()
        {
            string _numbers = "0123456789";
            Random random = new Random();
            StringBuilder builder = new StringBuilder(6);
            string numberAsString = "";
            int numberAsNumber = 0;

            for (var i = 0; i < 6; i++)
            {
                builder.Append(_numbers[random.Next(0, _numbers.Length)]);
            }

            numberAsString = builder.ToString();
            numberAsNumber = int.Parse(numberAsString);
            return numberAsString;
        }
        public static string GetResponse(string sURL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(sURL);
            request.MaximumAutomaticRedirections = 4;
            request.Credentials = CredentialCache.DefaultCredentials;
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
                string sResponse = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return sResponse;
            }
            catch
            {
                return "";
            }
        }

        public async Task<OTPResponse> SendOTP(SendOTPRequest oData)
        {
            OTPResponse sResponse = new OTPResponse();

            try
            {
                var users = await _userData.FindByUsernameAsync(oData.userName);

                if (users.Count > 0)
                {
                    var email = users[0].email;
                    var mobile = users[0].contactNo;
                    var userFullName = users[0].name;
                    var otp = GenerateOTPNumber();
                    if (email == "")
                    {
                        sResponse.status = "false";
                        sResponse.message = "Email does not exist for this user";
                    }
                    else
                    {
                        var otpSend = _userData.SendOTP(oData.userName, otp);
                        if (otpSend.msgRespone == true)
                        {
                            var sent = _mailService.ForgotPasswordOTPMail(otp, userFullName, email);
                            if(sent == true)
                            {
                                sResponse.status = "true";
                                sResponse.message = otpSend.msg;
                            }
                            else
                            {
                                sResponse.status = "false";
                                sResponse.message = "Mail sent Failed";
                            }
                        }
                        else
                        {
                            sResponse.status = "false";
                            sResponse.message = otpSend.msg;
                        }
                    }
                }
                else
                {
                    sResponse.status = "false";
                    sResponse.message = "Username does not exist";
                }
                return sResponse;

            }
            catch (Exception e)
            {
                sResponse.status = "false";
                sResponse.message = e.Message;
            }
            return sResponse;
        }

        public async Task<OTPResponse> ValidateOTP(OTPRequest oData)
        {
            OTPResponse sResponse = new OTPResponse();
            try
            {
                var users = await _userData.FindByUsernameAsync(oData.userName);

                if (users.Count > 0)
                {
                    var otpvalidate = _userData.ValidateOTP(oData);
                    if (otpvalidate.msgRespone == true)
                    {
                        sResponse.status = "true";
                        sResponse.message = otpvalidate.msg;
                    }
                    else
                    {
                        sResponse.status = "false";
                        sResponse.message = otpvalidate.msg;
                    }
                }
                else
                {
                    sResponse.status = "false";
                    sResponse.message = "Username does not exist";
                }
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.status = "false";
                sResponse.message = e.Message;
            }
            return sResponse;
        }

        public async Task<ServiceResponse> ChangePassword(LoginRequest lData)
        {
            ServiceResponse sResponse = new ServiceResponse();
            try
            {
                var users = await _userData.FindByUsernameAsync(lData.userName);

                if (users.Count > 0)
                {
                    var hashPassword = BCrypt.Net.BCrypt.HashPassword(lData.password);

                    var changePwd = _userData.ChangePassword(lData.userName, hashPassword);
                    if (changePwd.msgRespone == true)
                    {
                        sResponse.Status = "true";
                        sResponse.Message = changePwd.msg;
                    }
                    else
                    {
                        sResponse.Status = "false";
                        sResponse.Message = changePwd.msg;
                    }
                }
                else
                {
                    sResponse.Status = "false";
                    sResponse.Message = "Username does not exist";
                }
                return sResponse;
            }
            catch (Exception e)
            {
                sResponse.Status = "false";
                sResponse.Message = e.Message;
            }
            return sResponse;

        }
    }
}
