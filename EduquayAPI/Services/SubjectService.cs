using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
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
        public string AddSubject(SubjectRegistrationRequest subRegData)
        {
            try
            {
                if (subRegData.subjectPrimaryRequest.districtId <= 0)
                {
                    return "Invalid District Id";
                }
                if (subRegData.subjectPrimaryRequest.chcId <= 0)
                {
                    return "Invalid CHC Id";
                }
                if (subRegData.subjectPrimaryRequest.riId <= 0)
                {
                    return "Invalid RI Id";
                }

                var result = _subjectData.AddSubject(subRegData);
                return string.IsNullOrEmpty(result) ? $"Unable to generate subject detail" : result;
            }
            catch (Exception e)
            {
                return $"Unable to generate subject detail - {e.Message}";
            }

        }

        public List<SubjectAddresDetail> RetrieveAddressDetail(SubjectRequest sData)
        {
            var subjectAddress = _subjectData.RetrieveAddressDetail(sData);
            return subjectAddress;
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
