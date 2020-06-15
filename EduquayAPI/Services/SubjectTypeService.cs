using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public class SubjectTypeService : ISubjectTypeService
    {
        private readonly ISubjectTypeData _subjectTypeData;

        public SubjectTypeService(ISubjectTypeDataFactory subjecttypeDataFactory)
        {
            _subjectTypeData = new SubjectTypeDataFactory().Create();
        }
        public string Add(SubjectTypeRequest stData)
        {
            try
            {
                if (stData.isActive.ToLower() != "true")
                {
                    stData.isActive = "false";
                }
                var result = _subjectTypeData.Add(stData);
                return string.IsNullOrEmpty(result) ? $"Unable to add subject type data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add subject type data - {e.Message}";
            }
        }

        public List<SubjectType> Retrieve(int code)
        {
            var subjectType = _subjectTypeData.Retrieve(code);
            return subjectType;
        }

        public List<SubjectType> Retrieve()
        {
            var allSubjectTypes = _subjectTypeData.Retrieve();
            return allSubjectTypes;
        }
    }
}
