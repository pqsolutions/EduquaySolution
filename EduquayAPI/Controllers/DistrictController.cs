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
    public class DistrictController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DistrictController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> AddDistrict(DistrictRequest dData)
        {
            var addEditResponse = await _districtService.AddDistrict(dData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
           
        }

        [HttpGet]
        [Route("Retrieve")]
        public DistrictResponse GetDistricts()
        {
            try
            {
                var districts = _districtService.Retrieve();
                return districts.Count == 0 ? new DistrictResponse { Status = "true", Message = "No districts found", Districts = new List<District>() } : new DistrictResponse { Status = "true", Message = string.Empty, Districts = districts };
            }
            catch (Exception e)
            {
                return new DistrictResponse { Status = "false", Message = e.Message, Districts = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public DistrictResponse GetDistrict(int code)
        {
            try
            {
                var districts = _districtService.Retrieve(code);
                return districts.Count == 0 ? new DistrictResponse { Status = "true", Message = "No district found", Districts = new List<District>() } : new DistrictResponse { Status = "true", Message = string.Empty, Districts = districts };
            }
            catch (Exception e)
            {
                return new DistrictResponse { Status = "false", Message = e.Message, Districts = null };
            }
        }

    }
}