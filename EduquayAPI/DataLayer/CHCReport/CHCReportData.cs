using EduquayAPI.Contracts.V1.Request.CHCReports;
using EduquayAPI.Models.CHCReport;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCReport
{
    public class CHCReportData : ICHCReportData
    {
        private const string CHCSamplingReport = "SPC_CHCSamplingReport";
        private const string CHCShipmentReport = "SPC_CHCShipmentReport";
        private const string CHCsCHCReport = "SPC_CHCsCHCReport";
        private const string CHCsHPLCReport = "SPC_CHCsHPLCReport";
        private const string CHCReCollectionReport = "SPC_CHCReCollectionReport";
        private const string CHCPNDTCReport = "SPC_CHCPNDTCReport";
        private const string CHCPNDTReport = "SPC_CHCPNDTReport";
        private const string CHCPostPNDTCReport = "SPC_CHCPostPNDTCReport";
        private const string CHCMTPReport = "SPC_CHCMTPReport";
        public List<CHCReports> RetrieveCHCReportsCHC(CHCReportRequest chcData)
        {
            string stProc = CHCsCHCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsHPLC(CHCReportRequest chcData)
        {
            string stProc = CHCsHPLCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsMTP(CHCReportRequest chcData)
        {
            string stProc = CHCMTPReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsPNDT(CHCReportRequest chcData)
        {
            string stProc = CHCPNDTReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsPostPNDTC(CHCReportRequest chcData)
        {
            string stProc = CHCPostPNDTCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsPrePNDTC(CHCReportRequest chcData)
        {
            string stProc = CHCPNDTCReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsSampling(CHCReportRequest chcData)
        {
            string stProc = CHCSamplingReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsShipment(CHCReportRequest chcData)
        {
            string stProc = CHCShipmentReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }

        public List<CHCReports> RetrieveCHCReportsTimeoutDamaged(CHCReportRequest chcData)
        {
            string stProc = CHCReCollectionReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", chcData.fromDate),
                new SqlParameter("@ToDate", chcData.toDate),
                new SqlParameter("@CHCID", chcData.chcId),
                new SqlParameter("@RIID", chcData.riId),
                new SqlParameter("@SubjectType", chcData.subjectTypeId),
                new SqlParameter("@Status", chcData.status)
            };
            var allData = UtilityDL.FillData<CHCReports>(stProc, pList);
            return allData;
        }
    }
}
