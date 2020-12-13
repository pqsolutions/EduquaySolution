using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EduquayAPI.Contracts.V1.Response.Masters;
using Microsoft.AspNetCore.Http.Extensions;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlockController : ControllerBase
    {
        private readonly IBlockService _blockService;
        private readonly ILogger<BlockController> _logger;
        public BlockController(IBlockService blockService,ILogger<BlockController> logger)
        {
            _blockService = blockService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddBlock(BlockRequest bData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding sample recollection data - {JsonConvert.SerializeObject(bData)}");
            var addEditResponse = await _blockService.AddBlock(bData);
            _logger.LogInformation($" Add Block {addEditResponse}");

            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
           
        }

        [HttpGet]
        [Route("Retrieve")]
        public BlockResponse GetBlocks()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var blocks = _blockService.Retrieve();
                _logger.LogInformation($" retirve Blocks {blocks}");
                return blocks.Count == 0 ? new BlockResponse { Status = "true", Message = "No blocks found", Blocks = new List<Block>() } : new BlockResponse { Status = "true", Message = string.Empty, Blocks = blocks };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve block  - {e.StackTrace}");
                return new BlockResponse { Status = "false", Message = e.Message, Blocks = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public BlockResponse GetBlock(int code)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding sample recollection data - {JsonConvert.SerializeObject(code)}");

            try
            {
                var blocks = _blockService.Retrieve(code);
                _logger.LogInformation($" retirve Blocks {blocks}");
                return blocks .Count == 0 ? new BlockResponse { Status = "true", Message = "No block found", Blocks = new List<Block>() } : new BlockResponse { Status = "true", Message = string.Empty, Blocks = blocks };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve block  - {e.StackTrace}");
                return new BlockResponse { Status = "false", Message = e.Message, Blocks = null };
            }
        }

    }
}