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
        private const string FetchRI = "SPC_FetchRIByPincode";



        public WebMasterData()
        {

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

        public List<LoadReligion> RetrieveReligion()
        {
            string stProc = FetchAllReligion;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadReligion>(stProc, pList);
            return allData;
        }

        public List<LoadRIs> RetrieveRI(string pincode)
        {
            string stProc = FetchRI;
            var pList = new List<SqlParameter>() { new SqlParameter("@Pincode", pincode) };
            var allData = UtilityDL.FillData<LoadRIs>(stProc, pList);
            return allData;
        }

      
    }
}
