using EduquayAPI.Contracts.V1.Request.ANMNotifications;
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
        private const string FetchANMSampleSubjectDetail = "SPC_FetchANMSampleSubjectDetail";
        private const string UpdateStatusANMNotificationSamples = "SPC_UpdateStatusANMNotificationSamples";
        private const string AddANMSampleRecollection = "SPC_AddANMSampleRecollection";


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
                    new SqlParameter("@SampleCollectionID", srData.sampleCollectionId),
                    new SqlParameter("@SubjectID", srData.subjectId),
                    new SqlParameter("@UniqueSubjectID", srData.uniqueSubjectId ?? srData.uniqueSubjectId),
                    new SqlParameter("@BarcodeNo", srData.barcodeNo ?? srData.barcodeNo),
                    new SqlParameter("@SampleCollectionDate", srData.sampleCollectionDate ?? srData.sampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", srData.sampleCollectionTime ?? srData.sampleCollectionTime),
                    new SqlParameter("@Reason_Id", srData.reasonId),
                    new SqlParameter("@CollectionFrom", srData.collectionFrom),
                    new SqlParameter("@CollectedBy", srData.collectedBy),
                    new SqlParameter("@Createdby", srData.createdBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Subject Sample Recollection added successfully";
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
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@ID", usData.id),
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
                new SqlParameter("@SearchValue",nsData.searchValue ?? string.Empty),
            };
            var allData = UtilityDL.FillData<ANMNotificationSample>(stProc, pList);
            return allData;
        }

        public List<ANMSubjectSample> GetANMSubjectSamples(int id, int notification)
        {
            string stProc = FetchANMSampleSubjectDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@ID", id),
                new SqlParameter("@Notification",notification),
            };
            var allData = UtilityDL.FillData<ANMSubjectSample>(stProc, pList);
            return allData;
        }

       
    }
}
