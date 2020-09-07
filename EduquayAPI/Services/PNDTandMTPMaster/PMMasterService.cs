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

        public List<PMMaster> GetAllDistricts()
        {
            var pmMaster = _pmMasterData.GetAllDistricts();
            return pmMaster;
        }

        public List<PMMaster> GetAllMTPComplications()
        {
            var pmMaster = _pmMasterData.GetAllMTPComplications();
            return pmMaster;
        }

        public List<PMMaster> GetAllMTPDischargeCondition()
        {
            var pmMaster = _pmMasterData.GetAllMTPDischargeCondition();
            return pmMaster;
        }

        public List<PMMaster> GetAllPNDTComplecations()
        {
            var pmMaster = _pmMasterData.GetAllPNDTComplecations();
            return pmMaster;
        }

        public List<PMMaster> GetAllPNDTDiagnosis()
        {
            var pmMaster = _pmMasterData.GetAllPNDTDiagnosis();
            return pmMaster;
        }

        public List<PMMaster> GetAllPNDTResultMaster()
        {
            var pmMaster = _pmMasterData.GetAllPNDTResultMaster();
            return pmMaster;
        }

        public List<PMMaster> GetAllProcedureofTesting()
        {
            var pmMaster = _pmMasterData.GetAllProcedureofTesting();
            return pmMaster;
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

        public List<PMMaster> GetCounsellor()
        {
            var pmMaster = _pmMasterData.GetCounsellor();
            return pmMaster;
        }

        public List<PMMaster> GetPHCbyCHC(int id)
        {
            var pmMaster = _pmMasterData.GetPHCbyCHC(id);
            return pmMaster;
        }

        public List<PMMaster> GetPNDTObstetrician()
        {
            var pmMaster = _pmMasterData.GetPNDTObstetrician();
            return pmMaster;
        }

        public List<PMMaster> GetUserDistrict(int userId)
        {
            var pmMaster = _pmMasterData.GetUserDistrict(userId);
            return pmMaster;
        }
    }
}
