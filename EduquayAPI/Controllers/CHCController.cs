using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CHCController : ControllerBase
    {
        private readonly ICHCService _chcService;
        private readonly ILogger<CHCController> _logger;
        public CHCController(ICHCService chcService, ILogger<CHCController> logger)
        {
            _chcService = chcService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCHC(CHCRequest cData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Adding chc data - {JsonConvert.SerializeObject(cData)}");
            var addEditResponse = await _chcService.Add(cData);
            _logger.LogInformation($" Add CHC {addEditResponse}");
            _logger.LogDebug($"Response - Adding chc data - {JsonConvert.SerializeObject(addEditResponse)}");
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }

        [HttpGet]
        [Route("Retrieve")]
        public CHCResponse GetCHCs()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var chcs = _chcService.Retrieve();
                _logger.LogInformation($" retierve chc {chcs}");
                _logger.LogDebug($"Response - retierve chc {JsonConvert.SerializeObject(chcs)}");
                return chcs.Count == 0 ? new CHCResponse { Status = "true", Message = "No CHC found", CHCDetails = new List<CHC>() } 
                : new CHCResponse { Status = "true", Message = string.Empty, CHCDetails = chcs };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve chc  - {e.StackTrace}");
                return new CHCResponse { Status = "false", Message = e.Message, CHCDetails = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public CHCResponse GetCHC(int code)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Resuest - retierve chc  {JsonConvert.SerializeObject(code)}");
            try
            {
                var chcs = _chcService.Retrieve(code);
                _logger.LogInformation($" retierve chc {chcs}");
                _logger.LogDebug($"Response - retierve chc {JsonConvert.SerializeObject(chcs)}");
                return chcs.Count == 0 ? new CHCResponse { Status = "true", Message = "No CHC found", CHCDetails = new List<CHC>() } 
                : new CHCResponse { Status = "true", Message = string.Empty, CHCDetails = chcs };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve chc  - {e.StackTrace}");
                return new CHCResponse { Status = "false", Message = e.Message, CHCDetails = null };
            }
        }


    }
}