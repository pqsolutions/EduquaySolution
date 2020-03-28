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
    public class HNINController : ControllerBase
    {
        private readonly IHNINService _hninService;

        public HNINController(IHNINService hninService)
        {
            _hninService = hninService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Add(HNINRequest hdata)
        {
            var hnin = _hninService.Add(hdata);
            if (hnin == null)
            {
                return NotFound();
            }
            return hnin;
        }

        [HttpGet]
        [Route("Retreive")]
        public HNINResponse GetHNINs()
        {
            try
            {
                var hnins = _hninService.Retreive();
                return hnins.Count == 0 ? new HNINResponse { Status = "true", Message = "No HNIN found", HNIN = new List<HNIN>() } : new HNINResponse { Status = "true", Message = string.Empty, HNIN = hnins };
            }
            catch (Exception e)
            {
                return new HNINResponse { Status = "false", Message = e.Message, HNIN = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public HNINResponse GetHNIN(int code)
        {
            try
            {
                var hnins = _hninService.Retreive(code);
                return hnins.Count == 0 ? new HNINResponse { Status = "true", Message = "No HNIN found", HNIN = new List<HNIN>() } : new HNINResponse { Status = "true", Message = string.Empty, HNIN = hnins };
            }
            catch (Exception e)
            {
                return new HNINResponse { Status = "false", Message = e.Message, HNIN = null };
            }
        }

    }
}