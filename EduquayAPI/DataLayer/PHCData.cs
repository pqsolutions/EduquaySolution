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
        public string Add(PHCRequest pData)
        {
            try
            {
                string stProc = AddPHC;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {                    
                    new SqlParameter("@CHCID", pData.CHCId),
                    new SqlParameter("@HNIN_ID", pData.HNIN_ID ?? pData.HNIN_ID),
                    new SqlParameter("@PHC_gov_code", pData.PHC_gov_code),
                    new SqlParameter("@PHCname", pData.PHCname  ?? pData.PHCname),
                    new SqlParameter("@Pincode", pData.Pincode  ?? pData.Pincode),
                    new SqlParameter("@Isactive", pData.IsActive ?? pData.IsActive),
                    new SqlParameter("@Latitude", pData.Latitude ?? pData.Latitude),
                    new SqlParameter("@Longitude", pData.Longitude ?? pData.Longitude),
                    new SqlParameter("@Comments", pData.Comments ?? pData.Comments),
                    new SqlParameter("@Createdby", pData.CreatedBy),
                    new SqlParameter("@Updatedby", pData.UpdatedBy),
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

        public List<PHC> Retrieve(int code)
        {
            string stProc = FetchPHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<PHC>(stProc, pList);
            return allData;
        }

        public List<PHC> Retrieve()
        {
            string stProc = FetchAllPHCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<PHC>(stProc, pList);
            return allData;
        }
    }
}
