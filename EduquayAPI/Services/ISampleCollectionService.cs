using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services
{
    public interface ISampleCollectionService
    {
        Task<ServiceResponse> AddSample(AddSubjectSampleRequest ssData);
        // string AddSample(AddSubjectSampleRequest  ssData);
        List<SubjectSamples> Retrieve(SubjectSampleRequest ssData);
    }
}
