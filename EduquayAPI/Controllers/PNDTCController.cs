using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Contracts.V1.Response.PNDT;
using EduquayAPI.Models.PNDT;
using EduquayAPI.Services.PNDT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class PNDTCController : ControllerBase
    {
        private readonly IPNDTService _pndtService;
        private readonly ILogger<PNDTCController> _logger;
        public PNDTCController(IPNDTService pndtService, ILogger<PNDTCController> logger)
        {
            _pndtService = pndtService;
            _logger = logger;
        }

        /// <summary>
        /// Used to retrieve positive couple subjects for schedule the counselling
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTScheduling")]
        public PrePNDTSchedulingResponse GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve positive couple subjects for schedule the counselling - {JsonConvert.SerializeObject(psData)}");
                var prePNDTScheduling = _pndtService.GetPositiveSubjectsScheduling(psData);
                return prePNDTScheduling.Count == 0 ? new PrePNDTSchedulingResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTScheduling>() } : new PrePNDTSchedulingResponse { Status = "true", Message = string.Empty, data = prePNDTScheduling };
            }
            catch (Exception e)
            {
                return new PrePNDTSchedulingResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to add subjects for schedule the counselling
        /// </summary>
        [HttpPost]
        [Route("ADDPrePNDTScheduling")]
        public async Task<IActionResult> AddScheduling(AddSchedulingRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var counselling = await _pndtService.AddScheduling(asData);
            _logger.LogInformation($"Add Scheduling the counselling for positive subjects {counselling}");
            return Ok(new AddSchedulingResponse
            {
                Status = counselling.Status,
                Message = counselling.Message,
                data = counselling.data,
            });
        }


        /// <summary>
        /// Used to retrieve positive couple subjects for scheduled the counselling
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTScheduled")]
        public PrePNDTScheduledResponse GetSubjectsScheduled(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve positive couple subjects for scheduled the counselling - {JsonConvert.SerializeObject(psData)}");
                var prePNDTScheduling = _pndtService.GetSubjectsScheduled(psData);
                return prePNDTScheduling.Count == 0 ? new PrePNDTScheduledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTScheduled>() } : new PrePNDTScheduledResponse { Status = "true", Message = string.Empty, data = prePNDTScheduling };
            }
            catch (Exception e)
            {
                return new PrePNDTScheduledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve positive couple subjects for scheduled the counselling
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselling")]
        public PrePNDTCounsellingResponse GetScheduledForCounselling(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselling - {JsonConvert.SerializeObject(psData)}");
                var prePNDTCounselling = _pndtService.GetScheduledForCounselling(psData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounsellingResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselling>() } : new PrePNDTCounsellingResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounsellingResponse { Status = "false", Message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used to add subjects for counselling for the PrePNDT
        /// </summary>
        [HttpPost]
        [Route("ADDPrePNDTCounselling")]
        public async Task<IActionResult> AddCounselling(AddPrePNDTCounsellingRequest acData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var counselling = await _pndtService.AddCounselling(acData);
            _logger.LogInformation($"Add  counselling for positive subjects for PNDT - {counselling}");
            return Ok(new AddCounsellingResponse
            {
                Status = counselling.Status,
                Message = counselling.Message,
                data = counselling.data,
            });
        }

        /// <summary>
        /// Used to retrieve positive couple subjects  counseled for PNDT agreed yes
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselledYes")]
        public PrePNDTCounselledResponse GetScheduledForCounseledYes(PNDTSchedulingRequest pcData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselled PNDT agree yes - {JsonConvert.SerializeObject(pcData)}");
                var prePNDTCounselling = _pndtService.GetSubjectsCounselledYes(pcData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounselledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselled>() } : new PrePNDTCounselledResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounselledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve positive couple subjects  counseled for PNDT agreed no
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselledNo")]
        public PrePNDTCounselledResponse GetScheduledForCounseledNo(PNDTSchedulingRequest pcData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselled PNDT agree no - {JsonConvert.SerializeObject(pcData)}");
                var prePNDTCounselling = _pndtService.GetSubjectsCounselledNo(pcData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounselledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselled>() } : new PrePNDTCounselledResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounselledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve positive couple subjects  counseled for PNDT agreed pending
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselledPending")]
        public PrePNDTCounselledResponse GetScheduledForCounseledPending(PNDTSchedulingRequest pcData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselled PNDT agree pending - {JsonConvert.SerializeObject(pcData)}");
                var prePNDTCounselling = _pndtService.GetSubjectsCounselledPending(pcData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounselledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselled>() } : new PrePNDTCounselledResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounselledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

    }  
}