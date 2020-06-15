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
    public class SubjectTypeData : ISubjectTypeData
    {
        private const string FetchSubjectTypes = "SPC_FetchAllSubjectType";
        private const string FetchSubjectType = "SPC_FetchSubjectType";
        private const string AddSubjectType = "SPC_AddSubjectType";
        public SubjectTypeData()
        {

        }
        public string Add(SubjectTypeRequest stData)
        {
            try
            {
                string stProc = AddSubjectType;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@SubjectType", stData.subectTypeName ?? stData.subectTypeName),
                    new SqlParameter("@Isactive", stData.isActive ?? stData.isActive),
                    new SqlParameter("@Comments", stData.comments ?? stData.comments),
                    new SqlParameter("@Createdby", stData.createdBy),
                    new SqlParameter("@Updatedby", stData.updatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "Subject Type added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SubjectType> Retrieve(int code)
        {
            string stProc = FetchSubjectType;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<SubjectType>(stProc, pList);
            return allData;
        }

        public List<SubjectType> Retrieve()
        {
            string stProc = FetchSubjectTypes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<SubjectType>(stProc, pList);
            return allData;
        }
    }
}
