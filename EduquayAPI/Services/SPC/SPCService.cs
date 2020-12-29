using EduquayAPI.Contracts.V1.Request.SPC;
using EduquayAPI.DataLayer.SPC;
using EduquayAPI.Models.SPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.SPC
{
    public class SPCService : ISPCService
    {
        private readonly ISPCData _spcData;

        public SPCService(ISPCDataFactory spcDataFactory) 
        {
            _spcData = new SPCDataFactory().Create();
        }
        public List<SPCPathoReports> RetrivePathologistReports(SPCPathoReportRequest prData)
        {
            var allSubject = _spcData.RetrivePathologistReports(prData);
            return allSubject;
        }
    }
}
