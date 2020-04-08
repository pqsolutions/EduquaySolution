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
        string AddSubject(SubjectPrimaryDetailRequest sprData, SubjectAddressDetailRequest saData, SubjectPregnancyDetailRequest spData, SubjectParentDetailRequest spaData);
        List<SubjectPrimaryDetail> RetrievePrimaryDetail(string uniqueSubjectId);
        List<SubjectAddresDetail> RetrieveAddressDetail(string uniqueSubjectId);
        List<SubjectPregnancyDetail> RetrievePregnancyDetail(string uniqueSubjectId);
        List<SubjectParentDetail> RetrieveParentDetail(string uniqueSubjectId);
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
