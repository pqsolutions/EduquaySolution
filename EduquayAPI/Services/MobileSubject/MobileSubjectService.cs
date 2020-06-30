using EduquayAPI.Contracts.V1.Request.MobileAppSampleCollection;
using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.MobileSubject;
using EduquayAPI.DataLayer.MobileSubject;
using EduquayAPI.Models.ANMSubjectRegistration;
using EduquayAPI.Models.MobileSubject;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MobileSubject
{
    public class MobileSubjectService : IMobileSubjectService
    {
        private readonly IMobileSubjectData _mobileSubjectData;

        public MobileSubjectService(IMobileSubjectDataFactory mobileSubjectDataFactory)
        {
            _mobileSubjectData = new MobileSubjectDataFactory().Create();
        }

        public async Task<SampleCollectionListResponse> AddSampleCollection(SampleCollectRequest ssData)
        {
            List<BarcodeSampleDetail> barcodes = new List<BarcodeSampleDetail>();
            SampleCollectionListResponse slResponse = new SampleCollectionListResponse();
            var barcodeNo = "";
            try
            {
                foreach (var sample in ssData.SampleCollectionsRequest)
                {
                    var slist = new BarcodeSampleDetail();
                    barcodeNo = sample.samples.barcodeNo;
                    _mobileSubjectData.SampleColection(sample.samples);
                    slist.barcodeNo = sample.samples.barcodeNo;
                    barcodes.Add(slist);
                }
                slResponse.Status = true;
                slResponse.Message = barcodes.Count +" Samples collected successfully";
                slResponse.Barcodes = barcodes;
            }
            catch(Exception e)
            {
                slResponse.Status = false;
                slResponse.Message = "Partially " + barcodes.Count + " samples collected successfully, From this (" + barcodeNo + ") onwards not collected. " + e.Message;
                slResponse.Barcodes = barcodes;
            }
            return slResponse;
        }

        public async Task<SubRegSuccessResponse> AddSubjectRegistration(AddSubjectRequest subRegData)
        {

            List<UniqueSubjectIdDetail> uniqSubjectIdDetail = new List<UniqueSubjectIdDetail>();
           
            SubRegSuccessResponse subRegSuccess = new SubRegSuccessResponse();
            var subId = "";
            try
            {
                foreach (var subject in subRegData.subjectsRequest)
                {
                    var slist = new UniqueSubjectIdDetail();
                    subId = subject.subjectPrimaryRequest.uniqueSubjectId;
                    _mobileSubjectData.subjectPrimary(subject.subjectPrimaryRequest);
                    _mobileSubjectData.SubjectAddress(subject.subjectAddressRequest);
                    _mobileSubjectData.SubjectPregnancy(subject.subjectPregnancyRequest);
                    _mobileSubjectData.SubjectParent(subject.subjectParentRequest);

                    slist.uniqueSubjectId = subject.subjectParentRequest.uniqueSubjectId;
                    uniqSubjectIdDetail.Add(slist);
                }

                subRegSuccess.Status = true;
                subRegSuccess.Message = uniqSubjectIdDetail.Count + " Subjects Registered Successfully";
                subRegSuccess.SuccessIds = uniqSubjectIdDetail;
            }
            catch (Exception e)
            {
                subRegSuccess.Status = false;
                subRegSuccess.Message = "Partially " + uniqSubjectIdDetail.Count + " subjects registered successfully, From this (" + subId + ") onwards not registered. " + e.Message;
                subRegSuccess.SuccessIds = uniqSubjectIdDetail;
            }
            return subRegSuccess;
        }

        public async Task<SubjectResigrationListResponse> RetrieveDetail(int userId)
        {

            var subjectDetails = _mobileSubjectData.MobileSubjectRegDetail(userId);
            var sampleDetails = _mobileSubjectData.MobileSampleDetail(userId);

            var subjectRegistrationResponse = new SubjectResigrationListResponse();
            var subjectRegistrations = new List<SubjectResigration>();
            try
            {

                foreach (var primarySubject in subjectDetails.PrimarySubjectList)
                {
                    var subjectRegistration = new SubjectResigration();
                    var address = subjectDetails.AddressSubjectList.FirstOrDefault(ad => ad.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pregnancy = subjectDetails.PregnancySubjectList.FirstOrDefault(pr => pr.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var parent = subjectDetails.ParentSubjectList.FirstOrDefault(pa => pa.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    subjectRegistration.SubjectPrimary = primarySubject;
                    subjectRegistration.SubjectAddress = address;
                    subjectRegistration.SubjectPregnancy = pregnancy;
                    subjectRegistration.SubjectParent = parent;
                    subjectRegistrations.Add(subjectRegistration);
                }
              
                subjectRegistrationResponse.SubjectResigrations = subjectRegistrations;
                subjectRegistrationResponse.SampleCollections = sampleDetails;
                subjectRegistrationResponse.Status = "true";
                subjectRegistrationResponse.Message = string.Empty;
            }
            catch (Exception ex)
            {
                subjectRegistrationResponse.Status = "false";
                subjectRegistrationResponse.Message = ex.Message;

            }

            return subjectRegistrationResponse;
        }
    }
}

