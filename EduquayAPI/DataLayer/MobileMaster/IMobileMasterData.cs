using EduquayAPI.Models.LoadMasters;
using EduquayAPI.Models.MobileSubject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MobileMaster
{
    public interface IMobileMasterData
    {
        List<LoadDistricts> RetrieveDistrict(int userId);
        List<LoadCHCs> RetrieveCHC(int userId);
        List<LoadPHCs> RetrievePHC(int userId);
        List<LoadSCs> RetrieveSC(int userId);
        List<LoadMobileRI> RetrieveRI(int userId);
        List<LoadReligion> RetrieveReligion();
        List<LoadCaste> RetrieveCaste();
        List<LoadCommunity> RetrieveCommunity(int id); 
        List<LoadCommunity> RetrieveCommunity();
        List<LoadGovIDType> RetrieveGovIDType();
        List<LoadConstantValues> RetrieveConstantValues();
        List<LoadState> RetrieveState();
        Device CheckDevice(int userId, string deviceId);

    }

    public interface IMobileMasterDataFactory
    {
        IMobileMasterData Create();
    }
    public class MobileMasterDataFactory : IMobileMasterDataFactory
    {
        public IMobileMasterData Create()
        {
            return new MobileMasterData();
        }
    }
}
