using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.DataLayer.ANMNotifications;
using EduquayAPI.Models.ANMNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMNotifications
{
    public class ANMNotificationsService : IANMNotificationsService
    {
        private readonly IANMNotificationsData _anmNotificationsData;

        public ANMNotificationsService(IANMNotificationsDataFactory anmNotificationsDataFactory)
        {
            _anmNotificationsData = new ANMNotificationsDataFactory().Create();
        }

        public string AddSampleRecollection(SampleRecollectionRequest srData)
        {
            try
            {
                if (srData.SampleCollectionID <= 0)
                {
                    return "Invalid Sample ID";
                }
                if (srData.SubjectID <= 0)
                {
                    return "Invalid subject Id";
                }
                if (string.IsNullOrEmpty(srData.UniqueSubjectID))
                {
                    return "Invalid UniqueSubjectID";
                }
                if (string.IsNullOrEmpty(srData.BarcodeNo))
                {
                    return "Invalid BarcodeNo";
                }
                if (string.IsNullOrEmpty(srData.SampleCollectionDate))
                {
                    return "Invalid SampleCollection Date";
                }
                if (string.IsNullOrEmpty(srData.SampleCollectionTime))
                {
                    return "Invalid SampleCollection Time";
                }
                if (srData.Reason_Id <= 0)
                {
                    return "Invalid Reason Id";
                }
                if (srData.CollectionFrom <= 0)
                {
                    return "Invalid Collection From data";
                }
                if (srData.CollectedBy <= 0)
                {
                    return "Invalid Collection By";
                }
                var result = _anmNotificationsData.AddSampleRecollection(srData);
                return string.IsNullOrEmpty(result) ? $"Unable to add subject sample recollection data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add subject sample recollection data - {e.Message}";
            }
        }


        public string UpdateSampleStatus(NotificationUpdateStatusRequest usData)
        {
            try
            {
                if (usData.ID <= 0)
                {
                    return "Invalid SampleId";
                }
                if (usData.ANMID <= 0)
                {
                    return "Invalid ANM Id";
                }

                var result = _anmNotificationsData.UpdateSampleStatus(usData);
                return string.IsNullOrEmpty(result) ? $"Unable to update sample status data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to update  sample status - {e.Message}";
            }
        }

        public List<ANMNotificationSample> GetANMNotificationSamples(NotificationSamplesRequest nsData)
        {
            var notificationSamples = _anmNotificationsData.GetANMNotificationSamples(nsData);
            return notificationSamples;
        }

        public List<ANMSubjectSample> GetANMSubjectSamples(int id, int notification)
        {
            var subjectSamples = _anmNotificationsData.GetANMSubjectSamples(id, notification);
            return subjectSamples;
        }
    }
}
