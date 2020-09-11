using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.DistrictCoordinator;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.DistrictCoordinator;
using EduquayAPI.Models.DiscrictCoordinator;
using EduquayAPI.Services.DistrictCoordinator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class DistrictCoordinatorController : ControllerBase
    {
        private readonly IDCService _dcService;
        private readonly ILogger<DistrictCoordinatorController> _logger;
        public DistrictCoordinatorController(IDCService dcService, ILogger<DistrictCoordinatorController> logger)
        {
            _dcService = dcService;
            _logger = logger;
        }


        /// <summary>
        /// Used to retrieve damaged samples for DC 
        /// </summary>
        [HttpGet]
        [Route("RetrieveDamagedSamples/{districtId}")]
        public DCNotificationSampleResponse GetDamagedSamples(int districtId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve  damaged samples for DC  - {JsonConvert.SerializeObject(districtId)}");
                var notificationSamples = _dcService.GetDamagedSamples(districtId);
                return notificationSamples.Count == 0 ? new DCNotificationSampleResponse { Status = "true", Message = "No subjects found", Samples = new List<NotificationSamples>() }
                : new DCNotificationSampleResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new DCNotificationSampleResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }

        /// <summary>
        /// Used to retrieve unsent samples for DC 
        /// </summary>
        [HttpGet]
        [Route("RetrieveUnsentSamples/{districtId}")]
        public DCNotificationSampleResponse GetUnsentSamples(int districtId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve  unsent samples for DC  - {JsonConvert.SerializeObject(districtId)}");
                var notificationSamples = _dcService.GetUnsentSamples(districtId);
                return notificationSamples.Count == 0 ? new DCNotificationSampleResponse { Status = "true", Message = "No subjects found", Samples = new List<NotificationSamples>() }
                : new DCNotificationSampleResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new DCNotificationSampleResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }

        /// <summary>
        /// Used to retrieve timeout samples for DC 
        /// </summary>
        [HttpGet]
        [Route("RetrieveTimeoutExpirySamples/{districtId}")]
        public DCNotificationSampleResponse GetTimeoutExpiry(int districtId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve  timeout expiry  samples for DC  - {JsonConvert.SerializeObject(districtId)}");
                var notificationSamples = _dcService.GetTimeoutSamples(districtId);
                return notificationSamples.Count == 0 ? new DCNotificationSampleResponse { Status = "true", Message = "No subjects found", Samples = new List<NotificationSamples>() }
                : new DCNotificationSampleResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new DCNotificationSampleResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }

        /// <summary>
        /// Used for update the Status in DC notification Damaged Samples and Sample Timeout
        /// </summary>
        [HttpPost]
        [Route("UpdateSamplesStatus")]
        public ActionResult<ServiceResponse> UpdateSampleStatus(NotificationDCRequest nData)
        {
            try
            {

                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Updating sample status data - {JsonConvert.SerializeObject(nData)}");
                var sampleStatus = _dcService.UpdateSampleStatus(nData);
                _logger.LogInformation($"Sample status updated successfully - {nData}");
                return new ServiceResponse { Status = sampleStatus.Status, Message = sampleStatus.Message, Result = null };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update the sample status  - {ex.StackTrace}");
                return new ServiceResponse { Status = "false", Message = ex.Message, Result = null };
            }
        }

        /// <summary>
        /// Used to retrieve positive samples for DC 
        /// </summary>
        [HttpGet]
        [Route("RetrievePositiveSubjectSamples/{districtId}")]
        public DCPositiveSamplesResponse GetPositiveSampeles(int districtId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve positive samples for DC  - {JsonConvert.SerializeObject(districtId)}");
                var notificationSamples = _dcService.GetPositiveSampeles(districtId);
                return notificationSamples.Count == 0 ? new DCPositiveSamplesResponse { Status = "true", Message = "No subjects found", Samples = new List<DCPositiveSamples>() }
                : new DCPositiveSamplesResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new DCPositiveSamplesResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }

        /// <summary>
        /// Used for update the Status in DC notification Positive Subjects
        /// </summary>
        [HttpPost]
        [Route("UpdatePositiveSubjectStatus")]
        public ActionResult<ServiceResponse> UpdatePositiveSubjectStatus(NotificationDCRequest nData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Updating positive subject status data - {JsonConvert.SerializeObject(nData)}");
                var positiveStatus = _dcService.UpdatePositiveSubjectStatus(nData);

                _logger.LogInformation($"Positive subject status data updated successfully - {nData}");
                return new ServiceResponse { Status = positiveStatus.Status, Message = positiveStatus.Message, Result = null };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update positive subject status data - {ex.StackTrace}");
                return new ServiceResponse { Status = "false", Message = ex.Message, Result = null };
            }
        }

        /// <summary>
        /// Used to retrieve pndt referal for DC 
        /// </summary>
        [HttpGet]
        [Route("RetrievePNDTReferal/{districtId}")]
        public DCPNDTReferalResponse GetPNDTReferal(int districtId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve pndt referals for DC  - {JsonConvert.SerializeObject(districtId)}");
                var notificationSamples = _dcService.GetPNDTReferal(districtId);
                return notificationSamples.Count == 0 ? new DCPNDTReferalResponse { Status = "true", Message = "No subjects found", Samples = new List<PNDTReferal>() }
                : new DCPNDTReferalResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new DCPNDTReferalResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }

        /// <summary>
        /// Used to retrieve mtp referal for DC 
        /// </summary>
        [HttpGet]
        [Route("RetrieveMTPReferal/{districtId}")]
        public DCMTPReferalResponse GetMTPReferal(int districtId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve mtp referals for DC  - {JsonConvert.SerializeObject(districtId)}");
                var notificationSamples = _dcService.GetMTPReferal(districtId);
                return notificationSamples.Count == 0 ? new DCMTPReferalResponse { Status = "true", Message = "No subjects found", Samples = new List<MTPReferal>() }
                : new DCMTPReferalResponse { Status = "true", Message = string.Empty, Samples = notificationSamples };
            }
            catch (Exception e)
            {
                return new DCMTPReferalResponse { Status = "false", Message = e.Message, Samples = null };
            }
        }

    }
}