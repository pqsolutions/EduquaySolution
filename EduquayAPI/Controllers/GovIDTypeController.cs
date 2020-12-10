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
    public class GovIDTypeController : ControllerBase
    {
        private readonly IGovIDTypeService _govidTypeService;

        public GovIDTypeController(IGovIDTypeService govidTypeService)
        {
            _govidTypeService = govidTypeService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(GovIDTypeRequest gtData)
        {
            var addEditResponse = await _govidTypeService.Add(gtData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }

        [HttpGet]
        [Route("Retrieve")]
        public GovIDTypeResponse GetGovIDTypes()
        {
            try
            {
                var govidTypes = _govidTypeService.Retrieve();
                return govidTypes.Count == 0 ? new GovIDTypeResponse { Status = "true", Message = "No gov id type found", GovIDTypes = new List<GovIDType>() } : new GovIDTypeResponse { Status = "true", Message = string.Empty, GovIDTypes = govidTypes };
            }
            catch (Exception e)
            {
                return new GovIDTypeResponse { Status = "false", Message = e.Message, GovIDTypes = null };
            }
        }


        [HttpGet]
        [Route("Retrieve/{code}")]
        public GovIDTypeResponse GetGovIDType(int code)
        {
            try
            {
                var govidTypes = _govidTypeService.Retrieve(code);
                return govidTypes.Count == 0 ? new GovIDTypeResponse { Status = "true", Message = "No gov id type found", GovIDTypes = new List<GovIDType>() } : new GovIDTypeResponse { Status = "true", Message = string.Empty, GovIDTypes = govidTypes };
            }
            catch (Exception e)
            {
                return new GovIDTypeResponse { Status = "false", Message = e.Message, GovIDTypes = null };
            }
        }

    }
}