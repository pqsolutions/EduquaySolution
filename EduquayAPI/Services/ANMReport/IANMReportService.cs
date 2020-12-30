using EduquayAPI.Contracts.V1.Request.ANMReports;
using EduquayAPI.Contracts.V1.Response.ANMReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMReport
{
    public interface IANMReportService
    {
        Task<ANMReportResponse> RetriveANMReportsDetail(ANMReportRequest anmData);
    }
}
