using EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection;
using EduquayAPI.Contracts.V1.Request.MobileAppShipment;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MobileSubject
{
    public interface IMobileSubjectData
    {
        void subjectPrimary(PrimaryDetailRequest sprData);
        void SubjectAddress(AddressDetailRequest saData);
        void SubjectPregnancy(PregnancyDetailRequest spData);
        void SubjectParent(ParentDetailRequest spaData);
        SubjectRegDetail MobileSubjectRegDetail(int userId);
        void SampleColection(SampleCollectionsRequest ssData);
        List<SampleCollection> MobileSampleDetail(int userId);
        void AddShipment(MobileShipmentRequest msData);
    }

    public interface IMobileSubjectDataFactory
    {
        IMobileSubjectData Create();
    }
    public class MobileSubjectDataFactory : IMobileSubjectDataFactory
    {
        public IMobileSubjectData Create()
        {
            return new MobileSubjectData();
        }
    }
}
