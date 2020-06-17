using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.WebMaster
{
    public interface IWebMasterService
    {
        List<LoadDistricts> RetrieveDistrict(int userId);
        List<LoadCHCs> RetrieveCHC(int userId);
        List<LoadRIs> RetrieveRI(string pincode);
        List<LoadReligion> RetrieveReligion();
        List<LoadCaste> RetrieveCaste();
        List<LoadCommunity> RetrieveCommunity(int id);
        List<LoadCommunity> RetrieveCommunity();
        List<LoadGovIDType> RetrieveGovIDType();
        List<LoadAssociatedANM > RetrieveAssociatedANM(int riId);
    }
}
