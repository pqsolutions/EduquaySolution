using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Response.Mother;
using SentinelAPI.Models.Mother;
using SentinelAPI.Services.Mother;

namespace SentinelAPI.Controllers
{
   // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MotherController : ControllerBase
    {
        private readonly IMotherService _motherService;
        private readonly ILogger<MotherController> _logger;

        public MotherController(IMotherService motherService, ILogger<MotherController> logger)
        {
            _motherService = motherService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddMotherDetail")]
        public async Task<IActionResult> AddMotherDetail(AddMotherRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding mother detail - {JsonConvert.SerializeObject(mrData)}");
            var motherResponse = await _motherService.AddMotherDetail(mrData);
            return Ok(new AddMotherResponse
            {
                Status = motherResponse.Status,
                Message = motherResponse.Message,
                MotherSubjectId = motherResponse.MotherSubjectId,
            });
        }

        [HttpPost]
        [Route("RetrieveMotherDetail")]
        public async Task<IActionResult> GetMotherDetail(FetchMotherRequest fmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve mother detail with baby detail - {JsonConvert.SerializeObject(fmData)}");
            var motherResponse = await _motherService.RetrieveMother(fmData);
            return Ok(new FetchMotherResponse
            {
                Status = motherResponse.Status,
                Message = motherResponse.Message,
                data = motherResponse.data,
            });
        }
    }
}