using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Response.ANMNotifications;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Services.ANMNotifications;
using EduquayAPI.Models.ANMNotifications;
using EduquayAPI.Contracts.V1.Response;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class ANMNotificationsController : ControllerBase
    {
        private readonly IANMNotificationsService _anmNotificationsService;
        private readonly ILogger<ANMNotificationsController> _logger;

        public ANMNotificationsController(IANMNotificationsService anmNotificationsService, ILogger<ANMNotificationsController> logger)
        {
            _anmNotificationsService = anmNotificationsService;
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
            var sampleRecollection = await _anmNotificationsService.AddSampleRecollection(srData);
            return Ok(new ServiceResponse
            {
                Status = sampleRecollection.Status,
                Message = sampleRecollection.Message,
            });
        }

        /// <summary>
        /// Used for update the Status in ANM notification Damaged Samples and Sample Timout
        /// </summary>
        [HttpPost]
        [Route("UpdateStatus")]
        public ActionResult<ServiceResponse> UpdateSampleStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {

                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Updating sample status data - {JsonConvert.SerializeObject(usData)}");
                var sampleStatus = _anmNotificationsService.UpdateSampleStatus(usData);
                _logger.LogInformation($"Sample status updated successfully - {usData}");
                return new ServiceResponse { Status = sampleStatus.Status, Message = sampleStatus.Message, Result = null };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update the sample status  - {ex.StackTrace}");
                return new ServiceResponse { Status = "false", Message = ex.Message, Result = null };
            }
        }

        /// <summary>
        /// Used for move  sample timout expiry for unsent samples
        /// </summary>
        [HttpPost]
        [Route("MoveTimeoutExpiry")]
        public ActionResult<ANMTimeoutResponse> MoveTimeoutExpiry(NotificationUpdateStatusRequest usData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"moving samples to timeout expiry - {JsonConvert.SerializeObject(usData)}");
                var sampleStatus = _anmNotificationsService.MoveTimeout(usData);
                _logger.LogInformation($"Sample successfully moved to sample timout expiry - {usData}");
                return new ANMTimeoutResponse { Status = sampleStatus.Status, Message = sampleStatus.Message };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to move sample data into timout expiry - {ex.StackTrace}");
                return new ANMTimeoutResponse { Status = "false", Message = ex.Message };
            }
        }


        /// <summary>
        /// Used for fetch samples list which damaged and timeout expired
        /// </summary>
        [HttpPost]
        [Route("RetrieveANMNotificationSamples")]
        public NotificationSamplesResponse GetANMNotificationSamples(NotificationSamplesRequest nsData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var notificationSamples = _anmNotificationsService.GetANMNotificationSamples(nsData);
                _logger.LogInformation($"Received sample data {notificationSamples}");
                return notificationSamples.Count == 0 ? new NotificationSamplesResponse { Status = "true", Message = "No sample data  found", SampleList = new List<ANMNotificationSample>() } : new NotificationSamplesResponse { Status = "true", Message = string.Empty, SampleList = notificationSamples };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  receiving samples data {e.StackTrace}");
                return new NotificationSamplesResponse { Status = "false", Message = e.Message, SampleList = null };
            }
        }

        /// <summary>
        /// Used for fetch unsent samples list 
        /// </summary>
        [HttpGet]
        [Route("RetrieveANMUnsentSamples/{userId}")]
        public async Task<IActionResult> GetANMUnsentSamples(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var unsentSamples = await _anmNotificationsService.RetrieveUnsentSamples(userId);
            _logger.LogInformation($"Received unsent sample data {unsentSamples}");
            return Ok(new ANMUnsentSamplesResponse
            {
                Status = unsentSamples.Status,
                Message = unsentSamples.Message,
                UnsentSamplesDetail = unsentSamples.UnsentSamplesDetail,
            });
        }

        /// <summary>
        /// Used for fetch HPLC positive subjects
        /// </summary>
        [HttpGet]
        [Route("RetrieveHPLCPositiveSubjects/{userId}")]
        public PositiveSubjectsResponse GetHPLCPositiveSubjects(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var positiveSubjects = _anmNotificationsService.GetPositiveDetails(userId);
                _logger.LogInformation($"Received hplc positive subject data {positiveSubjects}");
                return positiveSubjects.Count == 0 ? new PositiveSubjectsResponse { Status = "true", Message = "No positive subjects data found", positiveSubjects = new List<ANMHPLCPositiveSamples>() }
                : new PositiveSubjectsResponse { Status = "true", Message = string.Empty, positiveSubjects = positiveSubjects };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in  receiving hplc positive subjects data {e.StackTrace}");
                return new PositiveSubjectsResponse { Status = "false", Message = e.Message, positiveSubjects = null };
            }
        }

        /// <summary>
        /// Used for update the Status in ANM notification Positive Subjects
        /// </summary>
        [HttpPost]
        [Route("UpdatePositiveSubjectStatus")]
        public ActionResult<ServiceResponse> UpdatePositiveSubjectStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Updating positive subject status data - {JsonConvert.SerializeObject(usData)}");
                var positiveStatus = _anmNotificationsService.UpdatePositiveSubjectStatus(usData);
              
                _logger.LogInformation($"Positive subject status data updated successfully - {usData}");
                return new ServiceResponse { Status = positiveStatus.Status, Message = positiveStatus.Message , Result = null };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update positive subject status data - {ex.StackTrace}");
                return new ServiceResponse { Status = "false", Message = ex.Message, Result = null };
            }
        }

        /// <summary>
        /// Used to retrieve pndt referal for ANM 
        /// </summary>
        [HttpGet]
        [Route("RetrievePNDTReferal/{userId}")]
        public ANMPNDTResponse GetPNDTReferal(int userId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve pndt referals for ANM  - {JsonConvert.SerializeObject(userId)}");
                var notificationSamples = _anmNotificationsService.GetPNDTReferal(userId);
                return notificationSamples.Count == 0 ? new ANMPNDTResponse { Status = "true", Message = "No subjects found", Samples = new List<ANMPNDTReferal>() }
                : new ANMPNDTResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new ANMPNDTResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }

        /// <summary>
        /// Used to retrieve mtp referal for ANM 
        /// </summary>
        [HttpGet]
        [Route("RetrieveMTPReferal/{userId}")]
        public ANMMTPResponse GetMTPReferal(int userId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve mtp referals for ANM  - {JsonConvert.SerializeObject(userId)}");
                var notificationSamples = _anmNotificationsService.GetMTPReferal(userId);
                return notificationSamples.Count == 0 ? new ANMMTPResponse { Status = "true", Message = "No subjects found", Samples = new List<ANMMTPReferal>() }
                : new ANMMTPResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new ANMMTPResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }


    }
}