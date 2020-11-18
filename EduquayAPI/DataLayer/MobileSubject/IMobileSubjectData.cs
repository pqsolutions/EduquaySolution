using EduquayAPI.Contracts.V1.Request.Mobile;
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
        LastIds FindLastId(int userId);
        void subjectPrimary(PrimaryDetailRequest sprData);
        void SubjectAddress(AddressDetailRequest saData);
        void SubjectPregnancy(PregnancyDetailRequest spData);
        void SubjectParent(ParentDetailRequest spaData);
        SubjectRegDetail MobileSubjectRegDetail(int userId);
        void SampleColection(SampleCollectionsRequest ssData);
        List<SampleCollection> MobileSampleDetail(int userId);
        void AddShipment(MobileShipmentRequest msData);
        void AddTimeoutExpiry(MobileAddExpiryRequest meData);
        ANMMobileShipment MobileANMShipmentDetail(int userId);
        List<MobileNotificationSamples> DamagedSamples(int userId);
        List<MobileNotificationSamples> SampleTimeout(int userId);
        List<MobilePositiveSubjects> PositiveSubjects(int userId);
        List<TestResult> GetTestResults(int userId);
        Device CheckDevice(int userId, string deviceId);
        void UpdateNotificationStatus(UpdateStatusRequest usData);
        void UpdatePositiveSubjectStatus(UpdateStatusRequest usData);
        void AddResultAcknowledgement(string uniqueSubjectId);
        void AddCHCSubAcknowledgement(string uniqueSubjectId);
        void AddCHCSamplesAcknowledgement(string barcodeNo);
        List<SampleCollection> MobileCHCSampleDetail(int userId);
        SubjectRegDetail MobileCHCSubjectRegDetail(int userId);
        MobilePNDTReferal GetPNDTReferral(int userId);
        MobileMTPReferal GetMTPReferral(int userId);
        void UpdatePNDTReferalStatus(MobileReferalRequest rData);
        void UpdateMTPReferalStatus(MobileReferalRequest rData);
        List<MobilePrePNDTCounselling> FetchPrePNDTCounselling(int userId);
        List<MobilePNDTesting> FetchPNDTesting(int userId);
        List<MobilePostPNDTCounselling> FetchPostPNDTCounselling(int userId);
        List<MobileMTPService> FetchMTPService(int userId);
        List<MobilePrePNDTCounselling> FetchPrePNDTCounsellingNotification(int userId);
        List<MobilePNDTesting> FetchPNDTestingNotification(int userId);
        List<MobilePostPNDTCounselling> FetchPostPNDTCounsellingNotification(int userId);
        List<MobileMTPService> FetchMTPServiceNotification(int userId);
        void UpdatePrePostPNDTMTPAcknowledgement(AddPNDTMTPAckRequest aData);
        ANMMobileMTPFollowUp MobileMTPFollowUp(int userId);
        void UpdatePostMTPFollowupStatus(AddUpdateFollowupStatusRequest fData);
        List<TrackingMobileSubjects> RetrieveTrackingSubjects(int userId);
        MobileChartDetail FetchMobileChartDetail(int userId);
        MobileMetricsDetail FetchMobileMetricsDetail(int userId);
        List<MobileMenu> RetrieveMobileMenu();
        MobileAlert RetrieveAlert();
        MobileMetricSummaryMessage RetrieveResponseMsg();
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
