using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Services.ANMCHCPickandPack;
using EduquayAPI.Contracts.V1.Response.ANMCHCPickandPack;
using EduquayAPI.Models.ANMCHCPickandPack;
using EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class ANMCHCPickandPackController : ControllerBase
    {
        private readonly IANMCHCPickandPackService _anmchcPickandPackService;
        private readonly ILogger<ANMCHCPickandPackController> _logger;
        public ANMCHCPickandPackController(IANMCHCPickandPackService anmchcPickandPackService, ILogger<ANMCHCPickandPackController> logger)
        {
            _anmchcPickandPackService = anmchcPickandPackService;
            _logger = logger;
        }

         /// <summary>
        /// Used for get sample collection which are not generated the Shipment Id of particular ANM user / CHC
        /// </summary>
        [HttpPost]
        [Route("Retrieve")]
        public async Task<IActionResult> GetSampleList(ANMCHCPickandPackRequest acppData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request- {JsonConvert.SerializeObject(acppData)}");
            var sampleList = await _anmchcPickandPackService.Retrieve(acppData);
            _logger.LogInformation($"Received sample Data {sampleList}");
            _logger.LogDebug($"Response- {JsonConvert.SerializeObject(sampleList)}");
            return Ok(new ANMCHCPickandPackResponse
            {
                Status = sampleList.Status,
                Message = sampleList.Message,
                SampleList = sampleList.SampleList,
            });
        }
    }
}