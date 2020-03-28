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
    public class HNINController : ControllerBase
    {
        private readonly IHNINService _hninService;

        public HNINController(IHNINService hninService)
        {
            _hninService = hninService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Add(HNINRequest hData)
        {

            try
            {
                var hnin = _hninService.Add(hData);
                return string.IsNullOrEmpty(hnin) ? $"Unable to add HNIN data" : hnin;
            }
            catch (Exception e)
            {
                return $"Unable to add HNIN data - {e.Message}";
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public HNINResponse GetHNINs()
        {
            try
            {
                var hnins = _hninService.Retrieve();
                return hnins.Count == 0 ? new HNINResponse { Status = "true", Message = "No HNIN found", HNIN = new List<HNIN>() } : new HNINResponse { Status = "true", Message = string.Empty, HNIN = hnins };
            }
            catch (Exception e)
            {
                return new HNINResponse { Status = "false", Message = e.Message, HNIN = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public HNINResponse GetHNIN(int code)
        {
            try
            {
                var hnins = _hninService.Retrieve(code);
                return hnins.Count == 0 ? new HNINResponse { Status = "true", Message = "No HNIN found", HNIN = new List<HNIN>() } : new HNINResponse { Status = "true", Message = string.Empty, HNIN = hnins };
            }
            catch (Exception e)
            {
                return new HNINResponse { Status = "false", Message = e.Message, HNIN = null };
            }
        }

    }
}