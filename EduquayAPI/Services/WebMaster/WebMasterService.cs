using EduquayAPI.DataLayer.WebMaster;
using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.WebMaster
{
    public class WebMasterService : IWebMasterService
    {

        private readonly IWebMasterData _webMasterData;

        public WebMasterService(IWebMasterDataFactory webMasterDataFactory)
        {
            _webMasterData = new WebMasterDataFactory().Create();
        }

        public List<LoadAssociatedANM> RetrieveAssociatedANM(int riId)
        {
            var allANM = _webMasterData.RetrieveAssociatedANM(riId);
            return allANM;
        }

        public List<LoadCaste> RetrieveCaste()
        {
            var allCastes = _webMasterData.RetrieveCaste();
            return allCastes;
        }

        public List<LoadCHCs> RetrieveCHC(int userId)
        {
            var chc = _webMasterData.RetrieveCHC(userId);
            return chc;
        }

        public List<LoadCommunity> RetrieveCommunity(int id)
        {
            var community = _webMasterData.RetrieveCommunity(id);
            return community;
        }

        public List<LoadCommunity> RetrieveCommunity()
        {
            var allCommunity = _webMasterData.RetrieveCommunity();
            return allCommunity;
        }

        public List<LoadDistricts> RetrieveDistrict(int userId)
        {
            var district = _webMasterData.RetrieveDistrict(userId);
            return district;
        }

        public List<LoadGovIDType> RetrieveGovIDType()
        {
            var allGovIDType = _webMasterData.RetrieveGovIDType();
            return allGovIDType;
        }

        public List<LoadReligion> RetrieveReligion()
        {
            var allReligion = _webMasterData.RetrieveReligion();
            return allReligion;
        }

        public List<LoadRIs> RetrieveRI(string pincode)
        {
            var ri = _webMasterData.RetrieveRI(pincode);
            return ri;
        }
    }
}
