﻿using EduquayAPI.Contracts.V1.Request.Mobile;
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
        void AddCHCSamplesAcknowledgement(string uniqueSubjectId);
        List<SampleCollection> MobileCHCSampleDetail(int userId);
        SubjectRegDetail MobileCHCSubjectRegDetail(int userId);
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
