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
        public string Add(SCRequest sdata)
        {
            try
            {
                string stProc = AddSC;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@CHCID", sdata.CHCId),
                    new SqlParameter("@PHCID", sdata.PHCId),
                    new SqlParameter("@HNIN_ID", sdata.HNIN_ID),
                    new SqlParameter("@SC_gov_code", sdata.SC_gov_code),
                    new SqlParameter("@SCname", sdata.SCname  ?? sdata.SCname),
                    new SqlParameter("@Pincode", sdata.Pincode  ?? sdata.Pincode),
                    new SqlParameter("@Isactive", sdata.IsActive ?? sdata.IsActive),
                    new SqlParameter("@Latitude", sdata.Latitude ?? sdata.Latitude),
                    new SqlParameter("@Longitude", sdata.Longitude ?? sdata.Longitude),
                    new SqlParameter("@Comments", sdata.Comments ?? sdata.Comments),
                    new SqlParameter("@Createdby", sdata.CreatedBy),
                    new SqlParameter("@Updatedby", sdata.UpdatedBy),
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

        public List<SC> Retreive(int code)
        {
            string stProc = FetchSC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<SC>(stProc, pList);
            return allData;
        }

        public List<SC> Retreive()
        {
            string stProc = FetchAllSCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<SC>(stProc, pList);
            return allData;
        }
    }
}
