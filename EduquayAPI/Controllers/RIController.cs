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
    public class RIController : ControllerBase
    {
        private readonly IRIService _riService;
        public RIController(IRIService riService)
        {
            _riService = riService;
        }


        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddRI(RIRequest rdata)
        {
            var ri = _riService.Add(rdata);
            if (ri == null)
            {
                return NotFound();
            }
            return ri;
        }

        [HttpGet]
        [Route("Retreive")]
        public RIResponse GetRIs()
        {
            try
            {
                var ris = _riService.Retreive();
                return ris.Count == 0 ? new RIResponse { Status = "true", Message = "No RI found",RIDetails = new List<RI>() } : new RIResponse { Status = "true", Message = string.Empty, RIDetails = ris };
            }
            catch (Exception e)
            {
                return new RIResponse { Status = "false", Message = e.Message, RIDetails = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public RIResponse GetRI(int code)
        {
            try
            {
                var ris = _riService.Retreive(code);
                return ris.Count == 0 ? new RIResponse { Status = "true", Message = "No RI found", RIDetails = new List<RI>() } : new RIResponse { Status = "true", Message = string.Empty, RIDetails = ris };
            }
            catch (Exception e)
            {
                return new RIResponse { Status = "false", Message = e.Message, RIDetails = null };
            }
        }

    }
}