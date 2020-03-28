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
    public class RIData : IRIData
    {

        private const string FetchAllRIs = "SPC_FetchAllRI";
        private const string FetchRI = "SPC_FetchRI";
        private const string AddRI = "SPC_AddRI";
        public RIData()
        {

        }
        public string Add(RIRequest rData)
        {
            try
            {
                string stProc = AddRI;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                   
                    new SqlParameter("@PHCID", rData.PHCId),
                     new SqlParameter("@SCID", rData.SCId),                    
                    new SqlParameter("@RI_gov_code", rData.RI_gov_code),
                    new SqlParameter("@RIsite", rData.RIsite  ?? rData.RIsite),
                    new SqlParameter("@Pincode", rData.Pincode  ?? rData.Pincode),
                    new SqlParameter("@Isactive", rData.IsActive ?? rData.IsActive),
                    new SqlParameter("@Latitude", rData.Latitude ?? rData.Latitude),
                    new SqlParameter("@Longitude", rData.Longitude ?? rData.Longitude),
                    new SqlParameter("@Comments", rData.Comments ?? rData.Comments),
                    new SqlParameter("@Createdby", rData.CreatedBy),
                    new SqlParameter("@Updatedby", rData.UpdatedBy),
                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "RI added successfully";
            }
            catch (Exception e)
            {
                throw e;

            }
        }

        public List<RI> Retrieve(int code)
        {
            string stProc = FetchRI;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<RI>(stProc, pList);
            return allData;
        }

        public List<RI> Retrieve()
        {
            string stProc = FetchAllRIs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<RI>(stProc, pList);
            return allData;
        }
    }
}
