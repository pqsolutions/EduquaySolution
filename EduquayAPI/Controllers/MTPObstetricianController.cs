using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Contracts.V1.Response.Obstetrician;
using EduquayAPI.Models.MTPObstetrician;
using EduquayAPI.Services.MTPObstetrician;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MTPObstetricianController : ControllerBase
    {

        private readonly IMTPObstetricianService _mtpObstetricianService;
        private readonly ILogger<MTPObstetricianController> _logger;
        public MTPObstetricianController(IMTPObstetricianService mtpObstetricianService, ILogger<MTPObstetricianController> logger)
        {
            _mtpObstetricianService = mtpObstetricianService;
            _logger = logger;
        }

        /// <summary>
        /// Used to retrieve MTP Pending
        /// </summary>
        [HttpPost]
        [Route("RetrieveMTPPending")]
        public MTPPendingListResponse GetMTPPending(ObstetricianRequest oData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for pending MTP who agree the service - {JsonConvert.SerializeObject(oData)}");
                var mtpPending = _mtpObstetricianService.GetMTPPending(oData);
                return mtpPending.Count == 0 ? new MTPPendingListResponse { Status = "true", Message = "No subjects found", data = new List<MTPPending>() } : new MTPPendingListResponse { Status = "true", Message = string.Empty, data = mtpPending };
            }
            catch (Exception e)
            {
                return new MTPPendingListResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to add MTP service for the counselled couples
        /// </summary>
        [HttpPost]
        [Route("ADDMTPTest")]
        public async Task<IActionResult> AddMTPTest(AddMTPTestRequest aData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var mtpTest = await _mtpObstetricianService.AddMTPService(aData);
            _logger.LogInformation($"Add MTPTest for the counselled subjects {mtpTest}");
            return Ok(new AddMTPResponse
            {
                Status = mtpTest.Status,
                Message = mtpTest.Message,
                data = mtpTest.data,
            });
        }

        /// <summary>
        /// Used to retrieve MTP Completed
        /// </summary>
        [HttpPost]
        [Route("RetrieveMTPCompleted")]
        public MTPCompletedResponse GetMTPCompleted(ObstetricianRequest oData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for completed MTP  - {JsonConvert.SerializeObject(oData)}");
                var mtpCompleted = _mtpObstetricianService.GetMTPCompleted(oData);
                return mtpCompleted.Count == 0 ? new MTPCompletedResponse { Status = "true", Message = "No subjects found", data = new List<MTPSummary>() } : new MTPCompletedResponse { Status = "true", Message = string.Empty, data = mtpCompleted };
            }
            catch (Exception e)
            {
                return new MTPCompletedResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve MTP Summary
        /// </summary>
        [HttpGet]
        [Route("RetrieveMTPSummary")]
        public MTPSummaryResponse GetMTPSummary()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var mtpSummary = _mtpObstetricianService.GetMTPSummary();
                return mtpSummary.Count == 0 ? new MTPSummaryResponse { Status = "true", Message = "No subjects found", data = new List<MTPSummary>() } : new MTPSummaryResponse { Status = "true", Message = string.Empty, data = mtpSummary };
            }
            catch (Exception e)
            {
                return new MTPSummaryResponse { Status = "false", Message = e.Message, data = null };
            }
        }

    }
}