using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.DataLayer.MobileSubject;
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
    }
}

