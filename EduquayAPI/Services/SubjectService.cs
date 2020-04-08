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
        public string AddSubject(SubjectPrimaryDetailRequest sprData, SubjectAddressDetailRequest saData, SubjectPregnancyDetailRequest spData, SubjectParentDetailRequest spaData)
        {
            try
            {
                if (sprData.DistrictID <= 0)
                {
                    return "Invalid District Id";
                }
                if (sprData.CHCID <= 0)
                {
                    return "Invalid CHC Id";
                }
                if (sprData.PHCID <= 0)
                {
                    return "Invalid PHC Id";
                }
                if (sprData.SCID <= 0)
                {
                    return "Invalid SC Id";
                }
                if (sprData.RIID <= 0)
                {
                    return "Invalid RI Id";
                }

                if (sprData.IsActive.ToLower() != "true")
                {
                    sprData.IsActive = "false";
                }

                var result = _subjectData.AddSubject(sprData,saData,spData,spaData);
                return string.IsNullOrEmpty(result) ? $"Unable to generate subject detail" : result;
            }
            catch (Exception e)
            {
                return $"Unable to generate subject detail - {e.Message}";
            }

        }

        public List<SubjectAddresDetail> RetrieveAddressDetail(string uniqueSubjectId)
        {
            var subjectAddress = _subjectData.RetrieveAddressDetail(uniqueSubjectId);
            return subjectAddress;
        }

        public List<SubjectParentDetail> RetrieveParentDetail(string uniqueSubjectId)
        {
            var subjectParent = _subjectData.RetrieveParentDetail(uniqueSubjectId);
            return subjectParent;
        }

        public List<SubjectPregnancyDetail> RetrievePregnancyDetail(string uniqueSubjectId)
        {
            var subjectPregnancy = _subjectData.RetrievePregnancyDetail(uniqueSubjectId);
            return subjectPregnancy;
        }

        public List<SubjectPrimaryDetail> RetrievePrimaryDetail(string uniqueSubjectId)
        {
            var subjectPrimary = _subjectData.RetrievePrimaryDetail(uniqueSubjectId);
            return subjectPrimary;
        }
    }
}
