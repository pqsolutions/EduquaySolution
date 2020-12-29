using EduquayAPI.Contracts.V1.Request.SPC;
using EduquayAPI.Models.SPC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.SPC
{
    public interface ISPCData
    {
        List<SPCPathoReports> RetrivePathologistReports(SPCPathoReportRequest prData);
    }
    public interface ISPCDataFactory
    {
        ISPCData Create();
    }
    public class SPCDataFactory : ISPCDataFactory
    {
        public ISPCData Create()
        {
            return new SPCData();
        }
    }
}
