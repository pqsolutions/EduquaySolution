using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.SPC;
using EduquayAPI.Contracts.V1.Response.SPC;
using EduquayAPI.Models.SPC;
using EduquayAPI.Services.SPC;
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
    public class SPCController : ControllerBase
    {
        private readonly ISPCService _spcService;
        private readonly ILogger<SPCController> _logger;
        public SPCController(ISPCService spcService, ILogger<SPCController> logger)
        {
            _spcService = spcService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get  reports for Pathologist result 
        /// </summary>
        [HttpPost]
        [Route("RetrieveDiagnosisReports")]
        public SPCPathoReportResponse RetrieveDiagnosisReports(SPCPathoReportRequest prData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for diagnosis reports  - {JsonConvert.SerializeObject(prData)}");
                var subjects = _spcService.RetrivePathologistReports(prData);
                return subjects.Count == 0 ? new SPCPathoReportResponse { Status = "true", Message = "No subjects found", Subjects = new List<SPCPathoReports>() }
                : new SPCPathoReportResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new SPCPathoReportResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }
    }
}
