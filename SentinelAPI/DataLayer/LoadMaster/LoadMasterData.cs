﻿using SentinelAPI.Models.Masters.LoadMasters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.LoadMaster
{
    public class LoadMasterData : ILoadMasterData
    {

        private const string FetchDistrict = "SPC_FetchDistrictByUser";
        private const string FetchHospital = "SPC_FetchHospitalByUser";
        private const string FetchHospitalByDistrict = "SPC_FetchAllHospitalByDistrict";
        private const string FetchAllReligion = "SPC_FetchAllReligion";
        private const string FetchAllCaste = "SPC_FetchAllCaste";
        private const string FetchAllCommunity = "SPC_FetchAllCommunity";
        private const string FetchCommunity = "SPC_FetchCommunityByCaste";
        private const string FetchAllGovIdType = "SPC_FetchAllGovIDType";
        private const string FetchAllBirthStatus = "SPC_FetchAllBirthStatus";

        public LoadMasterData()
        {

        }

        public List<LoadHospitals> RetrieveHospitalByDistrict(int districtId)
        {
            string stProc = FetchHospitalByDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@DistrictId", districtId) };
            var allData = UtilityDL.FillData<LoadHospitals>(stProc, pList);
            return allData;
        }
        public List<LoadCaste> RetrieveCaste()
        {
            string stProc = FetchAllCaste;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCaste>(stProc, pList);
            return allData;
        }

        public List<LoadCommunity> RetrieveCommunity()
        {
            string stProc = FetchAllCommunity;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadCommunity>(stProc, pList);
            return allData;
        }

        public List<LoadCommunity> RetrieveCommunity(int casteId)
        {
            string stProc = FetchCommunity;
            var pList = new List<SqlParameter>() { new SqlParameter("@CasteId", casteId ) };
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

        public List<LoadGovIdType> RetrieveGovIDType()
        {
            string stProc = FetchAllGovIdType;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadGovIdType>(stProc, pList);
            return allData;
        }

        public List<LoadHospitals> RetrieveHospital(int userId)
        {
            string stProc = FetchHospital;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserId", userId) };
            var allData = UtilityDL.FillData<LoadHospitals>(stProc, pList);
            return allData;
        }

        public List<LoadReligion> RetrieveReligion()
        {
            string stProc = FetchAllReligion;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadReligion>(stProc, pList);
            return allData;
        }

        public List<LoadBirthStatus> RetrieveBirthStatus()
        {
            string stProc = FetchAllBirthStatus;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<LoadBirthStatus>(stProc, pList);
            return allData;
        }
    }
}