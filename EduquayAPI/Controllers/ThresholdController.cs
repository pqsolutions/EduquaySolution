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
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;


namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ThresholdController : ControllerBase
    {
        private readonly IThresholdService _thresholdService;
        public ThresholdController(IThresholdService tresholdService)
        {
            _thresholdService = tresholdService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Add(ThresholdRequest tData)
        {
            try
            {
                var threshold = _thresholdService.Add(tData);
                return string.IsNullOrEmpty(threshold) ? $"Unable to add threshold  data" : threshold;
            }
            catch (Exception e)
            {
                return $"Unable to add  threshold data - {e.Message}";
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public ThresholdResponse GetThresholds()
        {
            try
            {
                var thresholds = _thresholdService.Retrieve();
                return thresholds.Count == 0 ? new ThresholdResponse { Status = "true", Message = "No threshold data found", Thresholds = new List<Threshold>() } : new ThresholdResponse { Status = "true", Message = string.Empty, Thresholds = thresholds };
            }
            catch (Exception e)
            {
                return new ThresholdResponse { Status = "false", Message = e.Message, Thresholds = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public ThresholdResponse GetThreshold(int code)
        {
            try
            {
                var thresholds = _thresholdService.Retrieve(code);
                return thresholds.Count == 0 ? new ThresholdResponse { Status = "true", Message = "No threshold data found", Thresholds = new List<Threshold>() } : new ThresholdResponse { Status = "true", Message = string.Empty, Thresholds = thresholds };
            }
            catch (Exception e)
            {
                return new ThresholdResponse { Status = "false", Message = e.Message, Thresholds = null };
            }
        }




    }
}