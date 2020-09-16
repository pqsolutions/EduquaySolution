using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;


namespace EduquayAPI.Services
{
    public class SubjectService : ISubjectService
    {

        private readonly ISubjectData _subjectData;

        public SubjectService(ISubjectDataFactory subjectDataFactory)
        {
            _subjectData = new SubjectDataFactory().Create();
        }
        public async Task<UniqueIdDetail> AddSubject(SubjectRegistrationRequest subRegData)
        {
            UniqueIdDetail subRegSuccess = new UniqueIdDetail();
            try
            {
                var result = _subjectData.AddSubject(subRegData);
                subRegSuccess.status = true;
                subRegSuccess.message = result.message;
                subRegSuccess.uniqueSubjectId = result.uniqueSubjectId;
            }
            catch (Exception e)
            {
                subRegSuccess.uniqueSubjectId = "";
                subRegSuccess.status = false;
                subRegSuccess.message = $"Failed to add subject registration for {subRegData.subjectPrimaryRequest.firstName + " " + subRegData.subjectPrimaryRequest.lastName}";
            }
            return subRegSuccess;
        }



        public List<ANWSubjectDetail> RetrieveANWDetail(ANWSubjectRequest asData)
        {
            var anwSubjects = _subjectData.RetrieveANWDetail(asData);
            return anwSubjects;
        }

        public List<CHCANWSubjectDetail> RetrieveCHCANWDetail(CHCANWSubjectRequest casData)
        {
            var anwSubjects = _subjectData.RetrieveCHCANWDetail(casData);
            return anwSubjects;
        }

