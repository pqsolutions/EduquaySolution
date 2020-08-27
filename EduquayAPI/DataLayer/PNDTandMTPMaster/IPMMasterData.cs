using EduquayAPI.Models.PMMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDTandMTPMaster
{
    public interface IPMMasterData
    {
        List<PMMaster> GetUserDistrict(int userId);
        List<PMMaster> GetCHCbyDistrict(int id);
        List<PMMaster> GetPHCbyCHC(int id);
        List<PMMaster> GetANMbyPHC(int id);
    }

    public interface IPMMasterDataFactory
    {
        IPMMasterData Create();
    }
    public class PMMasterDataFactory : IPMMasterDataFactory
    {
        public IPMMasterData Create()
        {
            return new PMMasterData();
        }
    }
}
