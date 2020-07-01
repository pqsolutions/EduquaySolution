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

namespace EduquayAPI.Controllers
{

    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddSubjects(SubjectRegistrationRequest subRegData)
        {
            try
            {               
                var subject = _subjectService.AddSubject(subRegData);
                return string.IsNullOrEmpty(subject) ? $"Unable to generate the subject detail" : subject;
            }
            catch (Exception e)
            {
                return $"Unable to generate the subject detail - {e.Message}";
            }
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

       
    }
}