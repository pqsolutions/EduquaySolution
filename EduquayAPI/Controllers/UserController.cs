using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.Controllers
{
    [Authorize]
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUsersService _usersService;
        public UserController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        [HttpPost]
        [Route("Logout/{userId}")]
        public async Task<IActionResult> ResetLogin(int userId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var logout = await _usersService.Logout(userId);

            if (logout.Success == "true")
            {
                return Ok(new LogoutResponse
                {
                    Success = logout.Success,
                    Message = logout.Message
                });
            }
            else
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = "false",
                    Errors = logout.Errors
                });
            }

           
        }
    }
}