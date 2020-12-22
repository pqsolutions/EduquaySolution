using EduquayAPI.Contracts.V1.Request.NHMReport;
using EduquayAPI.Contracts.V1.Response.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.NHMReport
{
    public interface INHMReportService
    {
        Task<NHMReportResponse> RetriveNHMReportsDetail(NHMReportsRequest nhmData);
    }
}
