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
        [Route("AddNewDistrict")]
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

        /// <summary>
        /// Used for retrieve  all blocks 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllBlocks")]
        public SABlockResponse GetBlocks()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllBlocks();
                _logger.LogInformation($"Received Blocks {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SABlockResponse { Status = "true", Message = "No block found", data = new List<BlockDetail>() }
                : new SABlockResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve block {e.StackTrace}");
                return new SABlockResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve block by id 
        /// </summary>
        [HttpGet]
        [Route("RetrieveBlockById/{id}")]
        public SABlockResponse GetBlock(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveBlockById(id);
                _logger.LogInformation($"Received block by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SABlockResponse { Status = "true", Message = "No block found", data = new List<BlockDetail>() }
                : new SABlockResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve block by id {e.StackTrace}");
                return new SABlockResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new block
        /// </summary>
        [HttpPost]
        [Route("AddNewBlock")]
        public async Task<IActionResult> AddNewBlock(AddBlockRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddBlockDetail(sData);
            _logger.LogInformation($"Response - Add New Block {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update  vlock
        /// </summary>
        [HttpPost]
        [Route("UpdateBlock")]
        public async Task<IActionResult> UpdateBlock(UpdateBlockRequest uData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(uData)}");
            var data = await _saService.UpdateBlockDetail(uData);
            _logger.LogInformation($"Response - update block {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for retrieve  all chcs 
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllCHCs")]
        public SACHCResponse GetCHCs()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveAllCHCs();
                _logger.LogInformation($"Received all CHC {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SACHCResponse { Status = "true", Message = "No chc found", data = new List<CHCDetail>() }
                : new SACHCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve chc {e.StackTrace}");
                return new SACHCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for retrieve chc by id 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCHCById/{id}")]
        public SACHCResponse GetCHC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _saService.RetrieveCHCById(id);
                _logger.LogInformation($"Received chc by Id {data}");
                _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
                return data.Count == 0 ? new SACHCResponse { Status = "true", Message = "No chc found", data = new List<CHCDetail>() }
                : new SACHCResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  retrieve chc by id {e.StackTrace}");
                return new SACHCResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add new chc
        /// </summary>
        [HttpPost]
        [Route("AddNewCHC")]
        public async Task<IActionResult> AddNewCHC(AddCHCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.AddCHCDetail(sData);
            _logger.LogInformation($"Response - Add New CHC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

        /// <summary>
        /// Used for update chc
        /// </summary>
        [HttpPost]
        [Route("UpdateCHC")]
        public async Task<IActionResult> UpdateCHC(UpdateCHCRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(sData)}");

            var data = await _saService.UpdateCHCDetail(sData);
            _logger.LogInformation($"Response - Update CHC {data}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(data)}");
            return Ok(new AddEditResponse
            {
                Status = data.Status,
                Message = data.Message,
            });
        }

    }
}
