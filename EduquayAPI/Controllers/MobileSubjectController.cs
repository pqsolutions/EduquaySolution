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
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;

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

        //[HttpPost]
        //[Route("Add")]
        //public ActionResult<string> AddSubjects(AddSubjectRequest subRegData)
        //{
        //    try
        //    {
        //        var subject = _mobileSubjectService.AddSubject(subRegData);
        //        return string.IsNullOrEmpty(subject) ? $"Unable to generate the subject detail" : subject;
        //    }
        //    catch (Exception e)
        //    {
        //        return $"Unable to generate the subject detail - {e.Message}";
        //    }
        //}


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddMultipleSubjects(AddSubjectRequest subRegData)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(new AuthFailedResponse
            //    {
            //        Status = false,
            //        Errors = ModelState.Values.SelectMany(x => x.Errors.Select(xx => xx.ErrorMessage))
            //    });
            //}
            var subRegResponse = await _mobileSubjectService.AddSubjectRegistration(subRegData);

            return Ok(new SubRegSuccessResponse
            {
                Status = subRegResponse.Status,
                Message = subRegResponse.Message,
                UniqueSubjectId = subRegResponse.UniqueSubjectId,
            }); ;
        }
    }
}
