using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Models;
using EduquayAPI.Models.ANMNotifications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMNotifications
{
    public class ANMNotificationsData : IANMNotificationsData
    {
        private const string FetchANMNotificationSamples = "SPC_FetchANMNotificationSamples";
        private const string UpdateStatusANMNotificationSamples = "SPC_UpdateStatusANMNotificationSamples";
        private const string AddANMSampleRecollection = "SPC_AddANMSampleRecollection";
        private const string FetchBarcodeSample = "SPC_FetchBarcodeSample";
        private const string FetchUnsentSamples = "SPC_FetchUnsentSamples";
        private const string MoveTimeoutExpiry = "SPC_AddTimeoutExpiryInUnsentSamples";
        private const string FetchPositiveSubjects = "SPC_FetchANMPositiveSubjectDetail";
        private const string UpdatePositiveStatus = "SPC_UpdateStatusANMPositiveSubjects";
        private const string FetchANMNotificationPNDTReferal = "SPC_FetchANMNotificationPNDTReferal";
        private const string FetchANMNotificationMTPReferal = "SPC_FetchANMNotificationMTPReferal";

        public ANMNotificationsData()
        {

        }

        public string AddSampleRecollection(SampleRecollectionRequest srData)
        {
            try
            {
                string stProc = AddANMSampleRecollection;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@UniqueSubjectID", srData.uniqueSubjectId ?? srData.uniqueSubjectId),
                    new SqlParameter("@BarcodeNo", srData.barcodeNo  ?? srData.barcodeNo),
                    new SqlParameter("@SampleCollectionDate", srData.sampleCollectionDate ?? srData.sampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", srData.sampleCollectionTime ?? srData.sampleCollectionTime),
                    new SqlParameter("@Reason", srData.reason ?? srData.reason),
                    new SqlParameter("@CollectionFrom", srData.collectionFrom),
                    new SqlParameter("@CollectedBy", srData.collectedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return $"Sample recollected successfully";
            }
            catch (Exception e)
            {
                throw e;

            }
        }
        public string UpdateSampleStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {
                string stProc = UpdateStatusANMNotificationSamples;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", usData.barcodeNo ?? usData.barcodeNo),
                    new SqlParameter("@ANMID", usData.anmId),                   
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Sample status updated successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<ANMNotificationSample> GetANMNotificationSamples(NotificationSamplesRequest nsData)
        {
            string stProc = FetchANMNotificationSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANMID", nsData.anmId),
                new SqlParameter("@Notification",nsData.notification),
            };
            var allData = UtilityDL.FillData<ANMNotificationSample>(stProc, pList);
            return allData;
        }

        public List<BarcodeSample> FetchBarcode(string barcodeNo)
        {
            string stProc = FetchBarcodeSample;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@Barcode", barcodeNo),
            };
            var allData = UtilityDL.FillData<BarcodeSample>(stProc, pList);
            return allData;
        }

        public List<ANMUnsentSamples> GetANMUnsentSamples(int userId)
        {
            string stProc = FetchUnsentSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANMID", userId),
            };
            var allData = UtilityDL.FillData<ANMUnsentSamples>(stProc, pList);
            return allData;
        }

        public string AddTimeoutExpiry(NotificationUpdateStatusRequest usData)
        {
            try
            {
                string stProc = MoveTimeoutExpiry;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", usData.barcodeNo ?? usData.barcodeNo),
                    new SqlParameter("@ANMID", usData.anmId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);

                return "Samples successfully moved to timeout expiry";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ANMHPLCPositiveSamples> GetPositiveDetails(int userId)
        {
            string stProc = FetchPositiveSubjects;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ANMID", userId),
            };
            var allData = UtilityDL.FillData<ANMHPLCPositiveSamples>(stProc, pList);
            return allData;
        }

        public string UpdatePositiveSubjectStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {
                string stProc = UpdatePositiveStatus;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", usData.barcodeNo ?? usData.barcodeNo),
                    new SqlParameter("@ANMID", usData.anmId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Positive subject status updated successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<ANMPNDTReferal> GetPNDTReferal(int userId)
        {
            string stProc = FetchANMNotificationPNDTReferal;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", userId),
            };
            var samplesData = UtilityDL.FillData<ANMPNDTReferal>(stProc, pList);
            return samplesData;
        }

        public List<ANMMTPReferal> GetMTPReferal(int userId)
        {
            string stProc = FetchANMNotificationMTPReferal;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", userId),
            };
            var samplesData = UtilityDL.FillData<ANMMTPReferal>(stProc, pList);
            return samplesData;
        }
    }
}
