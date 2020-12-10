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
    public class SCController : ControllerBase
    {

        private readonly ISCService _scService;
        public SCController(ISCService scService)
        {
            _scService = scService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddSC(SCRequest sData)
        {
            var addEditResponse = await _scService.Add(sData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
           
        }

        [HttpGet]
        [Route("Retrieve")]
        public SCResponse GetSCs()
        {
            try
            {
                var scs = _scService.Retrieve();
                return scs.Count == 0 ? new SCResponse { Status = "true", Message = "No SC found", SCDetails = new List<SC>() } : new SCResponse { Status = "true", Message = string.Empty, SCDetails = scs };
            }
            catch (Exception e)
            {
                return new SCResponse { Status = "false", Message = e.Message, SCDetails = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public SCResponse GetSC(int code)
        {
            try
            {
                var scs = _scService.Retrieve(code);
                return scs.Count == 0 ? new SCResponse { Status = "true", Message = "No SC found", SCDetails = new List<SC>() } : new SCResponse { Status = "true", Message = string.Empty, SCDetails = scs };
            }
            catch (Exception e)
            {
                return new SCResponse { Status = "false", Message = e.Message, SCDetails = null };
            }
        }



    }
}