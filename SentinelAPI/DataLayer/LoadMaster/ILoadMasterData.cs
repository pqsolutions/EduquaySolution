using SentinelAPI.Models.Masters.LoadMasters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.LoadMaster
{
    public interface ILoadMasterData
    {
        List<LoadDistricts> RetrieveDistrict(int userId);
        List<LoadHospitals> RetrieveHospital(int userId);
        List<LoadHospitals> RetrieveHospitalByDistrict(int districtId);
        List<LoadGovIdType> RetrieveGovIDType();
        List<LoadReligion> RetrieveReligion();
        List<LoadCaste> RetrieveCaste();
        List<LoadCommunity> RetrieveCommunity();
        List<LoadCommunity> RetrieveCommunity(int casteId);
        List<LoadBirthStatus> RetrieveBirthStatus();
        List<LoadMolecularLab> RetrieveMolecularLab();

    }

    public interface ILoadMasterDataFactory
    {
        ILoadMasterData Create();
    }
    public class LoadMasterDataFactory : ILoadMasterDataFactory
    {
        public ILoadMasterData Create()
        {
            return new LoadMasterData();
        }
    }
}
