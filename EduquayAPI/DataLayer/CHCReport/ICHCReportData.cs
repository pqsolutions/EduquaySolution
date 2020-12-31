using EduquayAPI.Contracts.V1.Request.CHCReports;
using EduquayAPI.Models.CHCReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCReport
{
    public interface ICHCReportData
    {
        List<CHCReports> RetrieveCHCReportsSampling(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsShipment(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsTimeoutDamaged(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsCHC(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsHPLC(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsPrePNDTC(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsPNDT(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsPostPNDTC(CHCReportRequest chcData);
        List<CHCReports> RetrieveCHCReportsMTP(CHCReportRequest chcData);
    }
    public interface ICHCReportDataFactory
    {
        ICHCReportData Create();
    }
    public class CHCReportDataFactory : ICHCReportDataFactory
    {
        public ICHCReportData Create()
        {
            return new CHCReportData();
        }
    }
}
