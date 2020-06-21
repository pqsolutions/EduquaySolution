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
                fromDate = DateTime.Now.AddDays(-5).ToString("dd/MM/yyyy");
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
                _logger.LogInformation($"Received Subject Data {subjectList}");
                return subjectList.Count == 0 ? 
                    new SubjectSampleResponse { Status = "true", Message = "No subjects found", fromDate = fromDate , toDate = toDate, SubjectList = new List<SubjectSamples>() } 
                    : new SubjectSampleResponse { Status = "true", Message = string.Empty, fromDate = fromDate, toDate = toDate, SubjectList = subjectList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving subject data {e.StackTrace}");
                return new SubjectSampleResponse { Status = "false", Message = e.Message, fromDate = fromDate, toDate = toDate, SubjectList = null };
            }
        }


        /// <summary>
        /// Used for fetch detail of sparticular subject for collect the sample in ANM / CHC
        /// </summary>
        [HttpPost]
        [Route("RetrieveSubjects")]
        public SampleSubjectResponse GetSubject(SampleSubjectRequest ssData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var subjectDetail = _sampleCollectionService.Retrieve(ssData);
                _logger.LogInformation($"Received Subject Data {subjectDetail}");
                return subjectDetail.Count == 0 ? new SampleSubjectResponse { Status = "true", Message = "No subject found", SubjectDetail = new List<SampleSubject>() } : new SampleSubjectResponse { Status = "true", Message = string.Empty, SubjectDetail = subjectDetail };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving subject data {e.StackTrace}");
                return new SampleSubjectResponse { Status = "false", Message = e.Message, SubjectDetail = null };
            }
        }


        /// <summary>
        /// Used for collect the samples of particular subject
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public ActionResult<ServiceResponse> AddSample(AddSubjectSampleRequest ssData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Collecting sample of subject - {JsonConvert.SerializeObject(ssData)}");
                var subjectSample = _sampleCollectionService.AddSample(ssData);
                if (subjectSample == null)
                {
                    return NotFound();
                }
                _logger.LogInformation($"Sample collected Successfully - {ssData.uniqueSubjectId}");
                return new ServiceResponse { Status = "true", Message = string.Empty, Result = subjectSample };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to collect sample  - {ex.StackTrace}");
                return new ServiceResponse { Status = "true", Message = ex.Message, Result = "Failed to collect sample" };
            }
        }
    }
}