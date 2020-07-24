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
        [Route("Add")]
        public async Task<IActionResult> AddMotherDetail(AddMotherRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding Mother Detail - {JsonConvert.SerializeObject(mrData)}");
            var motherResponse = await _motherService.AddMotherDetail(mrData);
            return Ok(new AddMotherResponse
            {
                Status = motherResponse.Status,
                Message = motherResponse.Message,
                MotherSubjectId = motherResponse.MotherSubjectId,
            });
        }
    }
}