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
    public class FacilityTypeController : ControllerBase
    {
        private readonly IFacilityTypeService _facilityTypeService;

        public FacilityTypeController(IFacilityTypeService facilityTypeService)
        {
            _facilityTypeService = facilityTypeService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Add(FacilityTypeRequest ftData)
        {
            try
            {
                var facilityType = _facilityTypeService.Add(ftData);
                return string.IsNullOrEmpty(facilityType) ? $"Unable to add facility type data" : facilityType;
            }
            catch (Exception e)
            {
                return $"Unable to add facility type data - {e.Message}";
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public FacilityTypeResponse GetFacilityTypes()
        {
            try
            {
                var facilityTypes = _facilityTypeService.Retrieve();
                return facilityTypes.Count == 0 ? new FacilityTypeResponse { Status = "true", Message = "No facilty type found", FacilityType = new List<FacilityType>() } : new FacilityTypeResponse { Status = "true", Message = string.Empty, FacilityType = facilityTypes };
            }
            catch (Exception e)
            {
                return new FacilityTypeResponse { Status = "false", Message = e.Message, FacilityType = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public FacilityTypeResponse GetFacilityType(int code)
        {
            try
            {
                var facilityTypes = _facilityTypeService.Retrieve(code);
                return facilityTypes.Count == 0 ? new FacilityTypeResponse { Status = "true", Message = "No facility type found", FacilityType = new List<FacilityType>() } : new FacilityTypeResponse { Status = "true", Message = string.Empty, FacilityType = facilityTypes };
            }
            catch (Exception e)
            {
                return new FacilityTypeResponse { Status = "false", Message = e.Message, FacilityType = null };
            }
        }
    }
}
