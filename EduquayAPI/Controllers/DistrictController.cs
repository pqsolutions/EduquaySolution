using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
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
        public ActionResult<string> AddDistrict(DistrictRequest ddata)
        {
            var district = _districtService.AddDistrict(ddata);
            if (district == null)
            {
                return NotFound();
            }
            return district;
        }

        [HttpGet]
        [Route("Retreive")]
        public DistrictResponse GetDistricts()
        {
            try
            {
                var districts = _districtService.Retreive();
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
                var districts = _districtService.Retreive(code);
                return districts.Count == 0 ? new DistrictResponse { Status = "true", Message = "No district found", Districts = new List<District>() } : new DistrictResponse { Status = "true", Message = string.Empty, Districts = districts };
            }
            catch (Exception e)
            {
                return new DistrictResponse { Status = "false", Message = e.Message, Districts = null };
            }
        }

    }
}