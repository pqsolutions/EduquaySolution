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
    public class ReligionController : ControllerBase
    {
        private readonly IReligionService _religionService;

        public ReligionController(IReligionService religionService)
        {
            _religionService = religionService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(ReligionRequest rData)
        {
            var addEditResponse = await _religionService.Add(rData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });

        }

        [HttpGet]
        [Route("Retrieve")]
        public ReligionResponse  GetReligions()
        {
            try
            {
                var religions = _religionService.Retrieve();
                return religions.Count == 0 ? new ReligionResponse { Status = "true", Message = "No religion found", Religion = new List<Religion>() } : new ReligionResponse { Status = "true", Message = string.Empty, Religion = religions };
            }
            catch (Exception e)
            {
                return new ReligionResponse { Status = "false", Message = e.Message, Religion = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public ReligionResponse GetReligion(int code)
        {
            try
            {
                var religions = _religionService.Retrieve(code);
                return religions.Count == 0 ? new ReligionResponse { Status = "true", Message = "No religion found", Religion = new List<Religion>() } : new ReligionResponse { Status = "true", Message = string.Empty, Religion = religions };
            }
            catch (Exception e)
            {
                return new ReligionResponse { Status = "false", Message = e.Message, Religion = null };
            }
        }
    }
}