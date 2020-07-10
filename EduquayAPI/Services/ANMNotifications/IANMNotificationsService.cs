using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Response.ANMNotifications;
using EduquayAPI.Models.ANMNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMNotifications
{
    public interface IANMNotificationsService
    {
        List<ANMNotificationSample> GetANMNotificationSamples(NotificationSamplesRequest nsData);
        string UpdateSampleStatus(NotificationUpdateStatusRequest usData);
        string AddSampleRecollection(SampleRecollectionRequest srData);
        Task<ANMUnsentSamplesResponse> RetrieveUnsentSamples(int userId);
        ANMTimeoutResponse MoveTimeout(NotificationUpdateStatusRequest usData);
    }
}
