using SentinelAPI.Contracts.V1.Request.Mother;
using SentinelAPI.Contracts.V1.Request.Profile;
using SentinelAPI.Models.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.Profile
{
    public interface IProfileData
    {
        ProfileMotherDetails RetrieveMother(FetchMotherRequest fmData);
        ProfileMotherDetails RetrieveAllMother(FetchAllMotherRequest fmData);
        MotherReturnDetail UpdateMother(MotherUpdateRequest mrData);
        List<BabyProfile> RetrieveAllBabies(FetchAllMotherRequest fmData);
        List<BabyProfile> RetrieveBabies(FetchBabiesRequest fmData);
        BabyReturnDetail UpdateBaby(UpdateBabyRequest brData);

    }
    public interface IProfileDataFactory
    {
        IProfileData Create();
    }
    public class ProfileDataFactory : IProfileDataFactory
    {
        public IProfileData Create()
        {
            return new ProfileData();
        }
    }
}
