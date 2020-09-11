using EduquayAPI.Contracts.V1.Request.DistrictCoordinator;
using EduquayAPI.Models.DiscrictCoordinator;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.DistrictCoordinator
{
    public class DCData :IDCData 
    {
        private const string FetchDCNotificationSamples = "SPC_FetchDCNotificationSamples";
        private const string FetchDCNotificationPositiveSamples = "SPC_FetchDCNotificationPositiveSamples";
        private const string UpdateStatusDCNotificationSamples = "SPC_UpdateStatusDCNotificationSamples";
        private const string UpdateStatusDCPositiveSubjects = "SPC_UpdateStatusDCPositiveSubjects";
        private const string FetchDCNotificationPNDTReferal = "SPC_FetchDCNotificationPNDTReferal";
        private const string FetchDCNotificationMTPReferal = "SPC_FetchDCNotificationMTPReferal";

        public DCData()
        {

        }

        public List<NotificationSamples> GetDamagedSamples(int districtId)
        {
            string stProc = FetchDCNotificationSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", districtId),
                new SqlParameter("@Notification", 1),
            };
            var samplesData = UtilityDL.FillData<NotificationSamples>(stProc, pList);
            return samplesData;
        }

        public List<MTPReferal> GetMTPReferal(int districtId)
        {
            string stProc = FetchDCNotificationMTPReferal;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", districtId),
            };
            var samplesData = UtilityDL.FillData<MTPReferal>(stProc, pList);
            return samplesData;
        }

        public List<PNDTReferal> GetPNDTReferal(int districtId)
        {
            string stProc = FetchDCNotificationPNDTReferal;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", districtId),
            };
            var samplesData = UtilityDL.FillData<PNDTReferal>(stProc, pList);
            return samplesData;
        }

        public List<DCPositiveSamples> GetPositiveSampeles(int districtId)
        {
            string stProc = FetchDCNotificationPositiveSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", districtId),
            };
            var samplesData = UtilityDL.FillData<DCPositiveSamples>(stProc, pList);
            return samplesData;
        }

        public List<NotificationSamples> GetTimeoutSamples(int districtId)
        {
            string stProc = FetchDCNotificationSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", districtId),
                new SqlParameter("@Notification", 3),
            };
            var samplesData = UtilityDL.FillData<NotificationSamples>(stProc, pList);
            return samplesData;
        }

        public List<NotificationSamples> GetUnsentSamples(int districtId)
        {
            string stProc = FetchDCNotificationSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", districtId),
                new SqlParameter("@Notification", 3),
            };
            var samplesData = UtilityDL.FillData<NotificationSamples>(stProc, pList);
            return samplesData;
        }

        public string UpdatePositiveSubjectStatus(NotificationDCRequest nData)
        {
            try
            {
                string stProc = UpdateStatusDCPositiveSubjects;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", nData.barcodeNo ?? nData.barcodeNo),
                    new SqlParameter("@UserId", nData.userId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Sample status updated successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public string UpdateSampleStatus(NotificationDCRequest nData)
        {
            try
            {
                string stProc = UpdateStatusDCNotificationSamples;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", nData.barcodeNo ?? nData.barcodeNo),
                    new SqlParameter("@UserId", nData.userId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Positive subject status updated successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
