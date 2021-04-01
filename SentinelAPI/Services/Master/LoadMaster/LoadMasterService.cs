using SentinelAPI.DataLayer.LoadMaster;
using SentinelAPI.Models.Masters.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Master.LoadMaster
{
    public class LoadMasterService : ILoadMasterService
    {
        private readonly ILoadMasterData _loadMasterData;

        public LoadMasterService(ILoadMasterDataFactory loadMasterDataFactory)
        {
            _loadMasterData = new LoadMasterDataFactory().Create();
        }

        public List<LoadCommonMaster> GetAllMutuation()
        {
            var mutuation = _loadMasterData.GetAllMutuation();
            return mutuation;
        }

        public List<LoadCommonMaster> GetAllZygosity()
        {
            var zygosity = _loadMasterData.GetAllZygosity();
            return zygosity;
        }

        public List<LoadBirthStatus> RetrieveBirthStatus()
        {
            var allBirthStatus = _loadMasterData.RetrieveBirthStatus();
            return allBirthStatus;
        }

        public List<LoadCaste> RetrieveCaste()
        {
            var allCastes = _loadMasterData.RetrieveCaste();
            return allCastes;
        }

        public List<LoadCommonMaster> RetrieveCollectionSite()
        {
            var allData = _loadMasterData.RetrieveCollectionSite();
            return allData;
        }

        public List<LoadCommunity> RetrieveCommunity()
        {
            var allCommunitys = _loadMasterData.RetrieveCommunity();
            return allCommunitys;
        }

        public List<LoadCommunity> RetrieveCommunity(int casteId)
        {
            var communitys = _loadMasterData.RetrieveCommunity(casteId);
            return communitys;
        }

        public List<LoadCommonMaster> RetrieveDiagnosis()
        {
            var allData = _loadMasterData.RetrieveDiagnosis();
            return allData;
        }

        public List<LoadDistricts> RetrieveDistrict(int userId)
        {
            var district = _loadMasterData.RetrieveDistrict(userId);
            return district;
        }

        public List<LoadGovIdType> RetrieveGovIDType()
        {
            var allGovIdType = _loadMasterData.RetrieveGovIDType();
            return allGovIdType;
        }

        public List<LoadHospitals> RetrieveHospital(int userId)
        {
            var hospital = _loadMasterData.RetrieveHospital(userId);
            return hospital;
        }

        public List<LoadHospitals> RetrieveHospitalByDistrict(int districtId)
        {
            var hospital = _loadMasterData.RetrieveHospitalByDistrict(districtId);
            return hospital;
        }

        public List<LoadCommonMaster> RetrieveHospitalbyMolecularLab(int molecularLabId)
        {
            var hospital = _loadMasterData.RetrieveHospitalbyMolecularLab(molecularLabId);
            return hospital;
        }

        public List<LoadMolecularLab> RetrieveMolecularLab()
        {
            var allMLab = _loadMasterData.RetrieveMolecularLab();
            return allMLab;
        }

        public List<LoadReligion> RetrieveReligion()
        {
            var allReligions = _loadMasterData.RetrieveReligion();
            return allReligions;
        }

        public List<LoadCommonMaster> RetrieveResults()
        {
            var allData = _loadMasterData.RetrieveResults();
            return allData;
        }

        public List<LoadCommonMaster> RetrieveSampleStatus()
        {
            var allData = _loadMasterData.RetrieveSampleStatus();
            return allData;
        }

        public List<LoadCommonMaster> RetrieveStates()
        {
            var allData = _loadMasterData.RetrieveStates();
            return allData;
        }
    }
}
