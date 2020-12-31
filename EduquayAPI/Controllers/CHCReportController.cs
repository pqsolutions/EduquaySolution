using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.CHCReports;
using EduquayAPI.Contracts.V1.Response.CHCReport;
using EduquayAPI.Services.CHCReport;
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
    public class CHCReportController : ControllerBase
    {
        private readonly ICHCReportService _chcReportsService;
        private readonly ILogger<CHCReportController> _logger;
        public CHCReportController(ICHCReportService chcReportsService, ILogger<CHCReportController> logger)
        {
            _chcReportsService = chcReportsService;
            _logger = logger;
        }

        /// <summary>
        /// Used to fetch subjects detail for chc reports
        /// </summary>
        [HttpPost]
        [Route("CHCReportsDetail")]
        public async Task<IActionResult> RetrieveSubjectsForCHCReports(CHCReportRequest chcData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve subject detail for chc report- {JsonConvert.SerializeObject(chcData)}");
            var chcReports = await _chcReportsService.RetriveCHCReportsDetail(chcData);
            _logger.LogInformation($"Fetch Subjects for chc reports {chcReports}");
            return Ok(new CHCReportsResponse
            {
                status = chcReports.status,
                message = chcReports.message,
                data = chcReports.data,
            });
        }
    }
}
