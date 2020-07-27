using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.CHCNotifications;
using EduquayAPI.Models.CHCNotifications;
using EduquayAPI.Services.CHCNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CHCNotificationsController : ControllerBase
    {
        private readonly ICHCNotificationsService _chcNotificationsService;
        private readonly ILogger<CHCNotificationsController> _logger;
        public CHCNotificationsController(ICHCNotificationsService chcNotificationsService, ILogger<CHCNotificationsController> logger)
        {
            _chcNotificationsService = chcNotificationsService;
            _logger = logger;
        }


        /// <summary>
        /// Used for  Add the new sample recollection of subject which are damaged sample or timout expiry sample
        /// </summary>
        [HttpPost]
        [Route("AddSampleRecollection")]
        public async Task<IActionResult> AddSampleRecollection(SampleRecollectionRequest srData)
        {


            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding sample recollection data - {JsonConvert.SerializeObject(srData)}");
            var sampleRecollection = await _chcNotificationsService.AddSampleRecollection(srData);
            return Ok(new ServiceResponse
            {
                Status = sampleRecollection.Status,
                Message = sampleRecollection.Message,
            });
        }


        /// <summary>
        /// Used for fetch samples list which damaged and timeout expired in chc notifications
        /// </summary>
        [HttpPost]
        [Route("RetrieveCHCNotificationSamples")]
        public CHCNotificationsSampleResponse GetANMNotificationSamples(CHCNotificationSamplesRequest cnData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var notificationSamples = _chcNotificationsService.GetCHCNotificationSamples(cnData);
                _logger.LogInformation($"Received sample data {notificationSamples}");
                return notificationSamples.Count == 0 ? new CHCNotificationsSampleResponse { Status = "true", Message = "No sample data  found", SampleList = new List<CHCNotificationSample>() }
                : new CHCNotificationsSampleResponse { Status = "true", Message = string.Empty, SampleList = notificationSamples };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  receiving samples data {e.StackTrace}");
                return new CHCNotificationsSampleResponse { Status = "false", Message = e.Message, SampleList = null };
            }
        }

        /// <summary>
        /// Used for fetch unsent samples list 
        /// </summary>
        [HttpPost]
        [Route("RetrieveCHCUnsentSamples")]
        public async Task<IActionResult> GetCHCUnsentSamples(CHCNotificationSamplesRequest cnData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var unsentSamples = await _chcNotificationsService.RetrieveUnsentSamples(cnData);
            _logger.LogInformation($"Received unsent sample data {unsentSamples}");
            return Ok(new CHCUnsentSamplesResponse
            {
                Status = unsentSamples.Status,
                Message = unsentSamples.Message,
                UnsentSamplesDetail = unsentSamples.UnsentSamplesDetail,
            });
        }

        /// <summary>
        /// Used for move  sample timout expiry for unsent samples
        /// </summary>
        [HttpPost]
        [Route("MoveTimeoutExpiry")]
        public ActionResult<CHCTimeoutResponse> MoveTimeoutExpiry(CHCNotificationTimeoutRequest cnData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"moving samples to timeout expiry - {JsonConvert.SerializeObject(cnData)}");
                var sampleStatus = _chcNotificationsService.MoveTimeout(cnData);
                _logger.LogInformation($"Sample successfully moved to sample timout expiry - {cnData}");
                return new CHCTimeoutResponse { Status = sampleStatus.Status, Message = sampleStatus.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to move sample data into timout expiry - {ex.StackTrace}");
                return new CHCTimeoutResponse { Status = "false", Message = ex.Message };
            }
        }

        /// <summary>
        /// Used for fetch HPLC positive subjects
        /// </summary>
        [HttpPost]
        [Route("RetrieveHPLCPositiveSubjects")]
        public HPLCPositiveSubjectsResponse GetHPLCPositiveSubjects(CHCPositiveSamplesRequest cpData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var positiveSubjects = _chcNotificationsService.GetPositiveDetails(cpData);
                _logger.LogInformation($"Received hplc positive subject data {positiveSubjects}");
                return positiveSubjects.Count == 0 ? new HPLCPositiveSubjectsResponse { Status = "true", Message = "No positive subjects data found", positiveSubjects = new List<CHCHPLCPositiveSamples>() }
                : new HPLCPositiveSubjectsResponse { Status = "true", Message = string.Empty, positiveSubjects = positiveSubjects };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  receiving hplc positive subjects data {e.StackTrace}");
                return new HPLCPositiveSubjectsResponse { Status = "false", Message = e.Message, positiveSubjects = null };
            }
        }
    }
}