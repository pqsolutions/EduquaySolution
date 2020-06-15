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
                    new SqlParameter("@SampleCollectionID", srData.SampleCollectionID),
                    new SqlParameter("@SubjectID", srData.SubjectID),
                    new SqlParameter("@UniqueSubjectID", srData.UniqueSubjectID ?? srData.UniqueSubjectID),
                    new SqlParameter("@BarcodeNo", srData.BarcodeNo ?? srData.BarcodeNo),
                    new SqlParameter("@SampleCollectionDate", srData.SampleCollectionDate ?? srData.SampleCollectionDate),
                    new SqlParameter("@SampleCollectionTime", srData.SampleCollectionTime ?? srData.SampleCollectionTime),
                    new SqlParameter("@Reason_Id", srData.Reason_Id),
                    new SqlParameter("@CollectionFrom", srData.CollectionFrom),
                    new SqlParameter("@CollectedBy", srData.CollectedBy),
                    new SqlParameter("@Createdby", srData.CreatedBy),
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
                    new SqlParameter("@ID", usData.ID),
                    new SqlParameter("@Status", usData.Status),
                    new SqlParameter("@ANMID", usData.ANMID),                   
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
                new SqlParameter("@ANMID", nsData.ANMID),
                new SqlParameter("@Notification",nsData.Notification),
                new SqlParameter("@SearchValue",nsData.SearchValue ?? string.Empty),
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
