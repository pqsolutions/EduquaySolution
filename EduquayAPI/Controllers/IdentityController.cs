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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IIdentityService _identityService;
        public IdentityController(IIdentityService identityService)
        {
            _identityService = identityService; 
        }

        [HttpPost(ApiRoutes.Identity.Register)]
        public async Task<IActionResult> Register(UserRegistrationRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = false,
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }
            var authResponse = await _identityService.RegisterAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = false,
                    Errors = authResponse.Errors
                });
            }
            return Ok(new AuthSuccessResponse
            {
                Status = true,
                Token = authResponse.Token,
            });
        }

        [HttpPost(ApiRoutes.Identity.Login)]
        public async Task<IActionResult> Login(UserLoginRequest request)
        {
            try
            {
            if (!ModelState.IsValid)
            {
                return BadRequest(new AuthFailedResponse
                {
                    Status = false,
                    Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
                });
            }

            var authResponse = await _identityService.LoginAsync(request.Email, request.Password);

            if (!authResponse.Success)
            {
                    return Ok(new AuthFailedResponse
                    {
                        Status = false,
                        Errors = authResponse.Errors
                    });
                    
            }

            return Ok(new AuthSuccessResponse
            {
                Status = true,
                Token = authResponse.Token,
            });
            }
            catch (Exception ex)
            {

                return BadRequest(new AuthFailedResponse
                {
                    Status = true,
                    Errors = CommonUtility.CreateEnumerable(ex.Message)
                });
            }

        }

        [Authorize]
        [HttpPost(ApiRoutes.Identity.User)]
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