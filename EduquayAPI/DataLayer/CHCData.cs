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
    public class CHCData : ICHCData
    {
        private const string FetchAllCHCs = "SPC_FetchAllCHC";
        private const string FetchCHC = "SPC_FetchCHC";
        private const string AddCHC = "SPC_AddCHC";
        public CHCData()
        {

        }

        public string Add(CHCRequest cData)
        {
            try
            {
                string stProc = AddCHC;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BlockID", cData.BlockId),
                    new SqlParameter("@DistrictID", cData.DistrictId),
                    new SqlParameter("@HNIN_ID", cData.HNIN_ID),
                    new SqlParameter("@CHC_gov_code", cData.CHC_gov_code),
                    new SqlParameter("@CHCname", cData.CHCname  ?? cData.CHCname),
                    new SqlParameter("@Istestingfacility", cData.Istestingfacility ?? cData.Istestingfacility),
                    new SqlParameter("@Isactive", cData.IsActive ?? cData.IsActive),
                    new SqlParameter("@Latitude", cData.Latitude ?? cData.Latitude),
                    new SqlParameter("@Longitude", cData.Longitude ?? cData.Longitude),
                    new SqlParameter("@Comments", cData.Comments ?? cData.Comments),
                    new SqlParameter("@Createdby", cData.CreatedBy),
                    new SqlParameter("@Updatedby", cData.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "CHC added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<CHC> Retrieve(int code)
        {
            string stProc = FetchCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<CHC>(stProc, pList);
            return allData;
        }

        public List<CHC> Retrieve()
        {
            string stProc = FetchAllCHCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<CHC>(stProc, pList);
            return allData;
        }
    }
}
