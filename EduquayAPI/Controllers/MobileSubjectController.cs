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
using EduquayAPI.Services.MobileSubject;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MobileSubjectController : ControllerBase
    {
        private readonly IMobileSubjectService _mobileSubjectService;
        private readonly ILogger<MobileSubjectController> _logger;
        public MobileSubjectController(IMobileSubjectService mobileSubjectService, ILogger<MobileSubjectController> logger)
        {
            _mobileSubjectService = mobileSubjectService;
            _logger = logger;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> AddSubjects(AddSubjectRequest subRegData)
        {
            try
            {
                var subject = _mobileSubjectService.AddSubject(subRegData);
                return string.IsNullOrEmpty(subject) ? $"Unable to generate the subject detail" : subject;
            }
            catch (Exception e)
            {
                return $"Unable to generate the subject detail - {e.Message}";
            }
        }

    }
}
