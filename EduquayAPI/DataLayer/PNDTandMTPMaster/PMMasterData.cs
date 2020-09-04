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
        private const string FetchAllCounsellor = "SPC_FetchAllCounsellor";
        private const string FetchAllPNDTObstetrician = "SPC_FetchAllPNDTObstetrician";
        private const string FetchAllDistrictss = "SPC_FetchAllDistrictss";
        private const string FetchAllProcedureOfTesting = "SPC_FetchAllProcedureOfTesting";
        private const string FetchAllPNDTComplecations = "SPC_FetchAllPNDTComplecations";
        private const string FetchAllPNDTDiagnosis = "SPC_FetchAllPNDTDiagnosis";
        private const string FetchAllPNDTResultMaster = "SPC_FetchAllPNDTResultMaster";
        private const string FetchAllMTPComplecations = "SPC_FetchAllMTPComplecations";
        private const string FetchAllMTPDischarge = "SPC_FetchAllMTPDischarge";


        public PMMasterData()
        {

        }

        public List<PMMaster> GetAllDistricts()
        {
            string stProc = FetchAllDistrictss;
            var pList = new List<SqlParameter>();
            var districtData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return districtData;
        }

        public List<PMMaster> GetAllMTPDischargeCondition()
        {
            string stProc = FetchAllMTPDischarge;
            var pList = new List<SqlParameter>();
            var districtData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return districtData;
        }

        public List<PMMaster> GetAllMTPComplications()
        {
            string stProc = FetchAllMTPComplecations;
            var pList = new List<SqlParameter>();
            var districtData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return districtData;
        }

        public List<PMMaster> GetAllPNDTComplecations()
        {
            string stProc = FetchAllPNDTComplecations;
            var pList = new List<SqlParameter>();
            var districtData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return districtData;
        }

        public List<PMMaster> GetAllPNDTDiagnosis()
        {
            string stProc = FetchAllPNDTDiagnosis;
            var pList = new List<SqlParameter>();
            var districtData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return districtData;
        }

        public List<PMMaster> GetAllPNDTResultMaster()
        {
            string stProc = FetchAllPNDTResultMaster;
            var pList = new List<SqlParameter>();
            var districtData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return districtData;
        }

        public List<PMMaster> GetAllProcedureofTesting()
        {
            string stProc = FetchAllProcedureOfTesting;
            var pList = new List<SqlParameter>();
            var potData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return potData;
        }

        public List<PMMaster> GetANMbyPHC(int id)
        {
            string stProc = FetchANMbyPHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var anmData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return anmData;
        }

        public List<PMMaster> GetCHCbyDistrict(int id)
        {
            string stProc = FetchCHCByDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var chcData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return chcData;
        }

        public List<PMMaster> GetCounsellor()
        {
            string stProc = FetchAllCounsellor;
            var pList = new List<SqlParameter>();
            var counsellorData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return counsellorData;
        }

        public List<PMMaster> GetPHCbyCHC(int id)
        {
            string stProc = FetchPHCByCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var phcData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return phcData;
        }

        public List<PMMaster> GetPNDTObstetrician()
        {
            string stProc = FetchAllPNDTObstetrician;
            var pList = new List<SqlParameter>();
            var pndtObsData = UtilityDL.FillData<PMMaster>(stProc, pList);
            return pndtObsData;
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
