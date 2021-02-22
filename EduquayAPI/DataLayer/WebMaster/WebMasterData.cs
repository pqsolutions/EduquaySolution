using EduquayAPI.Models.LoadMasters;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.WebMaster
{
    public class WebMasterData : IWebMasterData
    {
        private const string FetchDistrict = "SPC_FetchDistrictByUser";
        private const string FetchCHC = "SPC_FetchCHCByUser";
        private const string FetchAllReligion = "SPC_FetchAllReligion";
        private const string FetchAllCaste = "SPC_FetchAllCaste";
        private const string FetchAllCommunity = "SPC_FetchAllCommunity";
        private const string FetchCommunity = "SPC_FetchCommunityByCaste";
        private const string FetchAllGovIdType = "SPC_FetchAllGovIDType";
        private const string FetchRI = "SPC_FetchRIByUser";
        private const string FetchPHC = "SPC_FetchPHCByUser";
        private const string FetchSC = "SPC_FetchSCByUser";
        private const string FetchAssociatedANM = "SPC_FetchAssociatedANMByRI";
        private const string FetchConstantValues = "SPC_FetchWebConstantData";
        private const string FetchILR = "SPC_FetchILRByRI";
        private const string FetchTestingCHC = "SPC_FetchTestingCHCByRI";
        private const string FetchAVD = "SPC_FetchAVDByRI";
        private const string FetchANM = "SPC_FetchAllAssociatedANMByCHC";
        private const string FetchStates = "SPC_FetchAllStates";
        private const string FetchLogisticsProvider = "SPC_FetchLogisticsProvider";
        private const string FetchTestingCHCByCHC = "SPC_FetchTestingCHCByCHC";
        private const string FetchMolecularLabLabByCentralLab = "SPC_FetchMolecularLabLabByCentralLab";
        private const string FetchCentralLabByCHC = "SPC_FetchCentralLabByCHC";
        private const string FetchAllMolecularResultMaster = "SPC_FetchAllMolecularResultMaster";
        private const string FetchAllCHCByTestingCHC = "SPC_FetchAllCHCByTestingCHC";
        private const string FetchAllCHCByCentralLab = "SPC_FetchAllCHCByCentralLab";
        private const string FetchBlockByDistrict = "SPC_FetchBlockByDistrict";
        private const string FetchCHCByBlock = "SPC_FetchCHCByBlock";
        private const string FetchANMByCHC = "SPC_FetchANMByCHC";
        private const string FetchRIByCHC = "SPC_FetchRIByCHC";
        private const string FetchPHCByCHC = "SPC_FetchPHCByCHC";
        private const string FetchAllPNDTLocation = "SPC_FetchAllPNDTLocation";
        private const string FetchAllZygosity = "SPC_FetchAllZygosity";
        private const string FetchAllMutation = "SPC_FetchAllMutation";
        public WebMasterData()
        {

        }
        public List<LoadCommon> GetAllZygosity()
        {
            string stProc = FetchAllZygosity;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }

        public List<LoadCommon> GetAllMutuation()
        {
            string stProc = FetchAllMutation;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }
        public List<LoadCommon> GetAllPNDTLocation()
        {
            string stProc = FetchAllPNDTLocation;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }

        public List<LoadAssociatedANM> RetrieveAssociatedANM(int riId)
        {
            string stProc = FetchAssociatedANM;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", riId) };
            var allData = UtilityDL.FillData<LoadAssociatedANM>(stProc, pList);
            return allData;
        }

        public List<LoadCaste> RetrieveCaste()
        {
            string stProc = FetchAllCaste;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCaste>(stProc, pList);
            return allData;
        }

        public List<LoadCHCs> RetrieveCHC(int userId)
        {
            string stProc = FetchCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadCHCs>(stProc, pList);
            return allData;
        }

        public List<LoadCommunity> RetrieveCommunity(int id)
        {
            string stProc = FetchCommunity;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", id) };
            var allData = UtilityDL.FillData<LoadCommunity>(stProc, pList);
            return allData;
        }

        public List<LoadCommunity> RetrieveCommunity()
        {
            string stProc = FetchAllCommunity;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCommunity>(stProc, pList);
            return allData;
        }

        public List<LoadConstantValues> RetrieveConstantValues(int userId)
        {
            string stProc = FetchConstantValues;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadConstantValues>(stProc, pList);
            return allData;
        }

        public List<LoadDistricts> RetrieveDistrict(int userId)
        {
            string stProc = FetchDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadDistricts>(stProc, pList);
            return allData;
        }

        public List<LoadGovIDType> RetrieveGovIDType()
        {
            string stProc = FetchAllGovIdType;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadGovIDType>(stProc, pList);
            return allData;
        }

        public List<LoadILR> RetrieveILR(int riId)
        {
            string stProc = FetchILR;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", riId) };
            var allData = UtilityDL.FillData<LoadILR>(stProc, pList);
            return allData;
        }

        public List<LoadCHCs> RetrieveTestingCHC(int riId)
        {
            string stProc = FetchTestingCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", riId) };
            var allData = UtilityDL.FillData<LoadCHCs>(stProc, pList);
            return allData;
        }

        public List<LoadReligion> RetrieveReligion()
        {
            string stProc = FetchAllReligion;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadReligion>(stProc, pList);
            return allData;
        }

        public List<LoadRIs> RetrieveRI(int userId)
        {
            string stProc = FetchRI;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadRIs>(stProc, pList);
            return allData;
        }
        public List<LoadAVD> RetrieveAVD(int riId)
        {
            string stProc = FetchAVD;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", riId) };
            var allData = UtilityDL.FillData<LoadAVD>(stProc, pList);
            return allData;
        }
        public List<LoadPHCs> RetrievePHC(int userId)
        {
            string stProc = FetchPHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadPHCs>(stProc, pList);
            return allData;
        }
        public List<LoadSCs> RetrieveSC(int userId)
        {
            string stProc = FetchSC;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadSCs>(stProc, pList);
            return allData;
        }

        public List<AssociatedSCRIANM> RetrieveAssociatedANMByCHC(int chcId)
        {
            string stProc = FetchANM;
            var pList = new List<SqlParameter>() { new SqlParameter("@CHCId", chcId) };
            var allData = UtilityDL.FillData<AssociatedSCRIANM>(stProc, pList);
            return allData;
        }

        public List<LoadState> RetrieveState()
        {
            string stProc = FetchStates;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadState>(stProc, pList);
            return allData;
        }

        public List<LoadLogisticsProvider> RetrieveLogisticsProvider()
        {
            string stProc = FetchLogisticsProvider ;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadLogisticsProvider>(stProc, pList);
            return allData;
        }

        public List<LoadCHCs> RetrieveTestingCHCbyCHC(int chcId)
        {
            string stProc = FetchTestingCHCByCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", chcId) };
            var allData = UtilityDL.FillData<LoadCHCs>(stProc, pList);
            return allData;
        }

        public List<LoadCentralLab> RetrieveCentralLabbyCHC(int chcId)
        {
            string stProc = FetchCentralLabByCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", chcId) };
            var allData = UtilityDL.FillData<LoadCentralLab>(stProc, pList);
            return allData;
        }

        public List<LoadMolecularLab> RetrieveMolecularLabbyCentralLab(int centralLabId)
        {
            string stProc = FetchMolecularLabLabByCentralLab;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", centralLabId) };
            var allData = UtilityDL.FillData<LoadMolecularLab>(stProc, pList);
            return allData;
        }

        public List<LoadMolecularResult> RetrieveMolecularResult()
        {
            string stProc = FetchAllMolecularResultMaster;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadMolecularResult>(stProc, pList);
            return allData;
        }

        public List<LoadCHCs> RetrieveCHCbyTestingCHC(int testingCHCId)
        {
            string stProc = FetchAllCHCByTestingCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", testingCHCId) };
            var allData = UtilityDL.FillData<LoadCHCs>(stProc, pList);
            return allData;
        }

        public List<LoadCHCs> RetrieveCHCbyCentralLab(int centralLabId)
        {
            string stProc = FetchAllCHCByCentralLab;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", centralLabId) };
            var allData = UtilityDL.FillData<LoadCHCs>(stProc, pList);
            return allData;
        }

        public List<LoadCommon> RetrieveBlocksByDistrict(int id)
        {

            string stProc = FetchBlockByDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }

        public List<LoadCommon> RetrieveCHCByBlock(int id)
        {
            string stProc = FetchCHCByBlock;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }

        public List<LoadCommon> RetrieveANMByCHC(int id)
        {
            string stProc = FetchANMByCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }

        public List<LoadCommon> RetrieveRIByCHC(int id)
        {
            string stProc = FetchRIByCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }

        public List<LoadCommon> RetrievePHCByCHC(int id)
        {
            string stProc = FetchPHCByCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@Id", id) };
            var allData = UtilityDL.FillData<LoadCommon>(stProc, pList);
            return allData;
        }

       
    }
}
