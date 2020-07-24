using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Services;
using EduquayAPI.Services.MobileMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EduquayAPI.Contracts.V1.Response.MobileMster;
using EduquayAPI.Models.LoadMasters;
using EduquayAPI.Contracts.V1.Request.Mobile;

namespace EduquayAPI.Controllers
{
    [Authorize]
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MobileMasterController : ControllerBase
    {
        private readonly IMobileMasterService _mobileMasterService;
        private readonly ILogger<MobileMasterController> _logger;

        public MobileMasterController(IMobileMasterService mobileMasterService, ILogger<MobileMasterController> logger)
        {
            _mobileMasterService = mobileMasterService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Retrieve")]
        public async Task<IActionResult> GetMasters(MobileRetrieveRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var mmResponse = await _mobileMasterService.RetrieveMasters(mrData);


            if (!mmResponse.Valid)
            {
                return Unauthorized(new MobileMasterResponse
                {
                    Status = "false",
                    Message = mmResponse.Message
                });
            }
            return Ok(new MobileMasterResponse
            {
                Valid = true,
                Status = "true",
                Message = mmResponse.Message,
                States = mmResponse.States,
                Districts = mmResponse.Districts,
                CHC = mmResponse.CHC,
                PHC = mmResponse.PHC,
                SC = mmResponse.SC,
                RI = mmResponse.RI,
                GovIdType = mmResponse.GovIdType,
                Religion = mmResponse.Religion,
                Caste = mmResponse.Caste,
                Community = mmResponse.Community,
                ConstantValues = mmResponse.ConstantValues
            });
        }

        [HttpGet]
        [Route("RetrieveCommunity/{code}")]
        public CommunityMasterResponse GetCommunity(int code)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var community = _mobileMasterService.RetrieveCommunity(code);

                _logger.LogInformation($"Received community master data {community}");
                return community.Count == 0 ?
                    new CommunityMasterResponse { Status = "true", Message = "No record found", Community = new List<LoadCommunity>() }
                    : new CommunityMasterResponse { Status = "true", Message = string.Empty, Community = community };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving community data {e.StackTrace}");
                return new CommunityMasterResponse { Status = "false", Message = e.Message, Community = null };
            }
        }


    }
}