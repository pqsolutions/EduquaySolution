using EduquayAPI.Contracts.V1.Request.NHMReport;
using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.NHMReport
{
    public interface INHMReportData
    {
        List<NHMReports> RetrieveNHMReportsSampling(NHMReportsRequest nhmData);
        List<NHMReports> RetrieveNHMReportsCHCDetails(NHMReportsRequest nhmData);
        List<NHMReports> RetrieveNHMReportsHPLCPathoDetails(NHMReportsRequest nhmData);
        List<NHMReports> RetrieveNHMReportsSpouseRegDetails(NHMReportsRequest nhmData);
        List<NHMReports> RetrieveNHMReportsPrePNDTCdetails(NHMReportsRequest nhmData);
        List<NHMReports> RetrieveNHMReportsPNDTDetails(NHMReportsRequest nhmData);
        List<NHMReports> RetrieveNHMReportsPostPNDTCDetails(NHMReportsRequest nhmData);
        List<NHMReports> RetrieveNHMReportsMTPDetails(NHMReportsRequest nhmData);
    }
    public interface INHMReportDataFactory
    {
        INHMReportData Create();
    }
    public class NHMReportDataFactory : INHMReportDataFactory
    {
        public INHMReportData Create()
        {
            return new NHMReportData();
        }
    }
}