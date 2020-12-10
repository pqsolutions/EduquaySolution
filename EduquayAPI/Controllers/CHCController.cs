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
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CHCController : ControllerBase
    {
        private readonly ICHCService _chcService;
        public CHCController(ICHCService chcService)
        {
            _chcService = chcService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddCHC(CHCRequest cData)
        {
            var addEditResponse = await _chcService.Add(cData);
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
            try
            {
                var chcs = _chcService.Retrieve();
                return chcs.Count == 0 ? new CHCResponse { Status = "true", Message = "No CHC found", CHCDetails = new List<CHC>() } : new CHCResponse { Status = "true", Message = string.Empty, CHCDetails = chcs };
            }
            catch (Exception e)
            {
                return new CHCResponse { Status = "false", Message = e.Message, CHCDetails = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public CHCResponse GetCHC(int code)
        {
            try
            {
                var chcs = _chcService.Retrieve(code);
                return chcs.Count == 0 ? new CHCResponse { Status = "true", Message = "No CHC found", CHCDetails = new List<CHC>() } : new CHCResponse { Status = "true", Message = string.Empty, CHCDetails = chcs };
            }
            catch (Exception e)
            {
                return new CHCResponse { Status = "false", Message = e.Message, CHCDetails = null };
            }
        }


    }
}