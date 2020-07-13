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
            _logger.LogDebug($"Register multiple subjects in Mobile App- {JsonConvert.SerializeObject(subRegData)}");
           
            var subject = await _subjectService.AddSubject(subRegData);

            return Ok(new UniqueIdDetail
            {
                status = subject.status,
                message = subject.message,
                uniqueSubjectId = subject.uniqueSubjectId,
            });
        }

        [HttpPost]
        [Route("Retrieve")]
        public SubjectRegistrationResponse GetSubject(SubjectRequest sData)
        {
            try
            {
                var subjecPrimary = _subjectService.RetrievePrimaryDetail(sData);
                var subjectAddress = _subjectService.RetrieveAddressDetail(sData);
                var subjectPregnancy = _subjectService.RetrievePregnancyDetail(sData);
                var subjectParent = _subjectService.RetrieveParentDetail(sData);


                return subjecPrimary.Count == 0 && subjectAddress.Count == 0 && subjectPregnancy.Count == 0 && subjectParent.Count == 0 ?
                    new SubjectRegistrationResponse { Status = "true", Message = "No Subject found", primaryDetail = new List<SubjectPrimaryDetail>(), addressDetail = new List<SubjectAddresDetail>(), pregnancyDetail = new List<SubjectPregnancyDetail>() , parentDetail = new List<SubjectParentDetail>() } 
                    : new SubjectRegistrationResponse { Status = "true", Message = string.Empty, primaryDetail = subjecPrimary , addressDetail = subjectAddress , pregnancyDetail = subjectPregnancy , parentDetail = subjectParent };
            }
            catch (Exception e)
            {
                return new SubjectRegistrationResponse { Status = "false", Message = e.Message, primaryDetail = null , addressDetail = null , pregnancyDetail = null , parentDetail = null };
            }
        }

        [HttpPost]
        [Route("RetrieveANWSubjects")]
        public ANWSubjectResponse GetANWSubject(ANWSubjectRequest asData)
        {
            try
            {
                var anwSubjects = _subjectService.RetrieveANWDetail(asData);
                return anwSubjects.Count == 0 ?
                    new ANWSubjectResponse { Status = "false", Message = "No Subject found", ANWSubjects = new List<ANWSubjectDetail>() }
                    : new ANWSubjectResponse { Status = "true", Message = string.Empty, ANWSubjects = anwSubjects };
            }
            catch (Exception e)
            {
                return new ANWSubjectResponse { Status = "false", Message = e.Message, ANWSubjects = null };
            }
        }
    }
}