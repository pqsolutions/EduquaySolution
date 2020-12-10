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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EduquayAPI.Contracts.V1.Response.Masters;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CommunityController : ControllerBase
    {
        private readonly ICommunityService _communityService;
        public CommunityController(ICommunityService communityService)
        {
            _communityService = communityService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(CommunityRequest cData)
        {
            var addEditResponse = await _communityService.Add(cData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }

        [HttpGet]
        [Route("Retrieve")]
        public CommunityResponse GetCommunities()
        {
            try
            {
                var communities = _communityService.Retrieve();
                return communities.Count == 0 ? new CommunityResponse { Status = "true", Message = "No community found", Communitiy = new List<Community>() } : new CommunityResponse { Status = "true", Message = string.Empty, Communitiy = communities };
            }
            catch (Exception e)
            {
                return new CommunityResponse { Status = "false", Message = e.Message, Communitiy = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public CommunityResponse GetCommunity(int code)
        {
            try
            {
                var communities = _communityService.Retrieve(code);
                return communities.Count == 0 ? new CommunityResponse { Status = "true", Message = "No community found", Communitiy = new List<Community>() } : new CommunityResponse { Status = "true", Message = string.Empty, Communitiy = communities };
            }
            catch (Exception e)
            {
                return new CommunityResponse { Status = "false", Message = e.Message, Communitiy = null };
            }
        }

    }
}