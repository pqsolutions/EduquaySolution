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
using EduquayAPI.Contracts.V1;
using Microsoft.AspNetCore.Http.Extensions;
using EduquayAPI.Contracts.V1.Response.MobileSubject;

namespace EduquayAPI.Controllers
{

    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ILogger<SubjectController> _logger;

        public SubjectController(ISubjectService subjectService, ILogger<SubjectController> logger)
        {
            _subjectService = subjectService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddSubjects(SubjectRegistrationRequest subRegData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Registered subjects - {JsonConvert.SerializeObject(subRegData)}");
           
            var subject = await _subjectService.AddSubject(subRegData);

            return Ok(new UniqueIdDetail
            {
                status = subject.status,
                message = subject.message,
                uniqueSubjectId = subject.uniqueSubjectId,
            });
        }

        [HttpPost]
        [Route("RetrieveSubjectList")]
        public async Task<IActionResult> RetrieveSubjectList(SubjectDetailRequest sdData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var subRegListResponse = await _subjectService.RetrieveSubjectDetail(sdData);

            return Ok(new  SubjectRegistrationResponse
            {
                Status = subRegListResponse.Status,
                Message = subRegListResponse.Message,
                SubjectsDetail = subRegListResponse.SubjectsDetail,
            });
        }

        [HttpPost]
        [Route("RetrieveParticularSubjectList")]
        public async Task<IActionResult> RetrieveParticularSubjectList(SubjectsDetailRequest sdData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var subRegListResponse = await _subjectService.RetrieveParticularSubjectDetail(sdData);

            return Ok(new SubjectRegistrationResponse
            {
                Status = subRegListResponse.Status,
                Message = subRegListResponse.Message,
                SubjectsDetail = subRegListResponse.SubjectsDetail,
            });
        }

        [HttpPost]
        [Route("RetrieveCHCSubjectList")]
        public async Task<IActionResult> RetrieveCHCSubjectList(SubjectDetailRequest sdData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var subRegListResponse = await _subjectService.RetrieveCHCSubjectDetail(sdData);

            return Ok(new SubjectRegistrationResponse
            {
                Status = subRegListResponse.Status,
                Message = subRegListResponse.Message,
                SubjectsDetail = subRegListResponse.SubjectsDetail,
            });
        }

        [HttpPost]
        [Route("RetrieveParticularCHCSubjectList")]
        public async Task<IActionResult> RetrieveParticularCHCSubjectList(SubjectsDetailRequest sdData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var subRegListResponse = await _subjectService.RetrieveParticularCHCSubjectDetail(sdData);

            return Ok(new SubjectRegistrationResponse
            {
                Status = subRegListResponse.Status,
                Message = subRegListResponse.Message,
                SubjectsDetail = subRegListResponse.SubjectsDetail,
            });
        }

        [HttpPost]
        [Route("RetrieveANWSubjects")]
        public ANWSubjectResponse GetANWSubject(ANWSubjectRequest asData)
        {
            try
            {
                var anwSubjects = _subjectService.RetrieveANWDetail(asData);
                return anwSubjects.Count == 0 ?
                    new ANWSubjectResponse { Status = "false", Message = "No subject found", ANWSubjects = new List<ANWSubjectDetail>() }
                    : new ANWSubjectResponse { Status = "true", Message = string.Empty, ANWSubjects = anwSubjects };
            }
            catch (Exception e)
            {
                return new ANWSubjectResponse { Status = "false", Message = e.Message, ANWSubjects = null };
            }
        }


        [HttpPost]
        [Route("RetrieveCHCANWPositiveSubjects")]
        public CHCANWSubjectResponse GetCHCANWSubject(CHCANWSubjectRequest casData)
        {
            try
            {
                var anwSubjects = _subjectService.RetrieveCHCANWDetail(casData);
                return anwSubjects.Count == 0 ?
                    new CHCANWSubjectResponse { Status = "false", Message = "No subject found", ANWPositiveSubjects = new List<CHCANWSubjectDetail>() }
                    : new CHCANWSubjectResponse { Status = "true", Message = string.Empty, ANWPositiveSubjects = anwSubjects };
            }
            catch (Exception e)
            {
                return new CHCANWSubjectResponse { Status = "false", Message = e.Message, ANWPositiveSubjects = null };
            }
        }
    }
}