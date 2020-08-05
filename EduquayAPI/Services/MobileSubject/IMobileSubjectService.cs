using EduquayAPI.Contracts.V1.Request.Mobile;
using EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection;
using EduquayAPI.Contracts.V1.Request.MobileAppShipment;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.MobileSubject;
using EduquayAPI.Models.ANMSubjectRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MobileSubject
{
    public interface IMobileSubjectService
    {
        Task<SubRegSuccessResponse> AddSubjectRegistration(AddSubjectRequest subRegData);
        Task<SubjectResigrationListResponse> RetrieveDetail(MobileRetrieveRequest mrData);
        Task<SampleCollectionListResponse> AddSampleCollection(SampleCollectRequest ssData);
        Task<ShipmentListResponse> AddANMShipment(MobileShipmentsRequest msData);
        Task<NotificationListResponse> RetrieveNotifications(MobileRetrieveRequest mrData);
        Task<TimeoutResponse> AddMoveTimeout(AddTimeoutExpireMobileRequest eData);
        Task<UpdateStatusResponse> UpdateNotificationStatus(AddUpdateStatusRequest usData);
        Task<UpdateStatusResponse> UpdatatePositiveStatus(AddUpdateStatusRequest usData);
        Task<AcknowledgementResponse> AddAcknowledgement(AcnowledgementRequest aData);
    }
}
