using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UserTypeController : ControllerBase
    {
        private readonly IUserTypeService _userTypeService;

        public UserTypeController(IUserTypeService userTypeService)
        {
            _userTypeService = userTypeService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddUserType(UserTypeRequest utData)
        {
            var addEditResponse = await _userTypeService.Add(utData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }


        [HttpGet]
        [Route("Retrieve")]
        public UserTypeResponse GetUserTypes()
        {
            try
            {
                var userTypes = _userTypeService.Retrieve();
                return userTypes.Count == 0 ? new UserTypeResponse { Status = "true", Message = "No user type data found", UserTypes = new List<UserType>() } : new UserTypeResponse { Status = "true", Message = string.Empty, UserTypes = userTypes };
            }
            catch (Exception e)
            {
                return new UserTypeResponse { Status = "false", Message = e.Message, UserTypes = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public UserTypeResponse GetUserType(int code)
        {
            try
            {
                var userTypes = _userTypeService.Retrieve(code);
                return userTypes.Count == 0 ? new UserTypeResponse { Status = "true", Message = "No user type data found", UserTypes = new List<UserType>() } : new UserTypeResponse { Status = "true", Message = string.Empty, UserTypes = userTypes };
            }
            catch (Exception e)
            {
                return new UserTypeResponse { Status = "false", Message = e.Message, UserTypes = null };
            }
        }

    }
}