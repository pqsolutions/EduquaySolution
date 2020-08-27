using EduquayAPI.Models;
using EduquayAPI.Models.PMMaster;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDTandMTPMaster
{
    public class PMMasterData:IPMMasterData
    {
        private const string FetchUserDistrict = "SPC_FetchUserDistrict";
        private const string FetchCHCByDistrict = "SPC_FetchCHCByDistrict";
        private const string FetchPHCByCHC = "SPC_FetchPHCByCHC";
        private const string FetchANMbyPHC = "SPC_FetchANMbyPHC";

        public PMMasterData()
        {

        }

        public List<PMMaster> GetANMbyPHC(int id)
        {
            string stProc = FetchANMbyPHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var chcData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return chcData;
        }

        public List<PMMaster> GetCHCbyDistrict(int id)
        {
            string stProc = FetchCHCByDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var chcData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return chcData;
        }

        public List<PMMaster> GetPHCbyCHC(int id)
        {
            string stProc = FetchPHCByCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var chcData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return chcData;
        }

        public List<PMMaster> GetUserDistrict(int userId)
        {
            string stProc = FetchUserDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var districtData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return districtData;
        }
    }
}
