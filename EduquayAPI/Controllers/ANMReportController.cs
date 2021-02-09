using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.ANMReports;
using EduquayAPI.Contracts.V1.Response.ANMReport;
using EduquayAPI.Services.ANMReport;
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
    public class ANMReportController : ControllerBase
    {
        private readonly IANMReportService _anmReportsService;
        private readonly ILogger<ANMReportController> _logger;
        public ANMReportController(IANMReportService anmReportsService, ILogger<ANMReportController> logger)
        {
            _anmReportsService = anmReportsService;
            _logger = logger;
        }

        /// <summary>
        /// Used to fetch subjects detail for anm reports
        /// </summary>
        [HttpPost]
        [Route("ANMReportsDetail")]
        public async Task<IActionResult> RetrieveSubjectsForANMReports(ANMReportRequest anmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Retrieve subject detail for anm report- {JsonConvert.SerializeObject(anmData)}");
            var anmReports = await _anmReportsService.RetriveANMReportsDetail(anmData);
            _logger.LogInformation($"Fetch Subjects for anm reports {anmReports}");
            _logger.LogDebug($"Response - Retrieve subject detail for anm report- {JsonConvert.SerializeObject(anmReports)}");
            return Ok(new ANMReportResponse
            {
                status = anmReports.status,
                message = anmReports.message,
                data = anmReports.data,
            });
        }

    }
}
