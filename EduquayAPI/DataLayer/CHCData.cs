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

        public string Add(CHCRequest cdata)
        {
            try
            {
                string stProc = AddCHC;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BlockID", cdata.BlockId),
                    new SqlParameter("@DistrictID", cdata.DistrictId),
                    new SqlParameter("@HNIN_ID", cdata.HNIN_ID),
                    new SqlParameter("@CHC_gov_code", cdata.CHC_gov_code),
                    new SqlParameter("@CHCname", cdata.CHCname  ?? cdata.CHCname),
                    new SqlParameter("@Istestingfacility", cdata.Istestingfacility ?? cdata.Istestingfacility),
                    new SqlParameter("@Isactive", cdata.IsActive ?? cdata.IsActive),
                    new SqlParameter("@Latitude", cdata.Latitude ?? cdata.Latitude),
                    new SqlParameter("@Longitude", cdata.Longitude ?? cdata.Longitude),
                    new SqlParameter("@Comments", cdata.Comments ?? cdata.Comments),
                    new SqlParameter("@Createdby", cdata.CreatedBy),
                    new SqlParameter("@Updatedby", cdata.UpdatedBy),
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

        public List<CHC> Retreive(int code)
        {
            string stProc = FetchCHC;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<CHC>(stProc, pList);
            return allData;
        }

        public List<CHC> Retreive()
        {
            string stProc = FetchAllCHCs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<CHC>(stProc, pList);
            return allData;
        }
    }
}
