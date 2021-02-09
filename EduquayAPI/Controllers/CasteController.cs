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
    public class CasteController : ControllerBase
    {
        private readonly ICasteService _casteService;
        private readonly ILogger<CasteController> _logger;

        public CasteController(ICasteService casteService, ILogger<CasteController> logger)
        {
            _casteService = casteService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(CasteRequest cData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Adding caste data - {JsonConvert.SerializeObject(cData)}");
            var addEditResponse = await _casteService.Add(cData);
            _logger.LogInformation($" Add Caste {addEditResponse}");
            _logger.LogDebug($"Response - Adding caste data - {JsonConvert.SerializeObject(addEditResponse)}");
            return Ok(new AddEditResponse 
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
           
        }

        [HttpGet]
        [Route("Retrieve")]
        public CasteResponse GeCastes()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var castes = _casteService.Retrieve();
                _logger.LogInformation($" retierve caste {castes}");
                _logger.LogDebug($"Response - retierve Caste {JsonConvert.SerializeObject(castes)}");
                return castes.Count == 0 ? new CasteResponse { Status = "true", Message = "No caste found", Caste = new List<Caste>() } 
                : new CasteResponse { Status = "true", Message = string.Empty, Caste = castes };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve caste  - {e.StackTrace}");
                return new CasteResponse { Status = "false", Message = e.Message, Caste = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public CasteResponse GetCaste(int code)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Resuest - retierve caste  {JsonConvert.SerializeObject(code)}");
            try
            {
                var castes = _casteService.Retrieve(code);
                _logger.LogInformation($" retierve caste {castes}");
                _logger.LogDebug($"Response - retierve caste {JsonConvert.SerializeObject(castes)}");
                return castes.Count == 0 ? new CasteResponse { Status = "true", Message = "No caste found", Caste = new List<Caste>() } 
                : new CasteResponse { Status = "true", Message = string.Empty, Caste = castes };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve caste  - {e.StackTrace}");
                return new CasteResponse { Status = "false", Message = e.Message, Caste = null };
            }
        }
    }
}