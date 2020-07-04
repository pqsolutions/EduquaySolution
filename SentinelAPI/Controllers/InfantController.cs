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
        public ActionResult<string> AddInfantDetail(AddInfantRequest irData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Register Infant Detail - {JsonConvert.SerializeObject(irData)}");
            try
            {
                _logger.LogInformation($"Infant detail registered Successfully - {irData}");
                var infant = _infantService.AddInfantDetail(irData);
                return string.IsNullOrEmpty(infant) ? $"Unable to add infant detail " : infant;
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to register infant detail  - {e.StackTrace}");
                return $"Unable to add infant detail - {e.Message}";
            }
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