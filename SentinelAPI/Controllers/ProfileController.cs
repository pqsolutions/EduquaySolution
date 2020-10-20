using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Request.Profile;
using SentinelAPI.Contracts.V1.Response.Baby;
using SentinelAPI.Contracts.V1.Response.Mother;
using SentinelAPI.Contracts.V1.Response.Profile;
using SentinelAPI.Models.Profile;
using SentinelAPI.Services.Profile;

namespace SentinelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService _profileService;
        private readonly ILogger<ProfileController> _logger;
        public ProfileController(IProfileService profileService, ILogger<ProfileController> logger)
        {
            _profileService = profileService;
            _logger = logger;
        }

        [HttpPost]
        [Route("RetrieveParticularMotherProfile")]
        public async Task<IActionResult> GetMotherDetail(FetchMotherRequest fmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve mother detail with baby detail - {JsonConvert.SerializeObject(fmData)}");
            var motherResponse = await _profileService.RetrieveMother(fmData);
            return Ok(new MotherProfileResponse
            {
                Status = motherResponse.Status,
                Message = motherResponse.Message,
                data = motherResponse.data,
            });
        }

        [HttpPost]
        [Route("RetrieveAllMotherProfile")]
        public async Task<IActionResult> GetAllMotherDetail(FetchAllMotherRequest fmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve mother detail with baby detail - {JsonConvert.SerializeObject(fmData)}");
            var motherResponse = await _profileService.RetrieveAllMother(fmData);
            return Ok(new MotherProfileResponse
            {
                Status = motherResponse.Status,
                Message = motherResponse.Message,
                data = motherResponse.data,
            });
        }

        [HttpPost]
        [Route("UpdateMotherProfile")]
        public async Task<IActionResult> UpdateMotherDetail(MotherUpdateRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating mother detail - {JsonConvert.SerializeObject(mrData)}");
            var motherResponse = await _profileService.UpdateMother(mrData);
            return Ok(new AddMotherResponse
            {
                Status = motherResponse.Status,
                Message = motherResponse.Message,
                MotherSubjectId = motherResponse.MotherSubjectId,
            });
        }

        [HttpPost]
        [Route("RetrieveParticularBabiesProfile")]
        public BabyProfileResponse GetBabyProfile(FetchBabiesRequest fmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var babies = _profileService.RetrieveBabies(fmData);

                _logger.LogInformation($"Received babies profile data {babies}");
                return babies.Count == 0 ?
                    new BabyProfileResponse { Status = "true", Message = "No record found", data = new List<BabyProfile>() }
                    : new BabyProfileResponse { Status = "true", Message = string.Empty, data = babies };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in babies profile data {e.StackTrace}");
                return new BabyProfileResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpPost]
        [Route("RetrieveAllBabiesProfile")]
        public BabyProfileResponse GetAllBabyProfile(FetchAllMotherRequest fmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var babies = _profileService.RetrieveAllBabies(fmData);

                _logger.LogInformation($"Received babies profile data {babies}");
                return babies.Count == 0 ?
                    new BabyProfileResponse { Status = "true", Message = "No record found", data = new List<BabyProfile>() }
                    : new BabyProfileResponse { Status = "true", Message = string.Empty, data = babies };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in babies profile data {e.StackTrace}");
                return new BabyProfileResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpPost]
        [Route("UpdateBabyProfile")]
        public async Task<IActionResult> UpdateBabyrDetail(UpdateBabyRequest brData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating baby detail - {JsonConvert.SerializeObject(brData)}");
            var motherResponse = await _profileService.UpdateBaby(brData);
            return Ok(new AddBabyResponse
            {
                Status = motherResponse.Status,
                Message = motherResponse.Message,
                BabySubjectId = motherResponse.BabySubjectId,
            });
        }

    }
}