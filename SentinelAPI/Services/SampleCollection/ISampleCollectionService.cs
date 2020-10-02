using SentinelAPI.Contracts.V1.Request.SampleCollection;
using SentinelAPI.Contracts.V1.Response;
using SentinelAPI.Models.SampleCollection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.SampleCollection
{
    public interface ISampleCollectionService
    {
        Task<ServiceResponse> AddSample(AddSampleCollectionRequest scData);
        List<SampleCollectionList> RetriveBabiesList(SampleCollectionRequest scData);
    }
}
