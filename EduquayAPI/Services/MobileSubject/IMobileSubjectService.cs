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
        Task<SubjectResigrationListResponse> RetrieveDetail(int userId);
        Task<SampleCollectionListResponse> AddSampleCollection(SampleCollectRequest ssData);
        Task<ShipmentListResponse> AddANMShipment(MobileShipmentsRequest msData);
    }
}
