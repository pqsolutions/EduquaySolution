using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Response;
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
        ServiceResponse UpdateSampleStatus(NotificationUpdateStatusRequest usData);
        ServiceResponse UpdatePositiveSubjectStatus(NotificationUpdateStatusRequest usData);
        Task<ServiceResponse> AddSampleRecollection(SampleRecollectionRequest srData);
        List<ANMHPLCPositiveSamples> GetPositiveDetails(int userId);
        Task<ANMUnsentSamplesResponse> RetrieveUnsentSamples(int userId);
        ANMTimeoutResponse MoveTimeout(NotificationUpdateStatusRequest usData);
        List<ANMPNDTReferal> GetPNDTReferal(int userId);
        List<ANMMTPReferal> GetMTPReferal(int userId);
    }
}
