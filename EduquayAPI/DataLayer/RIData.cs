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
        public string Add(RIRequest rdata)
        {
            try
            {
                string stProc = AddRI;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                   
                    new SqlParameter("@PHCID", rdata.PHCId),
                     new SqlParameter("@SCID", rdata.SCId),                    
                    new SqlParameter("@RI_gov_code", rdata.RI_gov_code),
                    new SqlParameter("@RIsite", rdata.RIsite  ?? rdata.RIsite),
                    new SqlParameter("@Pincode", rdata.Pincode  ?? rdata.Pincode),
                    new SqlParameter("@Isactive", rdata.IsActive ?? rdata.IsActive),
                    new SqlParameter("@Latitude", rdata.Latitude ?? rdata.Latitude),
                    new SqlParameter("@Longitude", rdata.Longitude ?? rdata.Longitude),
                    new SqlParameter("@Comments", rdata.Comments ?? rdata.Comments),
                    new SqlParameter("@Createdby", rdata.CreatedBy),
                    new SqlParameter("@Updatedby", rdata.UpdatedBy),
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

        public List<RI> Retreive(int code)
        {
            string stProc = FetchRI;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<RI>(stProc, pList);
            return allData;
        }

        public List<RI> Retreive()
        {
            string stProc = FetchAllRIs;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<RI>(stProc, pList);
            return allData;
        }
    }
}
