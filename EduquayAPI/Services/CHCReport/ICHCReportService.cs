using EduquayAPI.Contracts.V1.Request.CHCReports;
using EduquayAPI.Contracts.V1.Response.CHCReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCReport
{
    public interface ICHCReportService
    {
        Task<CHCReportsResponse> RetriveCHCReportsDetail(CHCReportRequest chcData);
    }
}
