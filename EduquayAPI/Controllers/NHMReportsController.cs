using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.NHMReport;
using EduquayAPI.Contracts.V1.Response.Reports;
using EduquayAPI.Services.NHMReport;
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
    public class NHMReportsController : ControllerBase
    {
        private readonly INHMReportService _nhmReportsService;
        private readonly ILogger<NHMReportsController> _logger;
        public NHMReportsController(INHMReportService nhmReportsService, ILogger<NHMReportsController> logger)
        {
            _nhmReportsService = nhmReportsService;
            _logger = logger;
        }

        /// <summary>
        /// Used to fetch subjects detail for nhm reports
        /// </summary>
        [HttpPost]
        [Route("NHMReportsDetail")]
        public async Task<IActionResult> RetrieveSubjectsForNHMReports(NHMReportsRequest nhmData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve subject detail for nhm report- {JsonConvert.SerializeObject(nhmData)}");
            var nhmReports = await _nhmReportsService.RetriveNHMReportsDetail(nhmData);
            _logger.LogInformation($"Fetch Subjects for nhm reports {nhmReports}");
            return Ok(new NHMReportResponse
            {
                status = nhmReports.status,
                message = nhmReports.message,
                data = nhmReports.data,
            });
        }
    }
}
