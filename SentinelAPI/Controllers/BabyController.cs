using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SentinelAPI.Contracts.V1.Request.Baby;
using SentinelAPI.Contracts.V1.Response.Baby;
using SentinelAPI.Services.Baby;

namespace SentinelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BabyController : ControllerBase
    {

        private readonly IBabyService _babyService;
        private readonly ILogger<BabyController> _logger;

        public BabyController(IBabyService babyService, ILogger<BabyController> logger)
        {
            _babyService = babyService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddBabyDetail")]
        public async Task<IActionResult> AddBabyDetail(AddBabyRequest brData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding infant detail - {JsonConvert.SerializeObject(brData)}");
            var babyResponse = await _babyService.AddBabyDetail(brData);
            return Ok(new AddBabyResponse
            {
                Status = babyResponse.Status,
                Message = babyResponse.Message,
                BabySubjectId = babyResponse.BabySubjectId,
            });
        }
    }
}