using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Contracts.V1.Response.CHCNotifications;
using EduquayAPI.Models.CHCNotifications;
using EduquayAPI.Services.CHCNotifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

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
    }
}