using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SentinelAPI.Contracts.V1.Request.SampleCollection;
using SentinelAPI.Contracts.V1.Response;
using SentinelAPI.Contracts.V1.Response.SampleCollection;
using SentinelAPI.Models.SampleCollection;
using SentinelAPI.Services.SampleCollection;

namespace SentinelAPI.Controllers
{
    [Route("api/[controller]")]
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
        /// Used for fetch infant subject list not collected sample
        /// </summary>
        [HttpPost]
        [Route("RetrieveInfantList")]
        public InfantSubjectResponse GetInfantSubjectList(SampleCollectionRequest scData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var fromDate = "";
            var toDate = "";
            if (scData.fromDate == "" || scData.fromDate == null)
            {
                fromDate = DateTime.Now.AddYears(-1).ToString("dd/MM/yyyy");
            }
            else
            {
                fromDate = scData.fromDate;
            }
            if (scData.toDate == "" || scData.toDate == null)
            {
                toDate = DateTime.Now.ToString("dd/MM/yyyy");
            }
            else
            {
                toDate = scData.toDate;
            }
            try
            {
                var subjectList = _sampleCollectionService.RetriveInfantList(scData);
                _logger.LogInformation($"Received infant subject Data {subjectList}");
                return subjectList.Count == 0 ?
                    new InfantSubjectResponse { status = "true", message = "No subjects found", fromDate = fromDate, toDate = toDate, infantList = new List<SampleCollectionList>() }
                    : new InfantSubjectResponse { status = "true", message = string.Empty, fromDate = fromDate, toDate = toDate, infantList = subjectList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving infant subject data {e.StackTrace}");
                return new InfantSubjectResponse { status = "false", message = e.Message, fromDate = fromDate, toDate = toDate, infantList = null };
            }
        }

        /// <summary>
        /// Used for collect the samples of particular subject
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddSample(AddSampleCollectionRequest scData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Collecting sample of subject - {JsonConvert.SerializeObject(scData)}");
            var subjectSample = await _sampleCollectionService.AddSample(scData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }
    }
}