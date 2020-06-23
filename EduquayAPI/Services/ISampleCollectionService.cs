using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface ISampleCollectionService
    {
        string AddSample(AddSubjectSampleRequest  ssData);
        List<SubjectSamples> Retrieve(SubjectSampleRequest ssData);
        List<SampleSubject> Retrieve(SampleSubjectRequest ssData);
    }
}
