using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.MolecularLab;
using EduquayAPI.Models.MolecularLab;
using EduquayAPI.Services.MolLabResultProcess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MLResultProcessController : ControllerBase
    {
        private readonly IMLResultProcessService _mlResultProcessService;
        private readonly ILogger<MLResultProcessController> _logger;

        public MLResultProcessController(IMLResultProcessService mlResultProcessService, ILogger<MLResultProcessController> logger)
        {
            _mlResultProcessService = mlResultProcessService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get  received Blood samples  for molecular test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveBloodSamples/{molecularLabId}")]
        public MolecularLabSubjectResponse RetrieveBloodSamples(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular blood test  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _mlResultProcessService.RetriveSubjectForMolecularBloodTest(molecularLabId);
                return subjects.Count == 0 ? new MolecularLabSubjectResponse { Status = "true", Message = "No subjects found", Subjects = new List<MolecularSubjectsForTest>() }
                : new MolecularLabSubjectResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new MolecularLabSubjectResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get  received Blood samples  for molecular test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveBloodTestEdit/{molecularLabId}")]
        public FetchMLBloodTestEditCompleteResponse RetrieveBloodSamplesEdit(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular blood test complete  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _mlResultProcessService.RetriveSubjectForMolecularBloodTestEdit(molecularLabId);
                return subjects.Count == 0 ? new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = "No subjects found", Subjects = new List<MolecularSubjectsForBloodTestStatus>() }
                : new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new FetchMLBloodTestEditCompleteResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get  received Blood samples  for molecular test Complete
        /// </summary>
        [HttpGet]
        [Route("RetrieveBloodTestComplete/{molecularLabId}")]
        public FetchMLBloodTestEditCompleteResponse RetrieveBloodSamplesComplete(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular blood test complete  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _mlResultProcessService.RetriveSubjectForMolecularBloodTestComplete(molecularLabId);
                return subjects.Count == 0 ? new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = "No subjects found", Subjects = new List<MolecularSubjectsForBloodTestStatus>() }
                : new FetchMLBloodTestEditCompleteResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new FetchMLBloodTestEditCompleteResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

       

        /// <summary>
        /// Used for add to update the molecular blood test result 
        /// </summary>
        [HttpPost]
        [Route("AddMolecularBloodTestResult")]
        public async Task<IActionResult> AddMolecularBloodTestResult(AddBloodSampleTestRequest mrRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Blood samples to update molecular test result - {JsonConvert.SerializeObject(mrRequest)}");
            var rsResponse = await _mlResultProcessService.AddMolecularBloodResult(mrRequest);

            return Ok(new ServiceResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Used for get  received specimen samples for molecular test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveSpecimenSamples/{molecularLabId}")]
        public FetchMLabSpecimenSubjectResponse RetrieveSpecimenSubjects(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular specimen test  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _mlResultProcessService.RetriveSpecimenSubjectForMolecularTest(molecularLabId);
                return subjects.Count == 0 ? new FetchMLabSpecimenSubjectResponse { Status = "true", Message = "No subjects found", Subjects = new List<MLabSpecimenForTest>() }
                : new FetchMLabSpecimenSubjectResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new FetchMLabSpecimenSubjectResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }


        /// <summary>
        /// Used for get  specimen samples for molecular Edit test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveSpecimenTestEdit/{molecularLabId}")]
        public FetchMLSpecimenEditCompleteResponse RetrieveSpecimenSubjectsEdit(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular specimen test edit  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _mlResultProcessService.RetriveSpecimenForMolecularEditTest(molecularLabId);
                return subjects.Count == 0 ? new FetchMLSpecimenEditCompleteResponse { Status = "true", Message = "No subjects found", Subjects = new List<MLabSpecimenForTestStatus>() }
                : new FetchMLSpecimenEditCompleteResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new FetchMLSpecimenEditCompleteResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get  specimen samples for molecular Complete test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveSpecimenTestCompleted/{molecularLabId}")]
        public FetchMLSpecimenEditCompleteResponse RetrieveSpecimenSubjectsCompleted(int molecularLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular specimen test Complete  - {JsonConvert.SerializeObject(molecularLabId)}");
                var subjects = _mlResultProcessService.RetriveSpecimenForMolecularTestComplete(molecularLabId);
                return subjects.Count == 0 ? new FetchMLSpecimenEditCompleteResponse { Status = "true", Message = "No subjects found", Subjects = new List<MLabSpecimenForTestStatus>() }
                : new FetchMLSpecimenEditCompleteResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new FetchMLSpecimenEditCompleteResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for add to update the molecular Specimen test result 
        /// </summary>
        [HttpPost]
        [Route("AddMolecularSpecimenTestResult")]
        public async Task<IActionResult> AddMolecularSpecimenResult(AddSpecimenSampleTestRequest mrRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Specimen samples to update molecular test result - {JsonConvert.SerializeObject(mrRequest)}");
            var rsResponse = await _mlResultProcessService.AddSpecimenSamplesTestResult(mrRequest);

            return Ok(new ServiceResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Used for get  received Blood samples  for molecular test reports
        /// </summary>
        [HttpPost]
        [Route("RetrieveBloodTestReports")]
        public MolecularLabBloodTestReportsResponse RetrieveBloodTestReports(MolecularLabReportRequest rData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for molecular blood test report  - {JsonConvert.SerializeObject(rData)}");
                var subjects = _mlResultProcessService.RetriveSubjectForMolecularBloodTestReports(rData);
                return subjects.Count == 0 ? new MolecularLabBloodTestReportsResponse { Status = "true", Message = "No subjects found", data = new List<MolecularLabBloodReport>() }
                : new MolecularLabBloodTestReportsResponse { Status = "true", Message = string.Empty, data = subjects };
            }
            catch (Exception e)
            {
                return new MolecularLabBloodTestReportsResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for specimens Test Reports 
        [HttpPost]
        [Route("RetrieveSpecimenTestReports")]
        public async Task<IActionResult> RetrieveSpecimenTestReports(MolecularLabReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var response = await _mlResultProcessService.RetriveSubjectForMolecularSpecimenTestReports(rData);
            _logger.LogInformation($"get Specimen detail report {response}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(response)}");

            return Ok(new SpecimenReportResponse
            {
                Status = response.Status,
                Message = response.Message,
                data = response.data,
            });
        }

    }
}
