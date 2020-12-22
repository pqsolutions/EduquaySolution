using EduquayAPI.Contracts.V1.Request.NHMReport;
using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.NHMReport
{
    public class NHMReportData : INHMReportData
    {
        private const string NHMReportSampling = "SPC_NHMReportSampling";
        private const string NHMReportCHCDetails = "SPC_NHMReportCHCDetails";
        private const string NHMReportHPLCPathoDetails = "SPC_NHMReportHPLCPathoDetails";
        private const string NHMReportSpouseRegistraion = "SPC_NHMReportSpouseRegistraion";
        private const string NHMReportPrePNDTC = "SPC_NHMReportPrePNDTC";
        private const string NHMReportPNDT = "SPC_NHMReportPNDT";
        private const string NHMReportPostPNDTC = "SPC_NHMReportPostPNDTC";
        private const string NHMReportMTP = "SPC_NHMReportMTP";

        public NHMReportData()
        {

        }

        public List<NHMReports> RetrieveNHMReportsCHCDetails(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportCHCDetails;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReportsHPLCPathoDetails(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportHPLCPathoDetails;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReportsMTPDetails(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportMTP;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReportsPNDTDetails(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportPNDT;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReportsPostPNDTCDetails(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportPostPNDTC;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReportsPrePNDTCdetails(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportPrePNDTC;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReportsSampling(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportSampling;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReportsSpouseRegDetails(NHMReportsRequest nhmData)
        {
            string stProc = NHMReportSpouseRegistraion;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId),
                new SqlParameter("@Status", nhmData.status)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }
    }
}
