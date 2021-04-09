using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Models.AdminiSupport;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.SA
{
    public class SAData: ISAData
    {
        #region State Master Declaration
        private const string FetchAllStates = "SPC_FetchAllStates";
        private const string FetchState = "SPC_FetchState";
        private const string AddState = "SPC_SA_AddState";
        private const string UpdateState = "SPC_SA_UpdateState";
        #endregion

        #region State Master 
        public AddUpdateMaster AddStateDetail(AddStateRequest sData)
        {
            try
            {
                string stProc = AddState;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@State_gov_code", sData.stateGovCode ?? sData.stateGovCode),
                    new SqlParameter("@Statename", sData.name ?? sData.name),
                    new SqlParameter("@Shortname", sData.shortName ?? sData.shortName),
                    new SqlParameter("@Comments", sData.comments ?? sData.comments),
                    new SqlParameter("@UserId", sData.userId),
                };
                var returnData = UtilityDL.FillEntity<AddUpdateMaster>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<StateDetails> RetrieveAllStates()
        {
            string stProc = FetchAllStates;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<StateDetails>(stProc, pList);
            return allData;
        }
        public List<StateDetails> RetrieveStateById(int id)
        {
            string stProc = FetchState;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<StateDetails>(stProc, pList);
            return allData;
        }
        public AddUpdateMaster UpdateStatedetail(UpdateStateRequest sData)
        {
            try
            {
                string stProc = UpdateState;
                var pList = new List<SqlParameter>
                {
                     new SqlParameter("@Id", sData.Id ),
                    new SqlParameter("@State_gov_code", sData.stateGovCode ?? sData.stateGovCode),
                    new SqlParameter("@Statename", sData.name ?? sData.name),
                    new SqlParameter("@Shortname", sData.shortName ?? sData.shortName),
                    new SqlParameter("@Isactive", sData.isActive),
                    new SqlParameter("@Comments", sData.comments ?? sData.comments),
                    new SqlParameter("@UserId", sData.userId),
                };
                var returnData = UtilityDL.FillEntity<AddUpdateMaster>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion

        #region District Master Declaration
        private const string FetchAllDistricts = "SPC_FetchAllDistrictDetail";
        private const string FetchDistrict = "SPC_FetchDistrictDetail";
        private const string AddDistrict = "SPC_SA_AddDistrict";
        private const string UpdateDistrict = "SPC_SA_UpdateDistrict";
        #endregion

        #region District Master 
        public AddUpdateMaster AddDistrictDetail(AddDistrictRequest data)
        {
            try
            {
                string stProc = AddDistrict;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@District_gov_code", data.districtGovCode ?? data.districtGovCode),
                    new SqlParameter("@Districtname", data.name ?? data.name),
                    new SqlParameter("@StateID", data.stateId ),
                    new SqlParameter("@Comments", data.comments ?? data.comments),
                    new SqlParameter("@UserId", data.userId),
                };
                var returnData = UtilityDL.FillEntity<AddUpdateMaster>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public List<DistrictDetail> RetrieveAllDistricts()
        {
            string stProc = FetchAllDistricts;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<DistrictDetail>(stProc, pList);
            return allData;

        }
        public List<DistrictDetail> RetrieveDistrictById(int id)
        {
            string stProc = FetchDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<DistrictDetail>(stProc, pList);
            return allData;
        }
        public AddUpdateMaster UpdateDistrictDetail(UpdateDistrictRequest data)
        {
            try
            {
                string stProc = UpdateDistrict;
                var pList = new List<SqlParameter>
                {
                     new SqlParameter("@Id", data.Id ),
                    new SqlParameter("@District_gov_code", data.districtGovCode ?? data.districtGovCode),
                    new SqlParameter("@Districtname", data.name ?? data.name),
                    new SqlParameter("@StateID", data.stateId ),
                    new SqlParameter("@Isactive", data.isActive),
                    new SqlParameter("@Comments", data.comments ?? data.comments),
                    new SqlParameter("@UserId", data.userId),
                };
                var returnData = UtilityDL.FillEntity<AddUpdateMaster>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        #endregion
    }
}
