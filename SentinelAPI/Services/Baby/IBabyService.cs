using SentinelAPI.Contracts.V1.Request.Baby;
using SentinelAPI.Contracts.V1.Response.Baby;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Baby
{
    public interface IBabyService
    {
        Task<AddBabyResponse> AddBabyDetail(AddBabyRequest brData);
    }
}
