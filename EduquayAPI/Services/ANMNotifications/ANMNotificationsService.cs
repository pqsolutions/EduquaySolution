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
               
                if (string.IsNullOrEmpty(srData.uniqueSubjectId))
                {
                    return "Invalid UniqueSubjectID";
                }
                if (string.IsNullOrEmpty(srData.barcodeNo))
                {
                    return "Invalid BarcodeNo";
                }
                if (string.IsNullOrEmpty(srData.sampleCollectionDate))
                {
                    return "Invalid SampleCollection Date";
                }
                if (string.IsNullOrEmpty(srData.sampleCollectionTime))
                {
                    return "Invalid SampleCollection Time";
                }
                if (string.IsNullOrEmpty(srData.reason))
                {
                    return "Invalid Reason";
                }
                if (srData.collectionFrom <= 0)
                {
                    return "Invalid Collection From data";
                }
                if (srData.collectedBy <= 0)
                {
                    return "Invalid Collection By";
                }
                var barcode = _anmNotificationsData.FetchBarcode(srData.barcodeNo);
                if (barcode.Count <= 0)
                {
                    var result = _anmNotificationsData.AddSampleRecollection(srData);
                    return string.IsNullOrEmpty(result) ? $"Unable to re collect sampele for this uniquesubjectid - {srData.uniqueSubjectId}" : result;
                }
                else
                {
                    return $"This Barcode No - {srData.barcodeNo} already exist";
                }
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
               
                if (usData.anmId <= 0)
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
    }
}
