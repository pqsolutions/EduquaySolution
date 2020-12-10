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
    public class PHCData : IPHCData
    {
        private const string FetchAllPHCs = "SPC_FetchAllPHC";
        private const string FetchPHC = "SPC_FetchPHC";
        private const string AddPHC = "SPC_AddPHC";
        public PHCData()
        {

        }
        public AddEditMasters Add(PHCRequest pData)
        {
            try
            {
                string stProc = AddPHC;
                var pList = new List<SqlParameter>
                {                    
                    new SqlParameter("@CHCID", pData.chcId),
                    new SqlParameter("@HNIN_ID", pData.hninId ?? pData.hninId),
                    new SqlParameter("@PHC_gov_code", pData.phcGovCode),
                    new SqlParameter("@PHCname", pData.phcName  ?? pData.phcName),
                    new SqlParameter("@Pincode", pData.pincode  ?? pData.pincode),
                    new SqlParameter("@Isactive", pData.isActive ?? pData.isActive),
                    new SqlParameter("@Latitude", pData.latitude ?? pData.latitude),
                    new SqlParameter("@Longitude", pData.longitude ?? pData.longitude),
                    new SqlParameter("@Comments", pData.comments ?? pData.comments),
                    new SqlParameter("@Createdby", pData.createdBy),
                    new SqlParameter("@Updatedby", pData.updatedBy),
                };
                var returnData = UtilityDL.FillEntity<AddEditMasters>(stProc, pList);
                return returnData;
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
