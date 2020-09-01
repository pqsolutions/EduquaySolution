using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Response.PMMasters;
using EduquayAPI.Models.PMMaster;
using EduquayAPI.Services.PNDTandMTPMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class PNDTMTPMasterController : ControllerBase
    {
        private readonly IPMMasterService _pmMasterService;
        private readonly ILogger<PNDTMTPMasterController> _logger;
        public PNDTMTPMasterController(IPMMasterService pmMasterService, ILogger<PNDTMTPMasterController> logger)
        {
            _pmMasterService = pmMasterService;
            _logger = logger;
        }

        /// <summary>
        /// Used to fetch user District
        /// </summary>
        [HttpGet]
        [Route("RetrieveDistrict/{userId}")]
        public PMMasterResponse GetDistrict(int userId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve district by user- {JsonConvert.SerializeObject(userId)}");
                var pmMaster = _pmMasterService.GetUserDistrict(userId);
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

       
        /// <summary>
        /// Used to fetch user CHC by District
        /// </summary>
        [HttpGet]
        [Route("RetrieveCHC/{id}")]
        public PMMasterResponse GetCHC(int id)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve CHC by district- {JsonConvert.SerializeObject(id)}");
                var pmMaster = _pmMasterService.GetCHCbyDistrict(id);
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No chc found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch user PHC by CHC
        /// </summary>
        [HttpGet]
        [Route("RetrievePHC/{id}")]
        public PMMasterResponse GetPHC(int id)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve CHC by district- {JsonConvert.SerializeObject(id)}");
                var pmMaster = _pmMasterService.GetPHCbyCHC(id);
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No phc found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch user ANM by PHC
        /// </summary>
        [HttpGet]
        [Route("RetrieveANM/{id}")]
        public PMMasterResponse GetANM(int id)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve CHC by district- {JsonConvert.SerializeObject(id)}");
                var pmMaster = _pmMasterService.GetANMbyPHC(id);
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No anm found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch counsellor 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCounsellor")]
        public PMMasterResponse GetCounsellor()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var pmMaster = _pmMasterService.GetCounsellor();
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch PNDT Obstetrician 
        /// </summary>
        [HttpGet]
        [Route("RetrievePNDTObstetrician")]
        public PMMasterResponse GetPNDTObstetrician()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var pmMaster = _pmMasterService.GetPNDTObstetrician();
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch all District
        /// </summary>
        [HttpGet]
        [Route("RetrieveAllDistrict")]
        public PMMasterResponse GetAllDistrict()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var pmMaster = _pmMasterService.GetAllDistricts();
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }



        /// <summary>
        /// Used to fetch all Procedure of Testing
        /// </summary>
        [HttpGet]
        [Route("RetrieveProcedureOfTesting")]
        public PMMasterResponse GetAllPOT()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var pmMaster = _pmMasterService.GetAllProcedureofTesting();
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch all PNDT Complecations
        /// </summary>
        [HttpGet]
        [Route("RetrievePNDTComplecations")]
        public PMMasterResponse GetAllPNDTComplecations()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var pmMaster = _pmMasterService.GetAllPNDTComplecations();
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch all PNDT Diagnosis
        /// </summary>
        [HttpGet]
        [Route("RetrievePNDTDiagnosis")]
        public PMMasterResponse GetAllPNDTDiagnosis()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var pmMaster = _pmMasterService.GetAllPNDTDiagnosis();
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to fetch all PNDT Result
        /// </summary>
        [HttpGet]
        [Route("RetrievePNDTResult")]
        public PMMasterResponse GetAllPNDTResult()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var pmMaster = _pmMasterService.GetAllPNDTResultMaster();
                return pmMaster.Count == 0 ? new PMMasterResponse { Status = "true", Message = "No district found", data = new List<PMMaster>() } : new PMMasterResponse { Status = "true", Message = string.Empty, data = pmMaster };
            }
            catch (Exception e)
            {
                return new PMMasterResponse { Status = "false", Message = e.Message, data = null };
            }
        }
    }
}