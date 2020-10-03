using SentinelAPI.Models.Masters.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Master.LoadMaster
{
    public interface ILoadMasterService
    {
        List<LoadDistricts> RetrieveDistrict(int userId);
        List<LoadHospitals> RetrieveHospital(int userId);
        List<LoadGovIdType> RetrieveGovIDType();
        List<LoadReligion> RetrieveReligion();
        List<LoadCaste> RetrieveCaste();
        List<LoadCommunity> RetrieveCommunity();
        List<LoadCommunity> RetrieveCommunity(int casteId);
        List<LoadHospitals> RetrieveHospitalByDistrict(int districtId);
        List<LoadBirthStatus> RetrieveBirthStatus();
        List<LoadMolecularLab> RetrieveMolecularLab();
        List<LoadCommonMaster> RetrieveCollectionSite();
        List<LoadCommonMaster> RetrieveStates();

    }
}
