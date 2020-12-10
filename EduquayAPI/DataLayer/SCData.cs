using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
using EduquayAPI.Models.Masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer
{
    public class SCData : ISCData
    {

        private const string FetchAllSCs = "SPC_FetchAllSC";
        private const string FetchSC = "SPC_FetchSC";
        private const string AddSC = "SPC_AddSC";
        public SCData()
        {

        }
        public AddEditMasters Add(SCRequest sData)
        {
            try
            {
                string stProc = AddSC;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@CHCID", sData.chcId),
                    new SqlParameter("@PHCID", sData.phcId),
                    new SqlParameter("@HNIN_ID", sData.hninId ?? sData.hninId),
                    new SqlParameter("@SC_gov_code", sData.scGovCode),
                    new SqlParameter("@SCname", sData.scName  ?? sData.scName),
                    new SqlParameter("@SCAddress", sData.scAddress.ToCharArray()),
                    new SqlParameter("@Pincode", sData.pincode  ?? sData.pincode),
                    new SqlParameter("@Isactive", sData.isActive ?? sData.isActive),
                    new SqlParameter("@Latitude", sData.latitude ?? sData.latitude),
                    new SqlParameter("@Longitude", sData.longitude ?? sData.longitude),
                    new SqlParameter("@Comments", sData.comments ?? sData.comments),
                    new SqlParameter("@Createdby", sData.createdBy),
                    new SqlParameter("@Updatedby", sData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public List<SC> Retrieve(int code)
        {
            string stProc = FetchSC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<SC>(stProc, pList);
            return allData;
        }

        public List<SC> Retrieve()
        {
            string stProc = FetchAllSCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<SC>(stProc, pList);
            return allData;
        }
    }
}
