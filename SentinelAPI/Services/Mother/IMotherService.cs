using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Response.Mother;
using SentinelAPI.Models.Mother;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Mother
{
    public interface IMotherService
    {
        Task<AddMotherResponse> AddMotherDetail(AddMotherRequest mrData);
       Task<FetchMotherResponse> RetrieveMother(FetchMotherRequest fmData);
    }
}
