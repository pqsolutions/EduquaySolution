using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Pathologist;
using EduquayAPI.Models.Pathologist;
using EduquayAPI.Services.Pathologist;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _config;
        public readonly IHostingEnvironment _hostingEnvironment;

        public PathologistController(IPathologistService pathologistService, ILogger<PathologistController> logger, IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            _pathologistService = pathologistService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _config = config;
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
        /// Used for get for edit  hplc diagnosis data which are not update their result
        /// </summary>
        [HttpGet]
        [Route("RetrieveEditHPLCDiagnosisDetail/{centralLabId}")]
        public async Task<IActionResult> GetdiagnosisList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var subjectList = await _pathologistService.EditHPLCDiagnosisDetail(centralLabId);
            _logger.LogInformation($"Received hplc diagnosis  details {subjectList}");
            return Ok(new HPLCDiagnosisDetailResponse
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

        /// <summary>
        /// Used for get sample status in  Diagnosis  
        /// </summary>
        [HttpGet]
        [Route("RetrieveDiagnosisSampleStatus")]
        public PathologistSampleStatusResponse GetSampleStatus()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var sampleStatus = _pathologistService.RetrieveSampleStatus();
                return sampleStatus.Count == 0 ? new PathologistSampleStatusResponse { Status = "true", Message = "No subjects found", sampleStatus = new List<PathologistSampleStatus>() }
                : new PathologistSampleStatusResponse { Status = "true", Message = string.Empty, sampleStatus = sampleStatus };
            }
            catch (Exception e)
            {
                return new PathologistSampleStatusResponse { Status = "false", Message = e.Message, sampleStatus = null };
            }
        }

        /// <summary>
        /// Used for get  reports for Pathologist result 
        /// </summary>
        [HttpPost]
        [Route("RetrievePathologistReports")]
        public PathoReportsResponse GetPathologistReports(PathoReportsRequest prData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for Pathologist diagnosis reports  - {JsonConvert.SerializeObject(prData)}");
                var subjects = _pathologistService.RetrivePathologistReports(prData);
                return subjects.Count == 0 ? new PathoReportsResponse { Status = "true", Message = "No subjects found", Subjects = new List<PathoReports>() }
                : new PathoReportsResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new PathoReportsResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Download HPLC Graph  
        /// </summary>

        [HttpPost]
        [Route("DownloadHPLCGraph")]
        public async Task<IActionResult> Download(string file)
        {
            var uploads = "";
            var hplcGraphLocation = _config.GetSection("Graph").GetSection("HPLCGraphFolder").Value;

            if (file.ToUpper() == "" || file.ToUpper() == null)
            {
                return BadRequest();
            }
            else
            {
                uploads = Path.Combine(_hostingEnvironment.WebRootPath + hplcGraphLocation);
              
            }
            var filePath = Path.Combine(uploads, file);
            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var memory = new MemoryStream();
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(filePath), file);
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }

    }
}