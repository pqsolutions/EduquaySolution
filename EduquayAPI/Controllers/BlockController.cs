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

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
   // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class BlockController : ControllerBase
    {
        private readonly IBlockService _blockService;
        public BlockController(IBlockService blockService)
        {
            _blockService = blockService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddBlock(BlockRequest bData)
        {
            var addEditResponse = await _blockService.AddBlock(bData);
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
            try
            {
                var blocks = _blockService.Retrieve();
                return blocks.Count == 0 ? new BlockResponse { Status = "true", Message = "No blocks found", Blocks = new List<Block>() } : new BlockResponse { Status = "true", Message = string.Empty, Blocks = blocks };
            }
            catch (Exception e)
            {
                return new BlockResponse { Status = "false", Message = e.Message, Blocks = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public BlockResponse GetBlock(int code)
        {
            try
            {
                var blocks = _blockService.Retrieve(code);
                return blocks .Count == 0 ? new BlockResponse { Status = "true", Message = "No block found", Blocks = new List<Block>() } : new BlockResponse { Status = "true", Message = string.Empty, Blocks = blocks };
            }
            catch (Exception e)
            {
                return new BlockResponse { Status = "false", Message = e.Message, Blocks = null };
            }
        }

    }
}