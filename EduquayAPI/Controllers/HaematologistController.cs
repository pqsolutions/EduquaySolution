using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Haematologist;
using EduquayAPI.Contracts.V1.Response.Haematologist;
using EduquayAPI.Services.Haematologist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class HaematologistController : ControllerBase
    {
        private readonly IHaematologistService _haematologistService;
        private readonly ILogger<HaematologistController> _logger;
        public HaematologistController(IHaematologistService haematologistService, ILogger<HaematologistController> logger)
        {
            _haematologistService = haematologistService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get ANW Details with Specimen Molecular Test Result Details 
        [HttpGet]
        [Route("RetrieveSpecimenMolecularResults/{molecularId}")]
        public async Task<IActionResult> GetSpecimenMolecularDetails(int molecularId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(molecularId)}");
            var testDetailResponse = await _haematologistService.RetrieveCompletedMolecularDetail(molecularId);
            _logger.LogInformation($"get ANW Details with Specimen Molecular Test Result Details {testDetailResponse}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(testDetailResponse)}");
            
            return Ok(new CompletedMolecularTestResponse
            {
                Status = testDetailResponse.Status,
                Message = testDetailResponse.Message,
                data = testDetailResponse.data,
            });
        }


        /// <summary>
        /// Used for update the pregnancy continue detail by haematologist
        [HttpPost]
        [Route("UpdatePregnancyDecision")]
        public async Task<IActionResult> AddPregnancyDecision(AddPregnancyDecisionRequest prData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Update Pregnancy decision by haematologist - {JsonConvert.SerializeObject(prData)}");
            var rResponse = await _haematologistService.AddDecision(prData);

            return Ok(new ReviewResultResponse
            {
                Status = rResponse.Status,
                Message = rResponse.Message,
                data = rResponse.data
            });
        }
    }
}
