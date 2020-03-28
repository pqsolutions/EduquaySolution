using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
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
        public ActionResult<string> AddUserType(UserTypeRequest utdata)
        {
            var usertype = _userTypeService.Add(utdata);
            if (usertype == null)
            {
                return NotFound();
            }
            return usertype;
        }


        [HttpGet]
        [Route("Retreive")]
        public UserTypeResponse GetUserTypes()
        {
            try
            {
                var usertypes = _userTypeService.Retreive();
                return usertypes.Count == 0 ? new UserTypeResponse { Status = "true", Message = "No user type found", UserTypes = new List<UserType>() } : new UserTypeResponse { Status = "true", Message = string.Empty, UserTypes = usertypes };
            }
            catch (Exception e)
            {
                return new UserTypeResponse { Status = "false", Message = e.Message, UserTypes = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public UserTypeResponse GetUserType(int code)
        {
            try
            {
                var usertypes = _userTypeService.Retreive(code);
                return usertypes.Count == 0 ? new UserTypeResponse { Status = "true", Message = "No user type found", UserTypes = new List<UserType>() } : new UserTypeResponse { Status = "true", Message = string.Empty, UserTypes = usertypes };
            }
            catch (Exception e)
            {
                return new UserTypeResponse { Status = "false", Message = e.Message, UserTypes = null };
            }
        }

    }
}