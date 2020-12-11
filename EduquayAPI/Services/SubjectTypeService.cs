using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Response.Masters;

namespace EduquayAPI.Services
{
    public class SubjectTypeService : ISubjectTypeService
    {
        private readonly ISubjectTypeData _subjectTypeData;

        public SubjectTypeService(ISubjectTypeDataFactory subjecttypeDataFactory)
        {
            _subjectTypeData = new SubjectTypeDataFactory().Create();
        }
        public async Task<AddEditResponse> Add(SubjectTypeRequest stData)
        {
            var response = new AddEditResponse();
            try
            {
                if (stData.isActive.ToLower() != "true")
                {
                    stData.isActive = "false";
                }
                if (string.IsNullOrEmpty(stData.subectTypeName))
                {
                    response.Status = "false";
                    response.Message = "Please enter subject type name";
                }
                else
                {

                    var addEditResponse = _subjectTypeData.Add(stData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
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
