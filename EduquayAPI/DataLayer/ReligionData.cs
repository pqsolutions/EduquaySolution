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
    public class ReligionData : IReligionData
    {


        private const string FetchReligions = "SPC_FetchAllReligion";
        private const string FetchReligion = "SPC_FetchReligion";
        private const string AddReligion = "SPC_AddReligion";
        public ReligionData()
        {

        }

        public string Add(ReligionRequest rData)
        {
            try
            {
                string stProc = AddReligion;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@Religionname", rData.religionName  ?? rData.religionName),
                    new SqlParameter("@Isactive", rData.isActive ?? rData.isActive),
                    new SqlParameter("@Comments", rData.comments ?? rData.comments),
                    new SqlParameter("@Createdby", rData.createdBy),
                    new SqlParameter("@Updatedby", rData.updatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Religion added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<Religion> Retrieve(int code)
        {
            string stProc = FetchReligion;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<Religion>(stProc, pList);
            return allData;
        }

        public List<Religion> Retrieve()
        {
            string stProc = FetchReligions;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<Religion>(stProc, pList);
            return allData;
        }
    }
}
