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
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using EduquayAPI.Contracts.V1;
using System.Globalization;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class SampleCollectionController : ControllerBase
    {
        private readonly ISampleCollectionService _sampleCollectionService;
        private readonly ILogger<SampleCollectionController> _logger;

        public SampleCollectionController(ISampleCollectionService sampleCollectionService, ILogger<SampleCollectionController> logger)
        {
            _sampleCollectionService = sampleCollectionService;
            _logger = logger;
        }

        /// <summary>
        /// Used for fetch subject list not collected sample of particular ANM
        /// </summary>
        [HttpPost]
        [Route("Retrieve")]
        public SubjectSampleResponse GetSubjectList(SubjectSampleRequest ssData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var fromDate = "";
            var toDate = "";
            if (ssData.fromDate == "" || ssData.fromDate == null)
            {
                fromDate = DateTime.Now.AddYears(-1).ToString("dd/MM/yyyy");
            }
            else
            {
                fromDate = ssData.fromDate;
            }
            if (ssData.toDate == "" || ssData.toDate == null)
            {
                toDate = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                toDate = ssData.toDate;
            }
            try
            {
                var subjectList = _sampleCollectionService.Retrieve(ssData);
                _logger.LogInformation($"Received subject Data {subjectList}");
                return subjectList.Count == 0 ?
                    new SubjectSampleResponse { Status = "true", Message = "No subjects found", fromDate = fromDate, toDate = toDate, SubjectList = new List<SubjectSamples>() }
                    : new SubjectSampleResponse { Status = "true", Message = string.Empty, fromDate = fromDate, toDate = toDate, SubjectList = subjectList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving subject data {e.StackTrace}");
                return new SubjectSampleResponse { Status = "false", Message = e.Message, fromDate = fromDate, toDate = toDate, SubjectList = null };
            }
        }

        /// <summary>
        /// Used for collect the samples of particular subject
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddSample(AddSubjectSampleRequest ssData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Collecting sample of subject - {JsonConvert.SerializeObject(ssData)}");
            var subjectSample = await _sampleCollectionService.AddSample(ssData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }
    }
}