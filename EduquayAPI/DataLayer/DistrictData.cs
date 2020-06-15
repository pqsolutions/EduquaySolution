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
                    new SqlParameter("@District_gov_code", dData.districtGovCode),
                    new SqlParameter("@StateID", dData.stateId),
                    new SqlParameter("@Districtname", dData.districtName  ?? dData.districtName),
                    new SqlParameter("@Isactive", dData.isActive ?? dData.isActive),
                    new SqlParameter("@Comments", dData.comments ?? dData.comments),
                    new SqlParameter("@Createdby", dData.createdBy),
                    new SqlParameter("@Updatedby", dData.updatedBy),

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
