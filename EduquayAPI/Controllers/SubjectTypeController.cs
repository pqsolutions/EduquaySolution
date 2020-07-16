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

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubjectTypeController : ControllerBase
    {
        private readonly ISubjectTypeService _subjectTypeService;

        public SubjectTypeController(ISubjectTypeService subjectTypeService)
        {
            _subjectTypeService = subjectTypeService;
        }

        [HttpPost]
        [Route("Add")]
        public ActionResult<string> Add(SubjectTypeRequest stData)
        {
            try
            { 
                var subjectType = _subjectTypeService.Add(stData);
                return string.IsNullOrEmpty(subjectType) ? $"Unable to add subject type data" : subjectType;
            }
            catch (Exception e)
            {
                return $"Unable to add subject type data - {e.Message}";
            }
        }

        [HttpGet]
        [Route("Retrieve")]
        public SubjectTypeResponse GetSubjectTypes()
        {
            try
            {
                var subjectTypes = _subjectTypeService.Retrieve();
                return subjectTypes.Count == 0 ? new SubjectTypeResponse { Status = "true", Message = "No subject type found", SubjectTypes = new List<SubjectType>() } : new SubjectTypeResponse { Status = "true", Message = string.Empty, SubjectTypes = subjectTypes };
            }
            catch (Exception e)
            {
                return new SubjectTypeResponse { Status = "false", Message = e.Message, SubjectTypes = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public SubjectTypeResponse GetSubjectType(int code)
        {
            try
            {
                var subjectTypes = _subjectTypeService.Retrieve(code);
                return subjectTypes.Count == 0 ? new SubjectTypeResponse { Status = "true", Message = "No subject type found", SubjectTypes = new List<SubjectType>() } : new SubjectTypeResponse { Status = "true", Message = string.Empty, SubjectTypes = subjectTypes };
            }
            catch (Exception e)
            {
                return new SubjectTypeResponse { Status = "false", Message = e.Message, SubjectTypes = null };
            }
        }



    }
}