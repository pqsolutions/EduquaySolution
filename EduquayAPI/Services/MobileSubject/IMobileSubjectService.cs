using EduquayAPI.Contracts.V1.Request.MobileAppSubjectRegistration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MobileSubject
{
    public interface IMobileSubjectService
    {
        string AddSubject(AddSubjectRequest subRegData);
    }
}
