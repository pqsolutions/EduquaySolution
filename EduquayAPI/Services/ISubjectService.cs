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
        Task<SubjectRegistrationResponse> RetrieveSubjectDetail(SubjectDetailRequest sdData);
        Task<SubjectRegistrationResponse> RetrieveCHCSubjectDetail(SubjectDetailRequest sdData);
        Task<SubjectRegistrationResponse> RetrieveParticularSubjectDetail(SubjectsDetailRequest sdData);
        Task<SubjectRegistrationResponse> RetrieveParticularCHCSubjectDetail(SubjectsDetailRequest sdData);

        List<ANWSubjectDetail> RetrieveANWDetail(ANWSubjectRequest asData);
        List<CHCANWSubjectDetail> RetrieveCHCANWDetail(CHCANWSubjectRequest casData);


    }
}
