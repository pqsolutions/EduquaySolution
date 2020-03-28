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
        public ActionResult<string> AddDistrict(DistrictRequest dData)
        {
            try
            {
                var district = _districtService.AddDistrict(dData);
                return string.IsNullOrEmpty(district) ? $"Unable to add district data" : district;
            }
            catch (Exception e)
            {
                return $"Unable to add district data - {e.Message}";
            }
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