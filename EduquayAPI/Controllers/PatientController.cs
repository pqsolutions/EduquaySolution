using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        private readonly ILogger<PatientController> _logger;

        public PatientController(IPatientService patientService, ILogger<PatientController> logger)
        {
            _patientService = patientService;
            _logger = logger;
        }

        [HttpPost]
        [Route("AddPatient")]
        public ActionResult<ServiceResponse> AddPatient(Patient pdata)
        {
            try
            {

                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Adding patient data - {JsonConvert.SerializeObject(pdata)}");
                var patient = _patientService.AddPatient(pdata);
                if (patient == null)
                {
                    return NotFound();
                }

                _logger.LogInformation($"Patient data added successfully - {pdata}");
                return new ServiceResponse {Status = "true", Message = string.Empty, Result = patient};
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to update patient data - {ex.StackTrace}");
                return new ServiceResponse { Status = "true", Message = ex.Message, Result = "Failed to update patient data" };
            }
        }

        [HttpGet]
        [Route("GetPatients")]
        public PatientResponse GetPatients()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var patients = _patientService.GetPatients();
                _logger.LogInformation($"Received patient data {patients}");
                return patients.Count == 0 ? new PatientResponse { Status = "true", Message = "No patient found", Patients = new List<Patient>() } : new PatientResponse { Status = "true", Message = string.Empty, Patients = patients };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving patient data {e.StackTrace}");
                return new PatientResponse { Status = "false", Message = e.Message, Patients = null};
            }
        }

        [HttpGet]
        [Route("GetPatient/{pId}")]
        public PatientResponse GetPatient(int pId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}"); 
            try
            {
                var patients = _patientService.GetPatient(pId);
                _logger.LogInformation($"Received patient data {JsonConvert.SerializeObject(patients)}");
                return patients.Count == 0 ? new PatientResponse { Status = "true", Message = "No patient found", Patients = new List<Patient>() } : new PatientResponse { Status = "true", Message = string.Empty, Patients = patients };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving patient data {e.StackTrace}");
                return new PatientResponse { Status = "false", Message = e.Message, Patients = null };
            }
        }
    }
}