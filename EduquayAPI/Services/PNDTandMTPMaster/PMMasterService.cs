using EduquayAPI.Contracts.V1.Response.PMMasters;
using EduquayAPI.DataLayer.PNDTandMTPMaster;
using EduquayAPI.Models.PMMaster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.PNDTandMTPMaster
{
    public class PMMasterService : IPMMasterService
    {
        private readonly IPMMasterData _pmMasterData;

        public PMMasterService(IPMMasterDataFactory pmMasterData)
        {
            _pmMasterData = new PMMasterDataFactory().Create();
        }

        public List<PMMaster> GetANMbyPHC(int id)
        {
            var pmMaster = _pmMasterData.GetANMbyPHC(id);
            return pmMaster;
        }

        public List<PMMaster> GetCHCbyDistrict(int id)
        {
            var pmMaster = _pmMasterData.GetCHCbyDistrict(id);
            return pmMaster;
        }

        public List<PMMaster> GetPHCbyCHC(int id)
        {
            var pmMaster = _pmMasterData.GetPHCbyCHC(id);
            return pmMaster;
        }

        public List<PMMaster> GetUserDistrict(int userId)
        {
            var pmMaster = _pmMasterData.GetUserDistrict(userId);
            return pmMaster;
        }
    }
}
