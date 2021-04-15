using EduquayAPI.Contracts.V1.Request.AdminSupport;
using EduquayAPI.Models;
using EduquayAPI.Models.AdminiSupport;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.SA
{
    public class SAData : ISAData
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

        #region District Master Declaration
        private const string FetchAllBlocks = "SPC_FetchAllBlockDetail";
        private const string FetchBlock = "SPC_FetchBlockDetail";
        private const string AddBlock = "SPC_SA_AddBlock";
        private const string UpdateBlock = "SPC_SA_UpdateBlock";
        #endregion

        #region Block Master 
        public AddUpdateMaster AddBlockDetail(AddBlockRequest data)
        {
            try
            {
                string stProc = AddBlock;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Block_gov_code", data.blockGovCode ?? data.blockGovCode),
                    new SqlParameter("@Blockname", data.name ?? data.name),
                    new SqlParameter("@DistrictID", data.districtId ),
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
        public AddUpdateMaster UpdateBlockDetail(UpdateBlockRequest data)
        {
            try
            {
                string stProc = UpdateBlock;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Id", data.Id ),
                    new SqlParameter("@Block_gov_code", data.blockGovCode ?? data.blockGovCode),
                    new SqlParameter("@Blockname", data.name ?? data.name),
                    new SqlParameter("@DistrictID", data.districtId ),
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
        public List<BlockDetail> RetrieveBlockById(int id)
        {
            string stProc = FetchBlock;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<BlockDetail>(stProc, pList);
            return allData;
        }
        public List<BlockDetail> RetrieveAllBlocks()
        {
            string stProc = FetchAllBlocks;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<BlockDetail>(stProc, pList);
            return allData;
        }
        #endregion

        #region CHC Master Declaration
        private const string FetchAllCHCs = "SPC_FetchAllCHCDetail";
        private const string FetchCHC = "SPC_FetchCHCDetail";
        private const string AddCHC = "SPC_SA_AddCHC";
        private const string UpdateCHC = "SPC_SA_UpdateCHC";
        #endregion

        #region CHC Master 
        public AddUpdateMaster AddCHCDetail(AddCHCRequest data)
        {
            try
            {
                string stProc = AddCHC;
                var pList = new List<SqlParameter>
                {

                    new SqlParameter("@BlockID", data.blockId),
                    new SqlParameter("@DistrictID", data.districtId),
                    new SqlParameter("@HNIN_ID", data.hninId ?? data.hninId),
                    new SqlParameter("@CHC_gov_code", data.chcGovCode),
                    new SqlParameter("@CHCname", data.name  ?? data.name),
                    new SqlParameter("@Istestingfacility", data.isTestingFacility ),
                    new SqlParameter("@TestingCHCID", data.testingCHCId),
                    new SqlParameter("@CentralLabId", data.centralLabId),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public AddUpdateMaster UpdateCHCDetail(UpdateCHCRequest data)
        {
            try
            {
                string stProc = UpdateCHC;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Id", data.id),
                    new SqlParameter("@BlockID", data.blockId),
                    new SqlParameter("@DistrictID", data.districtId),
                    new SqlParameter("@HNIN_ID", data.hninId ?? data.hninId),
                    new SqlParameter("@CHC_gov_code", data.chcGovCode),
                    new SqlParameter("@CHCname", data.name  ?? data.name),
                    new SqlParameter("@Istestingfacility", data.isTestingFacility),
                    new SqlParameter("@TestingCHCID", data.testingCHCId),
                    new SqlParameter("@CentralLabId", data.centralLabId),
                    new SqlParameter("@IsActive", data.isActive),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public List<CHCDetail> RetrieveCHCById(int id)
        {
            string stProc = FetchCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<CHCDetail>(stProc, pList);
            return allData;
        }
        public List<CHCDetail> RetrieveAllCHCs()
        {
            string stProc = FetchAllCHCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<CHCDetail>(stProc, pList);
            return allData;
        }
        #endregion

        #region PHC Master Declaration
        private const string FetchAllPHCs = "SPC_FetchAllPHCDetail";
        private const string FetchPHC = "SPC_FetchPHCDetail";
        private const string AddPHC = "SPC_SA_AddPHC";
        private const string UpdatePHC = "SPC_SA_UpdatePHC";
        #endregion

        #region PHC Master 
        public AddUpdateMaster AddPHCDetail(AddPHCRequest data)
        {
            try
            {
                string stProc = AddPHC;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@PHC_gov_code", data.phcGovCode),
                    new SqlParameter("@PHCname", data.name  ?? data.name),
                    new SqlParameter("@HNIN_ID", data.hninId ?? data.hninId),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public AddUpdateMaster UpdatePHCDetail(UpdatePHCRequest data)
        {
            try
            {
                string stProc = UpdatePHC;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Id", data.id),
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@PHC_gov_code", data.phcGovCode),
                    new SqlParameter("@PHCname", data.name  ?? data.name),
                    new SqlParameter("@HNIN_ID", data.hninId ?? data.hninId),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@IsActive", data.isActive),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public List<PHCDetail> RetrievePHCById(int id)
        {
            string stProc = FetchPHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<PHCDetail>(stProc, pList);
            return allData;
        }
        public List<PHCDetail> RetrieveAllPHCs()
        {
            string stProc = FetchAllPHCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<PHCDetail>(stProc, pList);
            return allData;
        }
        #endregion

        #region SC Master Declaration
        private const string FetchAllSCs = "SPC_FetchAllSCDetail";
        private const string FetchSC = "SPC_FetchSCDetail";
        private const string AddSC = "SPC_SA_AddSC";
        private const string UpdateSC = "SPC_SA_UpdateSC";
        #endregion

        #region SC Master 
        public AddUpdateMaster AddSCDetail(AddSCRequest data)
        {
            try
            {
                string stProc = AddSC;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@PHCID", data.phcId),
                    new SqlParameter("@PHC_gov_code", data.scGovCode),
                    new SqlParameter("@SCname", data.name  ?? data.name),
                    new SqlParameter("@HNIN_ID", data.hninId ?? data.hninId),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@SCAddress", data.scAddress.ToCheckNull()),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public AddUpdateMaster UpdateSCDetail(UpdateSCRequest data)
        {
            try
            {
                string stProc = UpdateSC;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@ID", data.id),
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@PHCID", data.phcId),
                    new SqlParameter("@PHC_gov_code", data.scGovCode),
                    new SqlParameter("@SCname", data.name  ?? data.name),
                    new SqlParameter("@HNIN_ID", data.hninId ?? data.hninId),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@SCAddress", data.scAddress.ToCheckNull()),
                    new SqlParameter("@IsActive", data.isActive),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public List<SCDetail> RetrieveSCById(int id)
        {
            string stProc = FetchSC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<SCDetail>(stProc, pList);
            return allData;
        }
        public List<SCDetail> RetrieveAllSCs()
        {
            string stProc = FetchAllSCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<SCDetail>(stProc, pList);
            return allData;
        }
        #endregion

        #region ILR Master Declaration
        private const string FetchAllILR = "SPC_FetchAllILRDetail";
        private const string FetchILR = "SPC_FetchILRDetail";
        private const string AddILR = "SPC_SA_AddILR";
        private const string UpdateILR = "SPC_SA_UpdateILR";
        #endregion

        #region ILR Master 
        public AddUpdateMaster AddILRDetail(AddILRRequest data)
        {
            try
            {
                string stProc = AddILR;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@ILRCode", data.ilrCode),
                    new SqlParameter("@ILRPoint", data.name  ?? data.name),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public AddUpdateMaster UpdateILRDetail(UpdateILRRequest data)
        {
            try
            {
                string stProc = UpdateILR;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@ID", data.id),
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@ILRCode", data.ilrCode),
                    new SqlParameter("@ILRPoint", data.name  ?? data.name),
                    new SqlParameter("@IsActive", data.isActive),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public List<ILRDetail> RetrieveILRById(int id)
        {
            string stProc = FetchILR;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<ILRDetail>(stProc, pList);
            return allData;
        }
        public List<ILRDetail> RetrieveAllILR()
        {
            string stProc = FetchAllILR;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<ILRDetail>(stProc, pList);
            return allData;
        }
        #endregion

        #region RI Master Declaration
        private const string FetchAllRI = "SPC_FetchAllRIDetail";
        private const string FetchRI = "SPC_FetchRIDetail";
        private const string AddRISite = "SPC_SA_AddRISite";
        private const string UpdateRISite = "SPC_SA_UpdateRISite";
        private const string FetchRIBySC = "SPC_FetchRIBySC";
        #endregion

        #region RI Site Master 
        public AddUpdateMaster AddRIDetail(AddRISiteRequest data)
        {
            try
            {
                string stProc = AddRISite;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@PHCID", data.phcId),
                    new SqlParameter("@SCID", data.scId),
                    new SqlParameter("@TestingCHCId", data.testingCHCId),
                    new SqlParameter("@RI_gov_code", data.riGovCode),
                    new SqlParameter("@RISite", data.name  ?? data.name),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@ILRId", data.ilrId),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public AddUpdateMaster UpdateRIDetail(UpdateRISiteRequest data)
        {
            try
            {
                string stProc = UpdateRISite;
                var pList = new List<SqlParameter>
                {
                     new SqlParameter("@ID", data.id),
                    new SqlParameter("@CHCID", data.chcId),
                    new SqlParameter("@PHCID", data.phcId),
                    new SqlParameter("@SCID", data.scId),
                    new SqlParameter("@TestingCHCId", data.testingCHCId),
                    new SqlParameter("@RI_gov_code", data.riGovCode),
                    new SqlParameter("@RISite", data.name  ?? data.name),
                    new SqlParameter("@Pincode", data.pincode.ToCheckNull()),
                    new SqlParameter("@ILRId", data.ilrId),
                    new SqlParameter("@IsActive", data.isActive),
                    new SqlParameter("@Latitude", data.latitude.ToCheckNull()),
                    new SqlParameter("@Longitude", data.longitude.ToCheckNull()),
                    new SqlParameter("@Comments", data.comments.ToCheckNull()),
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
        public List<RISiteDetail> RetrieveRIById(int id)
        {
            string stProc = FetchRI;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<RISiteDetail>(stProc, pList);
            return allData;
        }
        public List<RISiteDetail> RetrieveAllRI()
        {
            string stProc = FetchAllRI;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<RISiteDetail>(stProc, pList);
            return allData;
        }
        public List<RISiteDetail> RetrieveRIBySC(int id)
        {
            string stProc = FetchRIBySC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<RISiteDetail>(stProc, pList);
            return allData;
        }
        #endregion
    }
}
