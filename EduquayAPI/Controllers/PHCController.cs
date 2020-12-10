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
    public class PHCController : ControllerBase
    {
        private readonly IPHCService _phcService;
        public PHCController(IPHCService phcService)
        {
            _phcService = phcService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddPHC(PHCRequest pData)
        {
            var addEditResponse = await _phcService.Add(pData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }

        [HttpGet]
        [Route("Retrieve")]
        public PHCResponse GetPHCs()
        {
            try
            {
                var phcs = _phcService.Retrieve();
                return phcs.Count == 0 ? new PHCResponse { Status = "true", Message = "No PHC found", PHCDetails = new List<PHC>() } : new PHCResponse { Status = "true", Message = string.Empty, PHCDetails = phcs };
            }
            catch (Exception e)
            {
                return new PHCResponse { Status = "false", Message = e.Message,PHCDetails = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public PHCResponse GetPHC(int code)
        {
            try
            {
                var phcs = _phcService.Retrieve(code);
                return phcs.Count == 0 ? new PHCResponse { Status = "true", Message = "No PHC found", PHCDetails = new List<PHC>() } : new PHCResponse { Status = "true", Message = string.Empty, PHCDetails = phcs };
            }
            catch (Exception e)
            {
                return new PHCResponse { Status = "false", Message = e.Message, PHCDetails = null };
            }
        }


    }
}