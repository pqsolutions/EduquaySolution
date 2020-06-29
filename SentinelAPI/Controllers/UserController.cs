using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nancy.Json;
using SentinelAPI.Contracts.V1.Request.Login;
using SentinelAPI.Contracts.V1.Response.Authentication;
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
        public UserController(ILoginUserService userLoginService, IUserService userService)
        {
            _userLoginService = userLoginService;
            _userService = userService;
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

        [HttpPost]
        [Route("Add")]
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