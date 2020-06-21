using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using EduquayAPI.Contracts.V1.Response.ANMSubjectRegistration;
using EduquayAPI.Models.ANMSubjectRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MobileSubject
{
    public interface IMobileSubjectData
    {
        string AddSubject(AddSubjectRequest subRegData);
        Task<SubRegSuccessResponse> AddSubjectRegistration(AddSubjectRequest subRegData);
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
