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
    public class CHCController : ControllerBase
    {
        private readonly ICHCService _chcService;
        public CHCController(ICHCService chcService)
        {
            _chcService = chcService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddCHC(CHCRequest cdata)
        {
            var chc = _chcService.Add(cdata);
            if (chc == null)
            {
                return NotFound();
            }
            return chc;
        }

        [HttpGet]
        [Route("Retreive")]
        public CHCResponse GetCHCs()
        {
            try
            {
                var chcs = _chcService.Retreive();
                return chcs.Count == 0 ? new CHCResponse { Status = "true", Message = "No CHC found", CHCDetails = new List<CHC>() } : new CHCResponse { Status = "true", Message = string.Empty, CHCDetails = chcs };
            }
            catch (Exception e)
            {
                return new CHCResponse { Status = "false", Message = e.Message, CHCDetails = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public CHCResponse GetCHC(int code)
        {
            try
            {
                var chcs = _chcService.Retreive(code);
                return chcs.Count == 0 ? new CHCResponse { Status = "true", Message = "No CHC found", CHCDetails = new List<CHC>() } : new CHCResponse { Status = "true", Message = string.Empty, CHCDetails = chcs };
            }
            catch (Exception e)
            {
                return new CHCResponse { Status = "false", Message = e.Message, CHCDetails = null };
            }
        }


    }
}