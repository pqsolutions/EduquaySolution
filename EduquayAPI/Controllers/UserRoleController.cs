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
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(IUserRoleService userRoleService)
        {
            _userRoleService = userRoleService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddUserRole(UserRoleRequest urdata)
        {
            var userrole = _userRoleService.Add(urdata);
            if (userrole == null)
            {
                return NotFound();
            }
            return userrole;
        }

        [HttpGet]
        [Route("Retreive")]
        public UserRoleResponse GetUserRoles()
        {
            try
            {
                var userroles = _userRoleService.Retreive();
                return userroles.Count == 0 ? new UserRoleResponse { Status = "true", Message = "No user type found", UserRoles = new List<UserRole>() } : new UserRoleResponse { Status = "true", Message = string.Empty, UserRoles = userroles };
            }
            catch (Exception e)
            {
                return new UserRoleResponse { Status = "false", Message = e.Message, UserRoles = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public UserRoleResponse GetUserType(int code)
        {
            try
            {
                var userroles = _userRoleService.Retreive(code);
                return userroles.Count == 0 ? new UserRoleResponse { Status = "true", Message = "No user type found", UserRoles = new List<UserRole>() } : new UserRoleResponse { Status = "true", Message = string.Empty, UserRoles = userroles };
            }
            catch (Exception e)
            {
                return new UserRoleResponse { Status = "false", Message = e.Message, UserRoles = null };
            }
        }

    }
}