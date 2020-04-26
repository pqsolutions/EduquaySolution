using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Models;
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
        public string Add(SCRequest sData)
        {
            try
            {
                string stProc = AddSC;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@CHCID", sData.CHCId),
                    new SqlParameter("@PHCID", sData.PHCId),
                    new SqlParameter("@HNIN_ID", sData.HNIN_ID ?? sData.HNIN_ID),
                    new SqlParameter("@SC_gov_code", sData.SC_gov_code),
                    new SqlParameter("@SCname", sData.SCname  ?? sData.SCname),
                    new SqlParameter("@Pincode", sData.Pincode  ?? sData.Pincode),
                    new SqlParameter("@Isactive", sData.IsActive ?? sData.IsActive),
                    new SqlParameter("@Latitude", sData.Latitude ?? sData.Latitude),
                    new SqlParameter("@Longitude", sData.Longitude ?? sData.Longitude),
                    new SqlParameter("@Comments", sData.Comments ?? sData.Comments),
                    new SqlParameter("@Createdby", sData.CreatedBy),
                    new SqlParameter("@Updatedby", sData.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "SC added successfully";
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
