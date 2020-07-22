using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Models;
using EduquayAPI.Models.CHCNotifications;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCNotifications
{
    public class CHCNotificationsData : ICHCNotificationsData
    {
        private const string FetchCHCNotificationSamples = "SPC_FetchCHCNotificationSamples";
        private const string FetchBarcodeSample = "SPC_FetchBarcodeSample";
        private const string MoveTimeoutExpiry = "SPC_AddCHCTimeoutExpiryInUnsentSamples";
        private const string AddANMSampleRecollection = "SPC_AddANMSampleRecollection";

        public CHCNotificationsData()
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

        public string AddTimeoutExpiry(CHCNotificationTimeoutRequest cnData)
        {
            try
            {
                string stProc = MoveTimeoutExpiry;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", cnData.barcodeNo ?? cnData.barcodeNo),
                    new SqlParameter("@UserId", cnData.userId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);

                return "Samples successfully moved to timeout expiry";
            }
            catch (Exception e)
            {
                throw e;
            }
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

        public List<CHCUnsentSamples> GetANMUnsentSamples(CHCNotificationSamplesRequest cnData)
        {
            string stProc = FetchCHCNotificationSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", cnData.userId),
                new SqlParameter("@CollectedFrom",cnData.collectionFrom),
                new SqlParameter("@Notification",cnData.notification),
            };
            var allData = UtilityDL.FillData<CHCUnsentSamples>(stProc, pList);
            return allData;
        }

        public List<CHCNotificationSample> GetCHCNotificationSamples(CHCNotificationSamplesRequest cnData)
        {
            string stProc = FetchCHCNotificationSamples;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UserId", cnData.userId),
                new SqlParameter("@CollectedFrom",cnData.collectionFrom),
                new SqlParameter("@Notification",cnData.notification),
            };
            var allData = UtilityDL.FillData<CHCNotificationSample>(stProc, pList);
            return allData;
        }
    }
}
