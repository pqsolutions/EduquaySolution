using EduquayAPI.Contracts.V1.Request.ANMNotifications;
using EduquayAPI.Contracts.V1.Request.CHCNotifications;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.CHCNotifications;
using EduquayAPI.Models.CHCNotifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCNotifications
{
    public interface ICHCNotificationsService
    {
        List<CHCNotificationSample> GetCHCNotificationSamples(CHCNotificationSamplesRequest cnData);
        Task<CHCUnsentSamplesResponse> RetrieveUnsentSamples(CHCNotificationSamplesRequest cnData);
        CHCTimeoutResponse MoveTimeout(CHCNotificationTimeoutRequest cnData);
        Task<ServiceResponse> AddSampleRecollection(SampleRecollectionRequest srData);
        List<CHCHPLCPositiveSamples> GetPositiveDetails(CHCPositiveSamplesRequest cpData);
    }
}
