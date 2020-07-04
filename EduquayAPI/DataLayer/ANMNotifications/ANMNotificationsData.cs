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
                return $"Sample recollected successfully for this UniquesubjectID - {srData.uniqueSubjectId}";
            }
            catch (Exception e)
            {
                return $"Unable to collect sampele for this uniquesubjectid - {srData.uniqueSubjectId} - {e.Message}";

            }
        }
        public string UpdateSampleStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {
                string stProc = UpdateStatusANMNotificationSamples;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SampleCollectionId", usData.sampleCollectionId),
                    new SqlParameter("@Status", usData.status),
                    new SqlParameter("@ANMID", usData.anmId),                   
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Sample Status updated successfully";
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
    }
}
