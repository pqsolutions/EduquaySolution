using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;
using EduquayAPI.Models.MailTemplate;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Exception = System.Exception;

namespace EduquayAPI.Services
{
    public class UsersService : IUsersService
    {

        private readonly IUsersData _usersData;
        private readonly IConfiguration _config;

        public UsersService(IUsersData usersData, IConfiguration config)
        {
            _usersData = usersData;
            _config = config;
        }
        public async Task<UserIdentityResult> AddNewUserAsync(AddUserRequest addUser, string password)
        {
            try
            {
                if (addUser.isActive.ToLower() != "true")
                {
                    addUser.isActive = "false";
                }
                var userId = await _usersData.AddNewUserAsync(addUser, password);

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

        public async Task<User> FindByEmailAsync(string email)
        {
            try
            {
                var users = await _usersData.FindByEmailAsync(email);
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

        public async Task<bool> CheckPasswordAsync(User user, string password)
        {
            try
            {
                if (user == null)
                {
                    return false;
                }
                var userPassword = await _usersData.CheckPasswordAsync(user);
                if (userPassword.Count <= 0) return false;
                // check a password
                var validPassword = BCrypt.Net.BCrypt.Verify(password, userPassword[0].password);
                return validPassword;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<User> FindByUsernameAsync(string userName)
        {
            try
            {
                var users = await _usersData.FindByUsernameAsync(userName);
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

        public List<User> FindByUserRole(int userRoleId)
        {
            var users = _usersData.RetrieveByUserRole(userRoleId);
            return users;
        }

        public List<User> FindByUserType(int userTypeId)
        {
            var users = _usersData.RetrieveByUserType(userTypeId);
            return users;
        }

        public List<User> Retrieve(int code)
        {
            var users = _usersData.Retrieve(code);
            return users;
        }

        public List<User> Retrieve()
        {
            var users = _usersData.Retrieve();
            return users;
        }

        public List<User> RetrieveByEmail(string email)
        {
            var users = _usersData.RetrieveByEmail(email);
            return users;
        }

        public List<User> RetrieveByUsername(string username)
        {
            var users = _usersData.RetrieveByUsername(username);
            return users;
        }

        public async Task<MobileLogin> CheckMobileLogin(int userId, string userName, string deviceId)
        {
            var checkStatus = await _usersData.CheckMobileLogin(userId, userName, deviceId);
            return checkStatus;
        }

        public async Task<MobileLogin> ResetLogin(string userName)
        {
            var reset = await _usersData.ResetLogin(userName);
            return reset;
        }

        public async Task<LogoutResponse> Logout(int anmId)
        {
            try
            {
                var logout = await _usersData.Logout(anmId);
                var allow = logout.allow;
                var msg = logout.msg;
                if (allow == true)
                {
                    return new LogoutResponse
                    {
                        Success = "true",
                        Message = msg,
                    };
                }
                else
                {
                    return new LogoutResponse
                    {
                        Success = "false",
                        Errors = new[] { msg }
                    };
                }
            }
            catch (Exception e)
            {
                return new LogoutResponse
                {
                    Success = "false",
                    Errors = new[] { e.Message }
                };
            }
        }

        public async Task<WebLogin> CheckWebLogin(int userId, string userName)
        {
            var checkStatus = await _usersData.CheckWebLogin(userId, userName);
            return checkStatus;
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
                var users = await _usersData.FindByUsernameAsync(oData.userName);

                if (users.Count > 0)
                {
                    var email = users[0].email;
                    var mobile = users[0].mobileNo;
                    var userFullName = users[0].name;
                    var otp = GenerateOTPNumber();
                    var host = _config.GetSection("ForgotPasswordSMTP").GetSection("host").Value;
                    var port = _config.GetSection("ForgotPasswordSMTP").GetSection("port").Value;
                    var uName = _config.GetSection("ForgotPasswordSMTP").GetSection("username").Value;
                    string pwd = _config.GetSection("ForgotPasswordSMTP").GetSection("pwd").Value;
                    string from = _config.GetSection("ForgotPasswordSMTP").GetSection("from").Value;
                    string cc = _config.GetSection("ForgotPasswordSMTP").GetSection("recipients").Value;
                    string recipients = email + cc;
                    string subject = _config.GetSection("ForgotPasswordSMTP").GetSection("subject").Value;
                    string body = _config.GetSection("ForgotPasswordSMTP").GetSection("message").Value + otp.ToString();

                    string mailTemplateSubject = _config.GetSection("ForgotPasswordMailTemplate").GetSection("Subject").Value;
                    string mailTemplateBody = _config.GetSection("ForgotPasswordMailTemplate").GetSection("Body").Value;
                    string mailBody = "";
                    //var forgetPasswordModel = JsonConvert.DeserializeObject<ForgetPassword>(mailTemplate);

                    if (email == "")
                    {
                        sResponse.status = "false";
                        sResponse.message = "Email does not exist for this user";
                    }
                    else
                    {

                        mailBody = "";
                        mailBody = mailBody + mailTemplateBody.Replace("#OTP", otp).Replace("#RecipientName",userFullName);
                        var mailMessage = new MailMessage(from, recipients, mailTemplateSubject, mailBody);
                        mailMessage.IsBodyHtml = true;

                        var otpSend = _usersData.SendOTP(oData.userName,otp);
                        if (otpSend.msgRespone == true)
                        {
                            var client = new SmtpClient(host, int.Parse(port))
                            {
                                Credentials = new NetworkCredential(uName, pwd),
                                EnableSsl = true
                            };
                            client.Send(mailMessage);
                            //client.Send(from, recipients, mailTemplateSubject, HttpUtility.HtmlDecode(mailBody));
                            sResponse.status = "true";
                            sResponse.message = otpSend.msg;
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
                var users = await _usersData.FindByUsernameAsync(oData.userName);

                if (users.Count > 0)
                {
                    var otpvalidate = _usersData.ValidateOTP(oData);
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
                var users = await _usersData.FindByUsernameAsync(lData.userName);

                if (users.Count > 0)
                {
                    var hashPassword = BCrypt.Net.BCrypt.HashPassword(lData.password);

                    var changePwd = _usersData.ChangePassword(lData.userName , hashPassword);
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





