using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.DataLayer.MobileSubject;
using EduquayAPI.Models.ANMSubjectRegistration;
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
        public string AddSubject(AddSubjectRequest subRegData)
        {
            try
            {
                var result = _mobileSubjectData.AddSubject(subRegData);
                return string.IsNullOrEmpty(result) ? $"Unable to generate subject detail" : result;
            }

            catch (Exception e)
            {
                return $"Unable to generate subject detail - {e.Message}";
            }
        }

        public async Task<SubRegSuccessResponse> AddSubjectRegistration(AddSubjectRequest subRegData)
        {
            var result = await _mobileSubjectData.AddSubjectRegistration(subRegData);
            try
            {

                return new SubRegSuccessResponse
                {
                    Status = result.Status,
                    Message = result.Message,
                    UniqueSubjectId = result.UniqueSubjectId,
                };
            }
            catch (Exception e)
            {
                return new SubRegSuccessResponse
                {
                    Status = result.Status,
                    Message = result.Message,
                    UniqueSubjectId = result.UniqueSubjectId,
                };
            }
        }
    }
}

