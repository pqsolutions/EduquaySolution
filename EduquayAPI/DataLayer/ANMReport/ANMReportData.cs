using EduquayAPI.Contracts.V1.Request.ANMReports;
using EduquayAPI.Models.ANMReport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMReport
{
    public class ANMReportData : IANMReportData
    {
        private const string ANMSamplingReport = "SPC_ANMSamplingReport";
        private const string ANMShipmentReport = "SPC_ANMShipmentReport";
        private const string ANMReCollectionReport = "SPC_ANMReCollectionReport";
        private const string ANMCHCReport = "SPC_ANMCHCReport";
        private const string ANMHPLCReport = "SPC_ANMHPLCReport";
        private const string ANMPNDTCReport = "SPC_ANMPNDTCReport";
        private const string ANMPNDTReport = "SPC_ANMPNDTReport";
        private const string ANMPostPNDTCReport = "SPC_ANMPostPNDTCReport";
        private const string ANMMTPReport = "SPC_ANMMTPReport";


        public List<ANMReports> RetrieveANMReportsCHC(ANMReportRequest anmData)
        {
            string stProc = ANMCHCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsHPLC(ANMReportRequest anmData)
        {
            string stProc = ANMHPLCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsMTP(ANMReportRequest anmData)
        {
            string stProc = ANMMTPReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsPNDT(ANMReportRequest anmData)
        {
            string stProc = ANMPNDTReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsPostPNDTC(ANMReportRequest anmData)
        {
            string stProc = ANMPostPNDTCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsPrePNDTC(ANMReportRequest anmData)
        {
            string stProc = ANMPNDTCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsSampling(ANMReportRequest anmData)
        {
            string stProc = ANMSamplingReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsShipment(ANMReportRequest anmData)
        {
            string stProc = ANMShipmentReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }

        public List<ANMReports> RetrieveANMReportsTimeoutDamaged(ANMReportRequest anmData)
        {
            string stProc = ANMReCollectionReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", anmData.fromDate),
                new SqlParameter("@ToDate", anmData.toDate),
                new SqlParameter("@ANMID", anmData.userId),
                new SqlParameter("@RIID", anmData.riId),
                new SqlParameter("@SubjectType", anmData.subjectTypeId),
                new SqlParameter("@Status", anmData.status)
            };
            var allData = UtilityDL.FillData<ANMReports>(stProc, pList);
            return allData;
        }
    }
}
