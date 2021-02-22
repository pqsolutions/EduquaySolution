using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Response.Hematologist;
using EduquayAPI.Services.Hematologist;
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
    public class HematologistController : ControllerBase
    {
        private readonly IHematologistService _hematologistService;
        private readonly ILogger<HematologistController> _logger;
        public HematologistController(IHematologistService hematologistService, ILogger<HematologistController> logger)
        {
            _hematologistService = hematologistService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get ANW Details with Specimen Molecular Test Result Details 
        [HttpPost]
        [Route("RetrieveSpecimenMolecularResults/{molecularId}")]
        public async Task<IActionResult> GetSpecimenMolecularDetails(int molecularId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(molecularId)}");
            var testDetailResponse = await _hematologistService.RetrieveCompletedMolecularDetail(molecularId);
            _logger.LogInformation($"get ANW Details with Specimen Molecular Test Result Details {testDetailResponse}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(testDetailResponse)}");
            
            return Ok(new CompletedMolecularTestResponse
            {
                Status = testDetailResponse.Status,
                Message = testDetailResponse.Message,
                data = testDetailResponse.data,
            });
        }
    }
}
