using EduquayAPI.Contracts.V1.Request.ANMReports;
using EduquayAPI.Models.ANMReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMReport
{
    public interface IANMReportData
    {
        List<ANMReports> RetrieveANMReportsSampling(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsShipment(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsTimeoutDamaged(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsCHC(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsHPLC(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsPrePNDTC(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsPNDT(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsPostPNDTC(ANMReportRequest anmData);
        List<ANMReports> RetrieveANMReportsMTP(ANMReportRequest anmData);
    }
    public interface IANMReportDataFactory
    {
        IANMReportData Create();
    }
    public class ANMReportDataFactory : IANMReportDataFactory
    {
        public IANMReportData Create()
        {
            return new ANMReportData();
        }
    }
}
