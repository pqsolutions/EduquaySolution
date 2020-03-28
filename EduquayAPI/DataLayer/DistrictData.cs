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
    public class DistrictData : IDistrictData
    {
        private const string FetchDistricts = "SPC_FetchAllDistricts";
        private const string FetchDistrict = "SPC_FetchDistrict";
        private const string AddDistrict = "SPC_AddDistrict";
        public DistrictData()
        {

        }

        public string Add(DistrictRequest dData)
        {
            try
            {
                string stProc = AddDistrict;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@District_gov_code", dData.District_gov_code),
                    new SqlParameter("@StateID", dData.StateId),
                    new SqlParameter("@Districtname", dData.Districtname  ?? dData.Districtname),
                    new SqlParameter("@Isactive", dData.IsActive ?? dData.IsActive),
                    new SqlParameter("@Latitude", dData.Latitude ?? dData.Latitude),
                    new SqlParameter("@Longitude", dData.Longitude ?? dData.Longitude),
                    new SqlParameter("@Comments", dData.Comments ?? dData.Comments),
                    new SqlParameter("@Createdby", dData.CreatedBy),
                    new SqlParameter("@Updatedby", dData.UpdatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "District added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<District> Retrieve(int code)
        {
            string stProc = FetchDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<District>(stProc, pList);
            return allData;
        }

        public List<District> Retrieve()
        {
            string stProc = FetchDistricts;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<District>(stProc, pList);
            return allData;
        }
    }
}
