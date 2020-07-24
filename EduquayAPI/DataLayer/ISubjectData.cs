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
        List<SubjectPrimaryDetail> RetrievePrimaryDetail(SubjectRequest sData);
        List<SubjectAddresDetail> RetrieveAddressDetail(SubjectRequest sData);
        List<SubjectPregnancyDetail> RetrievePregnancyDetail(SubjectRequest sData);
        List<SubjectParentDetail> RetrieveParentDetail(SubjectRequest sData);
        List<ANWSubjectDetail> RetrieveANWDetail(ANWSubjectRequest asData);
        List<CHCANWSubjectDetail> RetrieveCHCANWDetail(CHCANWSubjectRequest casData);


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
