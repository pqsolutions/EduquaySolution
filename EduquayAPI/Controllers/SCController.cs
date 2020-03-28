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
    public class SCController : ControllerBase
    {

        private readonly ISCService _scService;
        public SCController(ISCService scService)
        {
            _scService = scService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddSC(SCRequest sData)
        {
            try
            { 
                var sc = _scService.Add(sData);
                return string.IsNullOrEmpty(sc) ? $"Unable to add SC data" : sc;
            }
            catch (Exception e)
            {
                return $"Unable to add SC data - {e.Message}";
            }
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