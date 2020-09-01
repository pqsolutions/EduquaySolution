using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Contracts.V1.Response.Obstetrician;
using EduquayAPI.Models.PNDTObstetrician;
using EduquayAPI.Services.PNDTObstetrician;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class PNDTObstetricianController : ControllerBase
    {
        private readonly IPNDTObstetricianService _pndtObstetricianService;
        private readonly ILogger<PNDTObstetricianController> _logger;
        public PNDTObstetricianController(IPNDTObstetricianService pndtObstetricianService, ILogger<PNDTObstetricianController> logger)
        {
            _pndtObstetricianService = pndtObstetricianService;
            _logger = logger;
        }

        /// <summary>
        /// Used to retrieve PNDT Pending
        /// </summary>
        [HttpPost]
        [Route("RetrievePNDTPending")]
        public PNDTPendingListResponse GetPNDTPending(ObstetricianRequest oData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for pending PNDT who agree the test - {JsonConvert.SerializeObject(oData)}");
                var pndtPending = _pndtObstetricianService.GetPNDTPending(oData);
                return pndtPending.Count == 0 ? new PNDTPendingListResponse { Status = "true", Message = "No subjects found", data = new List<PNDTPending>() } : new PNDTPendingListResponse { Status = "true", Message = string.Empty, data = pndtPending };
            }
            catch (Exception e)
            {
                return new PNDTPendingListResponse { Status = "false", Message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used to add PND test for the counselled couples
        /// </summary>
        [HttpPost]
        [Route("ADDPNDTest")]
        public async Task<IActionResult> AddPNDTest(AddPNDTestRequest aData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var pndTest = await _pndtObstetricianService.AddPNDTest(aData);
            _logger.LogInformation($"Add PNDTest for the counselled positive subjects {pndTest}");
            return Ok(new AddPNDTResponse
            {
                Status = pndTest.Status,
                Message = pndTest.Message,
                data = pndTest.data,
            });
        }

        /// <summary>
        /// Used to retrieve Post PNDT not Completed
        /// </summary>
        [HttpPost]
        [Route("RetrievePostPNDTNotCompleted")]
        public PNDTNotCompletedResponse GetPNDTNotCompleted(ObstetricianRequest oData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for PNDT not completed - {JsonConvert.SerializeObject(oData)}");
                var notCompleted = _pndtObstetricianService.GetPNDTNotCompleted(oData);
                return notCompleted.Count == 0 ? new PNDTNotCompletedResponse { Status = "true", Message = "No subjects found", data = new List<PNDTNotCompleted>() } 
                : new PNDTNotCompletedResponse { Status = "true", Message = string.Empty, data = notCompleted };
            }
            catch (Exception e)
            {
                return new PNDTNotCompletedResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve  PNDT  Completed Summary
        /// </summary>
        [HttpPost]
        [Route("RetrievePNDTCompletedSummary")]
        public PNDTCompletedSummaryResponse GetPNDTCompleted(PNDTCompletedSummaryRequest oData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for PNDT completed summary - {JsonConvert.SerializeObject(oData)}");
                var completed = _pndtObstetricianService.GetPNDTCompletedSummary(oData);
                return completed.Count == 0 ? new PNDTCompletedSummaryResponse { Status = "true", Message = "No subjects found", data = new List<PNDTCompletedSummary>() }
                : new PNDTCompletedSummaryResponse { Status = "true", Message = string.Empty, data = completed };
            }
            catch (Exception e)
            {
                return new PNDTCompletedSummaryResponse { Status = "false", Message = e.Message, data = null };
            }
        }

    }
}