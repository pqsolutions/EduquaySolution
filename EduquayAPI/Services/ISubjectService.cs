using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;
using EduquayAPI.Contracts.V1.Request;

namespace EduquayAPI.Services
{
    public interface ISubjectService
    {
        string AddSubject(SubjectPrimaryDetailRequest sprData, SubjectAddressDetailRequest saData, SubjectPregnancyDetailRequest spData, SubjectParentDetailRequest spaData);

        List<SubjectPrimaryDetail> RetrievePrimaryDetail(string uniqueSubjectId);
        List<SubjectAddresDetail> RetrieveAddressDetail(string uniqueSubjectId);
        List<SubjectPregnancyDetail> RetrievePregnancyDetail(string uniqueSubjectId);
        List<SubjectParentDetail> RetrieveParentDetail(string uniqueSubjectId);

    }
}
