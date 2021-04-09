using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Contracts.V1.Response.AdminSupport;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models.AdminiSupport;
using EduquayAPI.Services.SA;
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
    public class SAController : ControllerBase
    {
        private readonly ISAService _saService;
        private readonly ILogger<SAController> _logger;
        public SAController(ISAService saService, ILogger<SAController> logger)
        {
            _saService = saService;
            _logger = logger;
        }

        /// <summary>
        /// Used for retrieve  all States 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllStates")]
        public SAStateResponse GetStates()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllStates();
                _logger.LogInformation($"Received states {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAStateResponse { Status = "true", Message = "No states found", data = new List<StateDetails>() } 
                : new SAStateResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve states {e.StackTrace}");
                return new SAStateResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve  State by Id
        /// </summary>
        [HttpGet]
        [Route("RetrieveStateById/{id}")]
        public SAStateResponse GetState(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request for get state - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _saService.RetrieveStateById(id);
                _logger.LogInformation($"Received state by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SAStateResponse { Status = "true", Message = "No states found", data = new List<StateDetails>() }
                : new SAStateResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  state by Id {e.StackTrace}");
                return new SAStateResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for Add new state
        /// </summary>
        [HttpPost]
        [Route("AddNewState")]
        public async Task<IActionResult> AddNewState(AddStateRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddStateDetail(sData);
            _logger.LogInformation($"Response - Add New State {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse 
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update  state
        /// </summary>
        [HttpPost]
        [Route("UpdateState")]
        public async Task<IActionResult> UpdateState(UpdateStateRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateStatedetail(sData);
            _logger.LogInformation($"Response - update State {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all districts 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllDistricts")]
        public SADistrictResponse GetDistricts()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllDistricts();
                _logger.LogInformation($"Received Districts {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SADistrictResponse { Status = "true", Message = "No states found", data = new List<DistrictDetail>() }
                : new SADistrictResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve district {e.StackTrace}");
                return new SADistrictResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve  district by Id
        /// </summary>
        [HttpGet]
        [Route("RetrieveDistrictById/{id}")]
        public SADistrictResponse GetDistrict(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request for get district - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _saService.RetrieveDistrictById(id);
                _logger.LogInformation($"Received district by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SADistrictResponse { Status = "true", Message = "No states found", data = new List<DistrictDetail>() }
                : new SADistrictResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  district by Id {e.StackTrace}");
                return new SADistrictResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new district
        /// </summary>
        [HttpPost]
        [Route("AddNewSDistrict")]
        public async Task<IActionResult> AddNewDistrict(AddDistrictRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddDistrictDetail(sData);
            _logger.LogInformation($"Response - Add New District {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update  district
        /// </summary>
        [HttpPost]
        [Route("UpdateDistrict")]
        public async Task<IActionResult> UpdateDistrict(UpdateDistrictRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateDistrictDetail(sData);
            _logger.LogInformation($"Response - update district {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }
    }
}
