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
    public class UserRoleData : IUserRoleData
    {
        private const string FetchUserRoles = "SPC_FetchAllUserRole";
        private const string FetchUserRole = "SPC_FetchUserRole";
        private const string AddUserRole = "SPC_AddUserRole";
        public UserRoleData()
        {

        }

        public string Add(UserRoleRequest urdata)
        {
            try
            {
                string stProc = AddUserRole;
                var retVal = new SqlParameter("@Scope_output", 1);
                retVal.Direction = ParameterDirection.Output;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@UserTypeID", urdata.UserTypeId),
                    new SqlParameter("@Userrolename", urdata.Userrolename ?? urdata.Userrolename),
                    new SqlParameter("@Isactive", urdata.IsActive ?? urdata.IsActive),
                    new SqlParameter("@Comments", urdata.Comments ?? urdata.Comments),
                    new SqlParameter("@Createdby", urdata.CreatedBy),
                    new SqlParameter("@Updatedby", urdata.UpdatedBy),

                    retVal
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return "User Role added successfully";
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<UserRole> Retreive(int code)
        {
            string stProc = FetchUserRole;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<UserRole>(stProc, pList);
            return allData; throw new NotImplementedException();
        }

        public List<UserRole> Retreive()
        {
            string stProc = FetchUserRoles;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<UserRole>(stProc, pList);
            return allData;
        }
    }
}
