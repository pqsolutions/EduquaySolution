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
    public class SCController : ControllerBase
    {

        private readonly ISCService _scService;
        public SCController(ISCService scService)
        {
            _scService = scService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddSC(SCRequest sdata)
        {
            var sc = _scService.Add(sdata);
            if (sc == null)
            {
                return NotFound();
            }
            return sc;
        }

        [HttpGet]
        [Route("Retreive")]
        public SCResponse GetSCs()
        {
            try
            {
                var scs = _scService.Retreive();
                return scs.Count == 0 ? new SCResponse { Status = "true", Message = "No SC found", SCDetails = new List<SC>() } : new SCResponse { Status = "true", Message = string.Empty, SCDetails = scs };
            }
            catch (Exception e)
            {
                return new SCResponse { Status = "false", Message = e.Message, SCDetails = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public SCResponse GetSC(int code)
        {
            try
            {
                var scs = _scService.Retreive(code);
                return scs.Count == 0 ? new SCResponse { Status = "true", Message = "No SC found", SCDetails = new List<SC>() } : new SCResponse { Status = "true", Message = string.Empty, SCDetails = scs };
            }
            catch (Exception e)
            {
                return new SCResponse { Status = "false", Message = e.Message, SCDetails = null };
            }
        }



    }
}