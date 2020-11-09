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
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Services.MobileSubject;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.MobileSubject;
using EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection;
using EduquayAPI.Contracts.V1.Request.MobileAppShipment;
using EduquayAPI.Contracts.V1.Request.Mobile;

namespace EduquayAPI.Controllers
{
    [Authorize]
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MobileSubjectController : ControllerBase
    {
        private readonly IMobileSubjectService _mobileSubjectService;
        private readonly ILogger<MobileSubjectController> _logger;
        public MobileSubjectController(IMobileSubjectService mobileSubjectService, ILogger<MobileSubjectController> logger)
        {
            _mobileSubjectService = mobileSubjectService;
            _logger = logger;
        }


        [HttpPost]
        [Route("RetrieveSubjectList")]
        public async Task<IActionResult> RetrieveSubjectList(MobileRetrieveRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var subRegListResponse = await _mobileSubjectService.RetrieveDetail(mrData);

            if (!subRegListResponse.Valid)
            {
                return Unauthorized(new SubjectResigrationListResponse
                {
                    Status = "false",
                    Valid = subRegListResponse.Valid,
                    Message = subRegListResponse.Message
                });
            }

            return Ok(new SubjectResigrationListResponse
            {
                Status = subRegListResponse.Status,
                Valid = subRegListResponse.Valid,
                Message = subRegListResponse.Message,
                LastUniqueSubjectId = subRegListResponse.LastUniqueSubjectId,
                LastShipmentId = subRegListResponse.LastShipmentId,
                SubjectResigrations = subRegListResponse.SubjectResigrations,
                SampleCollections = subRegListResponse.SampleCollections,
                ShipmentLogDetail = subRegListResponse.ShipmentLogDetail,
            });
        }

        [HttpPost]
        [Route("RetrieveNotificationList")]
        public async Task<IActionResult> RetrieveNotificationList(MobileRetrieveRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var nlResponse = await _mobileSubjectService.RetrieveNotifications(mrData);

            if (!nlResponse.Valid)
            {
                return Unauthorized(new NotificationListResponse
                {
                    Status = "false",
                    Valid = nlResponse.Valid,
                    Message = nlResponse.Message
                });
            }

            return Ok(new NotificationListResponse
            {
                Status = nlResponse.Status,
                Message = nlResponse.Message,
                Valid = nlResponse.Valid,
                totalNotifications = nlResponse.totalNotifications,
                damagedSamples = nlResponse.damagedSamples,
                timeoutExpirySamples = nlResponse.timeoutExpirySamples,
                positiveSubjects = nlResponse.positiveSubjects,
                chcSubjectResigrations = nlResponse.chcSubjectResigrations,
                chcSampleCollections = nlResponse.chcSampleCollections,
                results = nlResponse.results,
                pndtReferral = nlResponse.pndtReferral,
                mtpReferral = nlResponse.mtpReferral,
                prePndtCounselling = nlResponse.prePndtCounselling,
                pndtTesting = nlResponse.pndtTesting,
                postPndtCounselling = nlResponse.postPndtCounselling,
                mtpService = nlResponse.mtpService,
                postMtpFollowUp = nlResponse.postMtpFollowUp,
            });
        }

        [HttpPost]
        [Route("MoveTimeoutExpiry")]
        public async Task<IActionResult> AddMultipleTimeoutExpiry(AddTimeoutExpireMobileRequest eData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Move sample in timeout expiry in mobile app- {JsonConvert.SerializeObject(eData)}");
            var tResponse = await _mobileSubjectService.AddMoveTimeout(eData);

            if (!tResponse.Valid)
            {
                return Unauthorized(new TimeoutResponse
                {
                    Status = "false",
                    Valid = tResponse.Valid,
                    Message = tResponse.Message
                });
            }

            return Ok(new TimeoutResponse
            {
                Status = tResponse.Status,
                Valid = tResponse.Valid,
                Message = tResponse.Message,
                Barcodes = tResponse.Barcodes
            });
        }

        [HttpPost]
        [Route("UpdateStatusSamples")]
        public async Task<IActionResult> AddUpdateSamples(AddUpdateStatusRequest usData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Add status update for damaged or timeout expiry samples in mobile app- {JsonConvert.SerializeObject(usData)}");
            var uResponse = await _mobileSubjectService.UpdateNotificationStatus(usData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new UpdateStatusResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new UpdateStatusResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
                Barcodes = uResponse.Barcodes
            });
        }

