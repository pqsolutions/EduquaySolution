using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Models.ANMNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.ANMNotifications
{
    public interface IANMNotificationsData
    {
        List<ANMNotificationSample> GetANMNotificationSamples(NotificationSamplesRequest nsData);
        List<ANMSubjectSample> GetANMSubjectSamples(int id, int notification);
        string UpdateSampleStatus(NotificationUpdateStatusRequest usData);
        string AddSampleRecollection(SampleRecollectionRequest srData);
    }
    public interface IANMNotificationsDataFactory
    {
        IANMNotificationsData Create();
    }
    public class ANMNotificationsDataFactory : IANMNotificationsDataFactory
    {
        public IANMNotificationsData Create()
        {
            return new ANMNotificationsData();
        }
    }
}
