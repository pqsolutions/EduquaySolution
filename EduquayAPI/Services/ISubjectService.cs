using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;

namespace EduquayAPI.Services
{
    public interface ISubjectService
    {

        Task<UniqueIdDetail> AddSubject(SubjectRegistrationRequest subRegData);
        List<SubjectPrimaryDetail> RetrievePrimaryDetail(SubjectRequest sData);
        List<SubjectAddresDetail> RetrieveAddressDetail(SubjectRequest sData);
        List<SubjectPregnancyDetail> RetrievePregnancyDetail(SubjectRequest sData);
        List<SubjectParentDetail> RetrieveParentDetail(SubjectRequest sData);
        List<ANWSubjectDetail> RetrieveANWDetail(ANWSubjectRequest asData);
        List<CHCANWSubjectDetail> RetrieveCHCANWDetail(CHCANWSubjectRequest casData);
    }
}
