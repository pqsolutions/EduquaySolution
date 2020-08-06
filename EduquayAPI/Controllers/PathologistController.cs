using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.Models.Pathologist;
using EduquayAPI.Services.Pathologist;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
        /// Used for get hplc test data which are not update their result
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

        /// <summary>
        /// Used for get hplc result master 
        /// </summary>
        [HttpGet]
        [Route("HPLCResultMaster")]
        public HPLCResultMasterResponse GetHPLCMaster()
        {
            try
            {
                var hplcResult = _pathologistService.HPLCResult();
                return hplcResult.Count == 0 ? new HPLCResultMasterResponse { Status = "true", Message = "No hplc result master data found", hplcResults = new List<HPLCResult>() } 
                : new HPLCResultMasterResponse { Status = "true", Message = string.Empty, hplcResults = hplcResult };
            }
            catch (Exception e)
            {
                return new HPLCResultMasterResponse { Status = "false", Message = e.Message, hplcResults = null };
            }
        }

        /// <summary>
        /// Used for  Add the new sample recollection of subject which are damaged sample or timout expiry sample
        /// </summary>
        [HttpPost]
        [Route("AddHPLCDiagnosisResult")]
        public async Task<IActionResult> AddHPLCDiagnosisResult(AddHPLCDiagnosisResultRequest aData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding hplc diagnosis results data - {JsonConvert.SerializeObject(aData)}");
            var hplcDiagnosis = await _pathologistService.AddHPLCDiagnosisResult(aData);
            return Ok(new ServiceResponse
            {
                Status = hplcDiagnosis.Status,
                Message = hplcDiagnosis.Message,
            });
        }
    }
}