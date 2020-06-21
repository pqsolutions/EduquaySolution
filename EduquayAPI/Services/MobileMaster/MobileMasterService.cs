using EduquayAPI.DataLayer.MobileMaster;
using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.MobileMaster
{
    public class MobileMasterService : IMobileMasterService
    {
        private readonly IMobileMasterData _mobileMasterData;

        public MobileMasterService(IMobileMasterDataFactory mobileMasterDataFactory)
        {
            _mobileMasterData = new MobileMasterDataFactory().Create();
        }
        public List<LoadCaste> RetrieveCaste()
        {
            var allCastes = _mobileMasterData.RetrieveCaste();
            return allCastes;
        }

        public List<LoadCHCs> RetrieveCHC(int userId)
        {
            var chc = _mobileMasterData.RetrieveCHC(userId);
            return chc;
        }

        public List<LoadCommunity> RetrieveCommunity(int id)
        {
            var community = _mobileMasterData.RetrieveCommunity(id);
            return community;
        }

        public List<LoadCommunity> RetrieveCommunity()
        {
            var allCommunity = _mobileMasterData.RetrieveCommunity();
            return allCommunity;
        }

        public List<LoadConstantValues> RetrieveConstantValues()
        {
            var allConstant = _mobileMasterData.RetrieveConstantValues();
            return allConstant;
        }

        public List<LoadDistricts> RetrieveDistrict(int userId)
        {
            var district = _mobileMasterData.RetrieveDistrict(userId);
            return district;
        }

        public List<LoadGovIDType> RetrieveGovIDType()
        {
            var allGovIDType = _mobileMasterData.RetrieveGovIDType();
            return allGovIDType;
        }

        public List<LoadPHCs> RetrievePHC(int userId)
        {
            var phc = _mobileMasterData.RetrievePHC(userId);
            return phc;
        }

        public List<LoadReligion> RetrieveReligion()
        {
            var allReligion = _mobileMasterData.RetrieveReligion();
            return allReligion;
        }

        public List<LoadRIs> RetrieveRI(int userId)
        {
            var ri = _mobileMasterData.RetrieveRI(userId);
            return ri;
        }

        public List<LoadSCs> RetrieveSC(int userId)
        {
            var sc = _mobileMasterData.RetrieveSC(userId);
            return sc;
        }
    }
}
