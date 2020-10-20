using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Request.Profile;
using SentinelAPI.Contracts.V1.Response.Baby;
using SentinelAPI.Contracts.V1.Response.Mother;
using SentinelAPI.Contracts.V1.Response.Profile;
using SentinelAPI.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Profile
{
    public interface IProfileService
    {
        Task<MotherProfileResponse> RetrieveMother(FetchMotherRequest fmData);
        Task<MotherProfileResponse> RetrieveAllMother(FetchAllMotherRequest fmData);
        Task<AddMotherResponse> UpdateMother(MotherUpdateRequest mrData);
        List<BabyProfile> RetrieveAllBabies(FetchAllMotherRequest fmData);
        List<BabyProfile> RetrieveBabies(FetchBabiesRequest fmData);
        Task<AddBabyResponse> UpdateBaby(UpdateBabyRequest brData);
    }
}
