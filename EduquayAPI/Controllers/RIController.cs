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
    public class RIController : ControllerBase
    {
        private readonly IRIService _riService;
        public RIController(IRIService riService)
        {
            _riService = riService;
        }


        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddRI(RIRequest rData)
        {
            var addEditResponse = await _riService.Add(rData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }

        [HttpGet]
        [Route("Retrieve")]
        public RIResponse GetRIs()
        {
            try
            {
                var ris = _riService.Retrieve();
                return ris.Count == 0 ? new RIResponse { Status = "true", Message = "No RI found",RIDetails = new List<RI>() } : new RIResponse { Status = "true", Message = string.Empty, RIDetails = ris };
            }
            catch (Exception e)
            {
                return new RIResponse { Status = "false", Message = e.Message, RIDetails = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public RIResponse GetRI(int code)
        {
            try
            {
                var ris = _riService.Retrieve(code);
                return ris.Count == 0 ? new RIResponse { Status = "true", Message = "No RI found", RIDetails = new List<RI>() } : new RIResponse { Status = "true", Message = string.Empty, RIDetails = ris };
            }
            catch (Exception e)
            {
                return new RIResponse { Status = "false", Message = e.Message, RIDetails = null };
            }
        }

    }
}