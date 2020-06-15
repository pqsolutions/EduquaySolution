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
        public ActionResult<ServiceResponse> AddSampleRecollection(SampleRecollectionRequest srData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Adding sample recollection data - {JsonConvert.SerializeObject(srData)}");
                var sampleRecollection = _anmNotificationsService.AddSampleRecollection(srData);
                if (sampleRecollection == null)
                {
                    return NotFound();
                }
                _logger.LogInformation($"Sample recollection data added successfully - {srData}");
                return new ServiceResponse { Status = "true", Message = string.Empty, Result = sampleRecollection };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add sample recollection data - {ex.StackTrace}");
                return new ServiceResponse { Status = "true", Message = ex.Message, Result = "Failed to add sample recollection data" };
            }
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
                if (sampleStatus == null)
                {
                    return NotFound();
                }
                _logger.LogInformation($"Sample status data updated successfully - {usData}");
                return new ServiceResponse { Status = "true", Message = string.Empty, Result = sampleStatus };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update sample status data - {ex.StackTrace}");
                return new ServiceResponse { Status = "true", Message = ex.Message, Result = "Failed to update sample status data" };
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
        /// Used for get subject sample  detail of particular ANM
        /// </summary>
        [HttpGet]
        [Route("RetrieveSubjectSample/{id}/{notification}")]
        public NotificationSubjectSampleResponse  GetANMSubjectSamples(int id, int notification)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var subject = _anmNotificationsService.GetANMSubjectSamples(id, notification);
                _logger.LogInformation($"Received Subject Data {subject}");
                return subject.Count == 0 ? new NotificationSubjectSampleResponse { Status = "true", Message = "No subject found", Subject = new List<ANMSubjectSample>() } : new NotificationSubjectSampleResponse { Status = "true", Message = string.Empty, Subject = subject };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving subject data {e.StackTrace}");
                return new NotificationSubjectSampleResponse { Status = "false", Message = e.Message, Subject = null };
            }
        }



    }
}