using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
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
        public ActionResult<string> AddUserRole(UserRoleRequest urData)
        {
            try
            { 
            
                var userRole = _userRoleService.Add(urData);
                return string.IsNullOrEmpty(userRole) ? $"Unable to add user role data" : userRole;
            }
            catch (Exception e)
            {
                return $"Unable to add user role data - {e.Message}";
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public UserRoleResponse GetUserRoles()
        {
            try
            {
                var userRoles = _userRoleService.Retrieve();
                return userRoles.Count == 0 ? new UserRoleResponse { Status = "true", Message = "No user role data found", UserRoles = new List<UserRole>() } : new UserRoleResponse { Status = "true", Message = string.Empty, UserRoles = userRoles };
            }
            catch (Exception e)
            {
                return new UserRoleResponse { Status = "false", Message = e.Message, UserRoles = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public UserRoleResponse GetUserType(int code)
        {
            try
            {
                var userRoles = _userRoleService.Retrieve(code);
                return userRoles.Count == 0 ? new UserRoleResponse { Status = "true", Message = "No user role data found", UserRoles = new List<UserRole>() } : new UserRoleResponse { Status = "true", Message = string.Empty, UserRoles = userRoles };
            }
            catch (Exception e)
            {
                return new UserRoleResponse { Status = "false", Message = e.Message, UserRoles = null };
            }
        }

    }
}