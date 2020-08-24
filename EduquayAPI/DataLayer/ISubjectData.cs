using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface ISubjectData
    {
        UniqueIdDetail AddSubject(SubjectRegistrationRequest subRegData);
        List<ANWSubjectDetail> RetrieveANWDetail(ANWSubjectRequest asData);
        List<CHCANWSubjectDetail> RetrieveCHCANWDetail(CHCANWSubjectRequest casData);
        public SubjectDetails RetrieveSubjectDetail(SubjectDetailRequest sdData);
        public SubjectDetails RetrieveCHCSubjectDetail(SubjectDetailRequest sdData);
        public SubjectDetails RetrieveParticularSubjectDetail(SubjectsDetailRequest sdData);
        public SubjectDetails RetrieveParticularCHCSubjectDetail(SubjectsDetailRequest sdData);
    }
    public interface ISubjectDataFactory
    {
        ISubjectData Create();
    }
    public class SubjectDataFactory : ISubjectDataFactory
    {
        public ISubjectData Create()
        {
            return new SubjectData();
        }
    }
}
