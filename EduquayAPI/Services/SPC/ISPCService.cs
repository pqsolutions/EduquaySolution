using EduquayAPI.Contracts.V1.Request.SPC;
using EduquayAPI.Models.SPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.SPC
{
    public interface ISPCService
    {
        List<SPCPathoReports> RetrivePathologistReports(SPCPathoReportRequest prData);
    }
}
