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

        public List<SubjectAddresDetail> RetrieveAddressDetail(SubjectRequest sData)
        {
            var subjectAddress = _subjectData.RetrieveAddressDetail(sData);
            return subjectAddress;
        }

        public List<ANWSubjectDetail> RetrieveANWDetail(ANWSubjectRequest asData)
        {
            var anwSubjects = _subjectData.RetrieveANWDetail(asData);
            return anwSubjects;
        }

        public List<SubjectParentDetail> RetrieveParentDetail(SubjectRequest sData)
        {
            var subjectParent = _subjectData.RetrieveParentDetail(sData);
            return subjectParent;
        }

        public List<SubjectPregnancyDetail> RetrievePregnancyDetail(SubjectRequest sData)
        {
            var subjectPregnancy = _subjectData.RetrievePregnancyDetail(sData);
            return subjectPregnancy;
        }

        public List<SubjectPrimaryDetail> RetrievePrimaryDetail(SubjectRequest sData)
        {
            var subjectPrimary = _subjectData.RetrievePrimaryDetail(sData);
            return subjectPrimary;
        }
    }
}
