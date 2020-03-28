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
    public class FacilityTypeController : ControllerBase
    {
        private readonly IFacilityTypeService _facilityTypeService;

        public FacilityTypeController(IFacilityTypeService facilityTypeService)
        {
            _facilityTypeService = facilityTypeService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Add(FacilityTypeRequest ftdata)
        {
            var facilitytype = _facilityTypeService.Add(ftdata);
            if (facilitytype == null)
            {
                return NotFound();
            }
            return facilitytype;
        }

        [HttpGet]
        [Route("Retreive")]
        public FacilityTypeResponse GetFacilityTypes()
        {
            try
            {
                var facilitytypes = _facilityTypeService.Retreive();
                return facilitytypes.Count == 0 ? new FacilityTypeResponse { Status = "true", Message = "No facilty type found", FacilityType = new List<FacilityType>() } : new FacilityTypeResponse { Status = "true", Message = string.Empty, FacilityType = facilitytypes };
            }
            catch (Exception e)
            {
                return new FacilityTypeResponse { Status = "false", Message = e.Message, FacilityType = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public FacilityTypeResponse GetFacilityType(int code)
        {
            try
            {
                var facilitytypes = _facilityTypeService.Retreive(code);
                return facilitytypes.Count == 0 ? new FacilityTypeResponse { Status = "true", Message = "No facility type found", FacilityType = new List<FacilityType>() } : new FacilityTypeResponse { Status = "true", Message = string.Empty, FacilityType = facilitytypes };
            }
            catch (Exception e)
            {
                return new FacilityTypeResponse { Status = "false", Message = e.Message, FacilityType = null };
            }
        }
    }
}
