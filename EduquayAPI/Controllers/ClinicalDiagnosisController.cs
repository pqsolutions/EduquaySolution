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
using EduquayAPI.Contracts.V1.Response.Masters;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ClinicalDiagnosisController : ControllerBase
    {
        private readonly IClinicalDiagnosisService _clinicalDiagnosisService;
        public ClinicalDiagnosisController(IClinicalDiagnosisService clinicalDiagnosisService)
        {
            _clinicalDiagnosisService = clinicalDiagnosisService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(ClinicalDiagnosisRequest cdData)
        {
            var addEditResponse = await _clinicalDiagnosisService.Add(cdData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }


        [HttpGet]
        [Route("Retrieve")]
        public ClinicalDiagnosisResponse GetClinicalDiagnosises()
        {
            try
            {
                var clinicalDiagnosis = _clinicalDiagnosisService.Retrieve();
                return clinicalDiagnosis.Count == 0 ? new ClinicalDiagnosisResponse { Status = "true", Message = "No clinical diagnosis found", Diagnosis = new List<ClinicalDiagnosis>() } : new ClinicalDiagnosisResponse { Status = "true", Message = string.Empty, Diagnosis = clinicalDiagnosis };
            }
            catch (Exception e)
            {
                return new ClinicalDiagnosisResponse { Status = "false", Message = e.Message, Diagnosis = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public ClinicalDiagnosisResponse GetClinicalDiagnosis(int code)
        {
            try
            {
                var clinicalDiagnosis = _clinicalDiagnosisService.Retrieve(code);
                return clinicalDiagnosis.Count == 0 ? new ClinicalDiagnosisResponse { Status = "true", Message = "No clinical diagnosis found", Diagnosis = new List<ClinicalDiagnosis>() } : new ClinicalDiagnosisResponse { Status = "true", Message = string.Empty, Diagnosis = clinicalDiagnosis };
            }
            catch (Exception e)
            {
                return new ClinicalDiagnosisResponse { Status = "false", Message = e.Message, Diagnosis = null };
            }
        }
    }
}