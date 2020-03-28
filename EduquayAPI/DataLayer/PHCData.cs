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
    public class PHCData : IPHCData
    {
        private const string FetchAllPHCs = "SPC_FetchAllPHC";
        private const string FetchPHC = "SPC_FetchPHC";
        private const string AddPHC = "SPC_AddPHC";
        public PHCData()
        {

        }
        public string Add(PHCRequest pdata)
        {
            try
            {
                string stProc = AddPHC;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {                    
                    new SqlParameter("@CHCID", pdata.CHCId),
                    new SqlParameter("@HNIN_ID", pdata.HNIN_ID),
                    new SqlParameter("@PHC_gov_code", pdata.PHC_gov_code),
                    new SqlParameter("@PHCname", pdata.PHCname  ?? pdata.PHCname),                   
                    new SqlParameter("@Isactive", pdata.IsActive ?? pdata.IsActive),
                    new SqlParameter("@Latitude", pdata.Latitude ?? pdata.Latitude),
                    new SqlParameter("@Longitude", pdata.Longitude ?? pdata.Longitude),
                    new SqlParameter("@Comments", pdata.Comments ?? pdata.Comments),
                    new SqlParameter("@Createdby", pdata.CreatedBy),
                    new SqlParameter("@Updatedby", pdata.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "PHC added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<PHC> Retreive(int code)
        {
            string stProc = FetchPHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<PHC>(stProc, pList);
            return allData;
        }

        public List<PHC> Retreive()
        {
            string stProc = FetchAllPHCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<PHC>(stProc, pList);
            return allData;
        }
    }
}