        public async Task<SubjectRegistrationResponse> RetrieveCHCSubjectDetail(SubjectDetailRequest sdData)
        {
            var subjectRegistrationResponse = new SubjectRegistrationResponse();
            var subjectRegistrations = new List<SubjectsDetail>();
            try
            {
                var subjectDetails = _subjectData.RetrieveCHCSubjectDetail(sdData);
                foreach (var primarySubject in subjectDetails.PrimarySubjectList)
                {
                    var subjectRegistration = new SubjectsDetail();
                    var address = subjectDetails.AddressSubjectList.FirstOrDefault(ad => ad.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pregnancy = subjectDetails.PregnancySubjectList.FirstOrDefault(pr => pr.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var parent = subjectDetails.ParentSubjectList.FirstOrDefault(pa => pa.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    var prePndtCounselling = subjectDetails.prePndtCounselling.FirstOrDefault(prp => prp.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pndtTesting = subjectDetails.pndtTesting.FirstOrDefault(pn => pn.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var postPndtCounselling = subjectDetails.postPndtCounselling.FirstOrDefault(pop => pop.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var mtpService = subjectDetails.mtpService.FirstOrDefault(ms => ms.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    subjectRegistration.PrimaryDetail = primarySubject;
                    subjectRegistration.AddressDetail = address;
                    subjectRegistration.PregnancyDetail = pregnancy;
                    subjectRegistration.ParentDetail = parent;
                    subjectRegistration.prePndtCounselling = prePndtCounselling;
                    subjectRegistration.pndtTesting = pndtTesting;
                    subjectRegistration.postPndtCounselling = postPndtCounselling;
                    subjectRegistration.mtpService = mtpService;
                    subjectRegistrations.Add(subjectRegistration);
                }

                subjectRegistrationResponse.SubjectsDetail = subjectRegistrations;
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

        public async Task<SubjectRegistrationResponse> RetrieveParticularCHCSubjectDetail(SubjectsDetailRequest sdData)
        {
            var subjectRegistrationResponse = new SubjectRegistrationResponse();
            var subjectRegistrations = new List<SubjectsDetail>();
            try
            {
                var subjectDetails = _subjectData.RetrieveParticularCHCSubjectDetail(sdData);
                foreach (var primarySubject in subjectDetails.PrimarySubjectList)
                {
                    var subjectRegistration = new SubjectsDetail();
                    var address = subjectDetails.AddressSubjectList.FirstOrDefault(ad => ad.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pregnancy = subjectDetails.PregnancySubjectList.FirstOrDefault(pr => pr.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var parent = subjectDetails.ParentSubjectList.FirstOrDefault(pa => pa.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    var prePndtCounselling = subjectDetails.prePndtCounselling.FirstOrDefault(prp => prp.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pndtTesting = subjectDetails.pndtTesting.FirstOrDefault(pn => pn.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var postPndtCounselling = subjectDetails.postPndtCounselling.FirstOrDefault(pop => pop.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var mtpService = subjectDetails.mtpService.FirstOrDefault(ms => ms.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    subjectRegistration.PrimaryDetail = primarySubject;
                    subjectRegistration.AddressDetail = address;
                    subjectRegistration.PregnancyDetail = pregnancy;
                    subjectRegistration.ParentDetail = parent;
                    subjectRegistration.prePndtCounselling = prePndtCounselling;
                    subjectRegistration.pndtTesting = pndtTesting;
                    subjectRegistration.postPndtCounselling = postPndtCounselling;
                    subjectRegistration.mtpService = mtpService;
                    subjectRegistrations.Add(subjectRegistration);
                }

                subjectRegistrationResponse.SubjectsDetail = subjectRegistrations;
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

        public async Task<SubjectRegistrationResponse> RetrieveParticularSubjectDetail(SubjectsDetailRequest sdData)
        {
            var subjectRegistrationResponse = new SubjectRegistrationResponse();
            var subjectRegistrations = new List<SubjectsDetail>();
            try
            {
                var subjectDetails = _subjectData.RetrieveParticularSubjectDetail(sdData);
                foreach (var primarySubject in subjectDetails.PrimarySubjectList)
                {
                    var subjectRegistration = new SubjectsDetail();
                    var address = subjectDetails.AddressSubjectList.FirstOrDefault(ad => ad.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pregnancy = subjectDetails.PregnancySubjectList.FirstOrDefault(pr => pr.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var parent = subjectDetails.ParentSubjectList.FirstOrDefault(pa => pa.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    var prePndtCounselling = subjectDetails.prePndtCounselling.FirstOrDefault(prp => prp.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pndtTesting = subjectDetails.pndtTesting.FirstOrDefault(pn => pn.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var postPndtCounselling = subjectDetails.postPndtCounselling.FirstOrDefault(pop => pop.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var mtpService = subjectDetails.mtpService.FirstOrDefault(ms => ms.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    subjectRegistration.PrimaryDetail = primarySubject;
                    subjectRegistration.AddressDetail = address;
                    subjectRegistration.PregnancyDetail = pregnancy;
                    subjectRegistration.ParentDetail = parent;
                    subjectRegistration.prePndtCounselling = prePndtCounselling;
                    subjectRegistration.pndtTesting = pndtTesting;
                    subjectRegistration.postPndtCounselling = postPndtCounselling;
                    subjectRegistration.mtpService = mtpService;
                    subjectRegistrations.Add(subjectRegistration);
                }

                subjectRegistrationResponse.SubjectsDetail = subjectRegistrations;
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

        public async Task<SubjectRegistrationResponse> RetrieveSubjectDetail(SubjectDetailRequest sdData)
        {
            var subjectRegistrationResponse = new SubjectRegistrationResponse();
            var subjectRegistrations = new List<SubjectsDetail>();
            try
            {
                var subjectDetails = _subjectData.RetrieveSubjectDetail(sdData);
                foreach (var primarySubject in subjectDetails.PrimarySubjectList)
                {
                    var subjectRegistration = new SubjectsDetail();
                    var address = subjectDetails.AddressSubjectList.FirstOrDefault(ad => ad.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pregnancy = subjectDetails.PregnancySubjectList.FirstOrDefault(pr => pr.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var parent = subjectDetails.ParentSubjectList.FirstOrDefault(pa => pa.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    var prePndtCounselling = subjectDetails.prePndtCounselling.FirstOrDefault(prp => prp.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var pndtTesting = subjectDetails.pndtTesting.FirstOrDefault(pn => pn.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var postPndtCounselling = subjectDetails.postPndtCounselling.FirstOrDefault(pop => pop.uniqueSubjectId == primarySubject.uniqueSubjectId);
                    var mtpService = subjectDetails.mtpService.FirstOrDefault(ms => ms.uniqueSubjectId == primarySubject.uniqueSubjectId);

                    subjectRegistration.PrimaryDetail = primarySubject;
                    subjectRegistration.AddressDetail = address;
                    subjectRegistration.PregnancyDetail = pregnancy;
                    subjectRegistration.ParentDetail = parent;
                    subjectRegistration.prePndtCounselling = prePndtCounselling;
                    subjectRegistration.pndtTesting = pndtTesting;
                    subjectRegistration.postPndtCounselling = postPndtCounselling;
                    subjectRegistration.mtpService = mtpService;
                    subjectRegistrations.Add(subjectRegistration);
                }

                subjectRegistrationResponse.SubjectsDetail = subjectRegistrations;
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
