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
    public class UserTypeData : IUserTypeData
    {

        private const string FetchUserTypes = "SPC_FetchAllUserType";
        private const string FetchUserType = "SPC_FetchUserType";
        private const string AddUserType = "SPC_AddUserType";
        public UserTypeData()
        {

        }
        public string Add(UserTypeRequest utdata)
        {
            try
            {
                string stProc = AddUserType;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@UserType", utdata.UserTypename ?? utdata.UserTypename),
                    new SqlParameter("@Isactive", utdata.IsActive ?? utdata.IsActive),
                    new SqlParameter("@Comments", utdata.Comments ?? utdata.Comments),
                    new SqlParameter("@Createdby", utdata.CreatedBy),
                    new SqlParameter("@Updatedby", utdata.UpdatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "User Type added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserType> Retreive(int code)
        {
            string stProc = FetchUserType;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<UserType>(stProc, pList);
            return allData;
        }

        public List<UserType> Retreive()
        {
            string stProc = FetchUserTypes;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<UserType>(stProc, pList);
            return allData;
        }
    }
}
