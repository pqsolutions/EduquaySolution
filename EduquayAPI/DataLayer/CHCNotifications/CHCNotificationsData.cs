using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Models;
using EduquayAPI.Models.CHCNotifications;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCNotifications
{
    public class CHCNotificationsData : ICHCNotificationsData
    {
        private const string FetchCHCNotificationSamples = "SPC_FetchCHCNotificationSamples";
        private const string FetchBarcodeSample = "SPC_FetchBarcodeSample";

        public CHCNotificationsData()
        {

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
