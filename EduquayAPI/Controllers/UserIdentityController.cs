using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserIdentityController : ControllerBase
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly IUsersService _usersService;
        private readonly ILogger<UserIdentityController> _logger;
        public UserIdentityController(IUserIdentityService userIdentityService, IUsersService usersService, ILogger<UserIdentityController> logger)
        {
            _userIdentityService = userIdentityService;
            _usersService = usersService;
            _logger = logger;
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Register(AddUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var authResponse = await _userIdentityService.AddNewRegisterAsync(request, request.password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Status = "true",
                userDetail = await _usersService.FindByUsernameAsync(request.userName),
                Token = authResponse.Token,
                Created = new JavaScriptSerializer().Serialize(authResponse.Created),
                Expiry = new JavaScriptSerializer().Serialize(authResponse.Expiry)
            });
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _userIdentityService.LoginAsync(request.userName, request.password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Status = "true",                
                userDetail = await _usersService.FindByUsernameAsync(request.userName),
                Token = authResponse.Token,
                Created = new JavaScriptSerializer().Serialize(authResponse.Created),
                Expiry = new JavaScriptSerializer().Serialize(authResponse.Expiry)

            });
        }


        [HttpPost]
        [Route("MobileLogin")]
        public async Task<IActionResult> MobileLogin(MobileLoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _userIdentityService.MobileLoginAsync(request.userName, request.password, request.deviceId);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = authResponse.Errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                Status = "true",
                userDetail = await _usersService.FindByUsernameAsync(request.userName),
                Token = authResponse.Token,
                Created = new JavaScriptSerializer().Serialize(authResponse.Created),
                Expiry = null,
            });
        }

        [HttpPost]
        [Route("ResetLogin")]
        public async Task<IActionResult> ResetLogin(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var reset = await _userIdentityService.ResetLogin(request.userName, request.password);

            if (!reset.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = reset.Errors
                });
            }

            return Ok(new LoginResetResponse 
            {
               Success = reset.Success,
               Message = reset.Message

            });
        }

        /// <summary>
        /// Send OTP for Forgot Password
        /// </summary>
        [HttpPost]
        [Route("SendOTP")]
        public async Task<IActionResult> SendOTP(SendOTPRequest oData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var otp = await _usersService.SendOTP(oData);
            _logger.LogInformation($"Send otp for forgot passwords {otp}");
            return Ok(new OTPResponse
            {
                status = otp.status,
                message = otp.message,
            });
        }

        /// <summary>
        /// Valididate OTP for Forgot Password
        /// </summary>
        [HttpPost]
        [Route("ValidateOTP")]
        public async Task<IActionResult> ValidateOTP(OTPRequest oData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var otp = await _usersService.ValidateOTP(oData);
            _logger.LogInformation($"validate otp for forgot passwords {otp}");
            return Ok(new OTPResponse
            {
                status = otp.status,
                message = otp.message,
            });
        }

        /// <summary>
        /// Valididate OTP for Forgot Password
        /// </summary>
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword(LoginRequest lData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var pwd = await _usersService.ChangePassword(lData);
            _logger.LogInformation($"Change passwords {pwd}");
            return Ok(new ServiceResponse
            {
                Status = pwd.Status,
                Message = pwd.Message,
                Result = null,
            });
        }


        [HttpGet]
        [Route("Retrieve")]
        public UserResponse GetUsers()
        {
            try
            {
                var users = _usersService.Retrieve();
                return users.Count == 0 ? new UserResponse { Status = "true", Message = "No users found", Users = new List<User>() } : new UserResponse { Status = "true", Message = string.Empty, Users = users };
            }
            catch (Exception e)
            {
                return new UserResponse { Status = "false", Message = e.Message, Users = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public UserResponse GetUsers(int code)
        {
            try
            {
                var users = _usersService.Retrieve(code);
                return users.Count == 0 ? new UserResponse { Status = "true", Message = "No users found", Users = new List<User>() } : new UserResponse { Status = "true", Message = string.Empty, Users = users };
            }
            catch (Exception e)
            {
                return new UserResponse { Status = "false", Message = e.Message, Users = null };
            }
        }

        [HttpGet]
        [Route("RetrieveByRole/{roleId}")]
        public UserResponse GetUsersbyRole(int roleId)
        {
            try
            {
                var users = _usersService.FindByUserRole(roleId);
                return users.Count == 0 ? new UserResponse { Status = "true", Message = "No users found", Users = new List<User>() } : new UserResponse { Status = "true", Message = string.Empty, Users = users };
            }
            catch (Exception e)
            {
                return new UserResponse { Status = "false", Message = e.Message, Users = null };
            }
        }

        [HttpGet]
        [Route("RetrieveByType/{typeId}")]
        public UserResponse GetUsersbyType(int typeId)
        {
            try
            {
                var users = _usersService.FindByUserType(typeId);
                return users.Count == 0 ? new UserResponse { Status = "true", Message = "No users found", Users = new List<User>() } : new UserResponse { Status = "true", Message = string.Empty, Users = users };
            }
            catch (Exception e)
            {
                return new UserResponse { Status = "false", Message = e.Message, Users = null };
            }
        }

        [HttpGet]
        [Route("RetrieveByEmail/{email}")]
        public UserResponse GetUsersbyEmail(string email)
        {
            try
            {
                var users = _usersService.RetrieveByEmail(email);
                return users.Count == 0 ? new UserResponse { Status = "true", Message = "No users found", Users = new List<User>() } : new UserResponse { Status = "true", Message = string.Empty, Users = users };
            }
            catch (Exception e)
            {
                return new UserResponse { Status = "false", Message = e.Message, Users = null };
            }
        }

        [HttpGet]
        [Route("RetrieveByUsername/{username}")]
        public UserResponse GetUsersbyUsername(string username)
        {
            try
            {
                var users = _usersService.RetrieveByUsername(username);
                return users.Count == 0 ? new UserResponse { Status = "true", Message = "No users found", Users = new List<User>() } : new UserResponse { Status = "true", Message = string.Empty, Users = users };
            }
            catch (Exception e)
            {
                return new UserResponse { Status = "false", Message = e.Message, Users = null };
            }
        }

        [Authorize]
        [HttpPost]
        [Route("LoggedUser")]
        public string LoggedUser()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity == null) return "Oops! User haven't yet logged in";
            var claim = identity.Claims.ToList();
            var userName = claim[0].Value;
            return $"Welcome {userName}";
        }



    }
}