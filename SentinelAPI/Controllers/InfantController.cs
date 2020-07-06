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
using SentinelAPI.Contracts.V1.Request.Infant;
using SentinelAPI.Contracts.V1.Response.Infant;
using SentinelAPI.Services.Infant;

namespace SentinelAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InfantController : ControllerBase
    {

        private readonly IInfantService _infantService;
        private readonly ILogger<InfantController> _logger;

        public InfantController(IInfantService infantService, ILogger<InfantController> logger)
        {
            _infantService = infantService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddInfantDetail(AddInfantRequest irData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding infant detail - {JsonConvert.SerializeObject(irData)}");
            var infantResponse = await _infantService.AddInfantDetail(irData);
            return Ok(new AddInfantResponse
            {
                Status = infantResponse.Status,
                Message = infantResponse.Message,
                InfantSubjectId = infantResponse.InfantSubjectId,
            });
        }

        [HttpPost]
        [Route("RetrieveMother")]
        public async Task<IActionResult> GetMother(GetMotherRequest mData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var momResponse = await _infantService.RetrieveMother(mData);

            return Ok(new InfantMotherResponse
            {
                Status = momResponse.Status,
                Message = momResponse.Message,
                MotherDetail = momResponse.MotherDetail,
            });
        }
    }
}