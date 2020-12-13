using EduquayAPI.Contracts.V1.Request.Reports;
using EduquayAPI.Models.Reports;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Reports
{
    public class ReportsData : IReportsData
    {
        private const string FetchTrackingANWSubjectReport = "SPC_FetchTrackingANWSubjectReport";
        private const string FetchTrackingSubjectReport = "SPC_FetchTrackingSubjectReport";
        private const string NHMReport = "SPC_NHMReport";
        private const string NHMReportParticularDetails = "SPC_NHMReportParticularDetails";

        public ReportsData()
        {

        }

        public TrackingANWSubject RetrieveANWSubjects(string uniqueSubjectId)
        {
            string stProc = FetchTrackingANWSubjectReport;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectId", uniqueSubjectId) };
            var allData = UtilityDL.FillEntity<TrackingANWSubject>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveNHMReports(NHMRequest nhmData)
        {
            string stProc = NHMReport;
            var pList = new List<SqlParameter>()
            { 
                new SqlParameter("@FromDate", nhmData.fromDate),
                new SqlParameter("@ToDate", nhmData.toDate),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
                new SqlParameter("@CHCID", nhmData.chcId),
                new SqlParameter("@ANMID", nhmData.anmId)
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public List<NHMReports> RetrieveParticularNHMReports(NHMRequest nhmData)
        {
            string stProc = NHMReportParticularDetails;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserInput", nhmData.userInput),
                new SqlParameter("@DistrictId", nhmData.districtId),
                new SqlParameter("@BlockId", nhmData.blockId),
            };
            var allData = UtilityDL.FillData<NHMReports>(stProc, pList);
            return allData;
        }

        public TrackingSubjects RetrieveSubjectsForTracking(string uniqueSubjectId)
        {
            string stProc = FetchTrackingSubjectReport;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectId", uniqueSubjectId) };
            var allData = UtilityDL.FillEntity<TrackingSubjects>(stProc, pList);
            return allData;
        }
    }
}
