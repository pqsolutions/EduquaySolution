using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public interface ISubjectData
    {
        string AddSubject(SubjectRegistrationRequest subRegData);
        List<SubjectPrimaryDetail> RetrievePrimaryDetail(SubjectRequest sData);
        List<SubjectAddresDetail> RetrieveAddressDetail(SubjectRequest sData);
        List<SubjectPregnancyDetail> RetrievePregnancyDetail(SubjectRequest sData);
        List<SubjectParentDetail> RetrieveParentDetail(SubjectRequest sData);
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
