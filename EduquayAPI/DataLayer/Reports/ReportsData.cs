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

        public TrackingSubjects RetrieveSubjectsForTracking(string uniqueSubjectId)
        {
            string stProc = FetchTrackingSubjectReport;
            var pList = new List<SqlParameter>() { new SqlParameter("@UniqueSubjectId", uniqueSubjectId) };
            var allData = UtilityDL.FillEntity<TrackingSubjects>(stProc, pList);
            return allData;
        }
    }
}