        [HttpPost]
        [Route("UpdateStatusPositiveSubjects")]
        public async Task<IActionResult> AddUpdateStatusPositiveSubjects(AddUpdateStatusRequest usData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Add status update for hplc postive subjects in mobile app- {JsonConvert.SerializeObject(usData)}");
            var uResponse = await _mobileSubjectService.UpdatatePositiveStatus(usData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new UpdateStatusResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new UpdateStatusResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
                Barcodes = uResponse.Barcodes
            });
        }

        [HttpPost]
        [Route("AddAcknowledgement")]
        public async Task<IActionResult> AddAcknowledgement(AcnowledgementRequest usData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Add acknowledgement test results of subjects in mobile app- {JsonConvert.SerializeObject(usData)}");
            var uResponse = await _mobileSubjectService.AddAcknowledgement(usData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new AcknowledgementResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new AcknowledgementResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
            });
        }

        [HttpPost]
        [Route("AddCHCSubjectAcknowledgement")]
        public async Task<IActionResult> AddCHCSubjectAcknowledgement(AcnowledgementRequest usData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Add acknowledgement chc subjects registered received in mobile app- {JsonConvert.SerializeObject(usData)}");
            var uResponse = await _mobileSubjectService.AddCHCSubjectAcknowledgement(usData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new AcknowledgementResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new AcknowledgementResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
            });
        }

        [HttpPost]
        [Route("AddCHCSamplesAcknowledgement")]
        public async Task<IActionResult> AddCHCSamplesAcknowledgement(AcknowledgementBarocdeRequest usData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Add acknowledgement chc subjects samples collected received in mobile app- {JsonConvert.SerializeObject(usData)}");
            var uResponse = await _mobileSubjectService.AddCHCSampleAcknowledgement(usData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new AcknowledgementResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new AcknowledgementResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
            });
        }

        [HttpPost]
        [Route("UpdatePNDTStatus")]
        public async Task<IActionResult> UpdatePNDTStatus(AddReferalStatusRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Status update subjects for pndt referal  in mobile app- {JsonConvert.SerializeObject(rData)}");
            var uResponse = await _mobileSubjectService.UpdatePNDTReferalStatus(rData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new UpdateReferalStatusResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new UpdateReferalStatusResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
                SubjectIds = uResponse.SubjectIds
            });
        }

        [HttpPost]
        [Route("UpdateMTPStatus")]
        public async Task<IActionResult> UpdateMTPStatus(AddReferalStatusRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Status update subjects for mtp referal  in mobile app- {JsonConvert.SerializeObject(rData)}");
            var uResponse = await _mobileSubjectService.UpdateMTPReferalStatus(rData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new UpdateReferalStatusResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new UpdateReferalStatusResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
                SubjectIds = uResponse.SubjectIds
            });
        }

        [HttpPost]
        [Route("AddPrePostPNDTMTPAcknowledgement")]
        public async Task<IActionResult> AddPrePostPNDTMTPAcknowledgement(AddPrePostStatusRequest aData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Add acknowledgement pre and post counselling and pndt test and mtp service in mobile app- {JsonConvert.SerializeObject(aData)}");
            var uResponse = await _mobileSubjectService.UpdatePrePostPNDTMTPAcknowledgement(aData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new AcknowledgementResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message
                });
            }

            return Ok(new AcknowledgementResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
            });
        }

        [HttpPost]
        [Route("AddMTPFollowupStatus")]
        public async Task<IActionResult> AddMTPFollowupStatus(AddFollowUpRequest fData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Add post mtp followup status in mobile app- {JsonConvert.SerializeObject(fData)}");
            var uResponse = await _mobileSubjectService.UpdatePostMTPFollowupStatus(fData);

            if (!uResponse.Valid)
            {
                return Unauthorized(new UpdateFollowupStatusResponse
                {
                    Status = "false",
                    Valid = uResponse.Valid,
                    Message = uResponse.Message,
                    SubjectIds = uResponse.SubjectIds,
                });
            }

            return Ok(new UpdateFollowupStatusResponse
            {
                Status = uResponse.Status,
                Valid = uResponse.Valid,
                Message = uResponse.Message,
                SubjectIds = uResponse.SubjectIds,
            });
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddMultipleSubjects(AddSubjectRequest subRegData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Register multiple subjects in mobile app- {JsonConvert.SerializeObject(subRegData)}");
            var subRegResponse = await _mobileSubjectService.AddSubjectRegistration(subRegData);

            if (!subRegResponse.Valid)
            {
                return Unauthorized(new SubRegSuccessResponse
                {
                    Status = "false",
                    Valid = subRegResponse.Valid,
                    Message = subRegResponse.Message
                });
            }

            return Ok(new SubRegSuccessResponse
            {
                Status = subRegResponse.Status,
                Valid = subRegResponse.Valid,
                Message = subRegResponse.Message,
                SuccessIds = subRegResponse.SuccessIds,
            });

        }

        [HttpPost]
        [Route("AddSampleCollection")]
        public async Task<IActionResult> AddMultipleSamples(SampleCollectRequest ssData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Collect multiple samples in mobile app- {JsonConvert.SerializeObject(ssData)}");
            var sclResponse = await _mobileSubjectService.AddSampleCollection(ssData);

            if (!sclResponse.Valid)
            {
                return Unauthorized(new SampleCollectionListResponse
                {
                    Status = "false",
                    Valid = sclResponse.Valid,
                    Message = sclResponse.Message
                });
            }
            return Ok(new SampleCollectionListResponse
            {
                Status = sclResponse.Status,
                Valid = sclResponse.Valid,
                Message = sclResponse.Message,
                Barcodes = sclResponse.Barcodes,
            });
        }

        [HttpPost]
        [Route("AddShipment")]
        public async Task<IActionResult> AddMultipleShipments(MobileShipmentsRequest msData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Multiple shipments in mobile app- {JsonConvert.SerializeObject(msData)}");
            var sclResponse = await _mobileSubjectService.AddANMShipment(msData);
            if (!sclResponse.Valid)
            {
                return Unauthorized(new ShipmentListResponse
                {
                    Status = "false",
                    Valid = sclResponse.Valid,
                    Message = sclResponse.Message
                });
            }
            return Ok(new ShipmentListResponse
            {
                Status = sclResponse.Status,
                Valid = sclResponse.Valid,
                Message = sclResponse.Message,
                ShipmentIds = sclResponse.ShipmentIds,
            });
        }

        [HttpPost]
        [Route("RetrieveTrackingSubjects")]
        public async Task<IActionResult> RetrieveTrackingSubjects(MobileRetrieveRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve tracking for subjects in mobile app- {JsonConvert.SerializeObject(mrData)}");
            var rResponse = await _mobileSubjectService.RetrieveTrackingSubjects(mrData);
            if (!rResponse.Valid)
            {
                return Unauthorized(new RetriveTrackingResponse
                {
                    Status = "false",
                    Valid = rResponse.Valid,
                    Message = rResponse.Message
                });
            }
            return Ok(new RetriveTrackingResponse
            {
                Status =rResponse.Status,
                Valid = rResponse.Valid,
                Message =rResponse.Message,
                Subjects = rResponse.Subjects,
            });
        }

    }
}
