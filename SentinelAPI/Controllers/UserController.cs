using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nancy.Json;
using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Request.Master;
using SentinelAPI.Contracts.V1.Response;
using SentinelAPI.Contracts.V1.Response.Authentication;
using SentinelAPI.Contracts.V1.Response.LoadMaster;
using SentinelAPI.Services.Login;
using SentinelAPI.Services.Master.User;

namespace SentinelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ILoginUserService _userLoginService;
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(ILoginUserService userLoginService, IUserService userService,ILogger<UserController> logger)
        {
            _userLoginService = userLoginService;
            _userService = userService;
            _logger = logger;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    status = false,
                    errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _userLoginService.LoginAsync(request.userName, request.password);

            if (!authResponse.success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    status = false,
                    errors = authResponse.errors
                });
            }

            return Ok(new AuthSuccessResponse
            {
                status = true,
                username = request.userName,
                userDetail = await _userService.FindByUsernameAsync(request.userName),
                token = authResponse.token,
                created = new JavaScriptSerializer().Serialize(authResponse.created),
                expiry = new JavaScriptSerializer().Serialize(authResponse.expiry)

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

            var otp = await _userService.SendOTP(oData);
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

            var otp = await _userService.ValidateOTP(oData);
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

            var pwd = await _userService.ChangePassword(lData);
            _logger.LogInformation($"Change passwords {pwd}");
            return Ok(new ServiceResponse
            {
                Status = pwd.Status,
                Message = pwd.Message,
            });
        }

        [HttpPost]
        [Route("AddNewUser")]
        public async Task<IActionResult> Register(AddUserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    status = false,
                    errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var authResponse = await _userLoginService.AddNewRegisterAsync(request, request.password);

            if (!authResponse.success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    status = false,
                    errors = authResponse.errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                status = true,
                username =request.userName,
                userDetail = await _userService.FindByUsernameAsync(request.userName),
                token = authResponse.token,
                created = new JavaScriptSerializer().Serialize(authResponse.created),
                expiry = new JavaScriptSerializer().Serialize(authResponse.expiry)
            });;
        }
    }
}