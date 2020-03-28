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

        public string Add(DistrictRequest ddata)
        {
            try
            {
                string stProc = AddDistrict;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@District_gov_code", ddata.District_gov_code),
                    new SqlParameter("@StateID", ddata.StateId),
                    new SqlParameter("@Districtname", ddata.Districtname  ?? ddata.Districtname),
                    new SqlParameter("@Isactive", ddata.IsActive ?? ddata.IsActive),
                    new SqlParameter("@Latitude", ddata.Latitude ?? ddata.Latitude),
                    new SqlParameter("@Longitude", ddata.Longitude ?? ddata.Longitude),
                    new SqlParameter("@Comments", ddata.Comments ?? ddata.Comments),
                    new SqlParameter("@Createdby", ddata.CreatedBy),
                    new SqlParameter("@Updatedby", ddata.UpdatedBy),

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

        public List<District> Retreive(int code)
        {
            string stProc = FetchDistrict;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<District>(stProc, pList);
            return allData;
        }

        public List<District> Retreive()
        {
            string stProc = FetchDistricts;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<District>(stProc, pList);
            return allData;
        }
    }
}
