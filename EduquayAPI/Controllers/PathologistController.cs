using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.Services.Pathologist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class PathologistController : ControllerBase
    {
        private readonly IPathologistService _pathologistService;
        private readonly ILogger<PathologistController> _logger;

        public PathologistController(IPathologistService pathologistService, ILogger<PathologistController> logger)
        {
            _pathologistService = pathologistService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get hplc  test data which are not update their result
        /// </summary>
        [HttpGet]
        [Route("RetrieveHPLCTestDetail/{centralLabId}")]
        public async Task<IActionResult> GetSampleList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var subjectList = await _pathologistService.HPLCResultDetail(centralLabId);
            _logger.LogInformation($"Received hplc test details {subjectList}");
            return Ok(new HPLCTestDetailResponse
            {
                Status = subjectList.Status,
                Message = subjectList.Message,
                SubjectDetails = subjectList.SubjectDetails,
            });
        }
    }
}