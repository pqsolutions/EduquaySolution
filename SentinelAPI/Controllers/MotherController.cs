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
using SentinelAPI.Services.Mother;

namespace SentinelAPI.Controllers
{
    [Authorize]
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
        public ActionResult<string> AddMotherDetail(AddMotherRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Register Mother Detail - {JsonConvert.SerializeObject(mrData)}");
            try
            {
                _logger.LogInformation($"Mother detail registered Successfully - {mrData}");
                var mother = _motherService.AddMotherDetail(mrData);
                return string.IsNullOrEmpty(mother) ? $"Unable to add mother detail " : mother;
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to register  motherdetail  - {e.StackTrace}");
                return $"Unable to add mother detail - {e.Message}";
            }
        }


    }
}