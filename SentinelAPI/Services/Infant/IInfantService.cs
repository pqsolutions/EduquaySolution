using SentinelAPI.Contracts.V1.Request.Infant;
using SentinelAPI.Contracts.V1.Response.Infant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Infant
{
    public interface IInfantService
    {
        Task<AddInfantResponse> AddInfantDetail(AddInfantRequest irData);
        Task<InfantMotherResponse> RetrieveMother(GetMotherRequest mData);
    }
}
