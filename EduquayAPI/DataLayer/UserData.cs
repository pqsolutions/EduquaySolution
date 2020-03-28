using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models;

namespace EduquayAPI.DataLayer
{
    public class UserData: IUserData
    {
        private const string CreateUser = "SPC_CreateUser";
        private const string FindUserByEmail = "SPC_FindUserByEmail";
        private const string CheckUserPassword = "SPC_CheckUserPassword";
        public async Task<List<UserModel>> FindByEmailAsync(string email)
        {
            var stProc = FindUserByEmail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@USEREMAIL", email)
            };
            var user = UtilityDL.FillData<UserModel>(stProc, pList);
            return user;
        }

        public async Task<int> CreateUserAsync(UserModel userModel, string password)
        {
            var recInsert = 0;
            try
            {
                var stProc = CreateUser;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 10) {Direction = ParameterDirection.Output};
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@USEREMAIL", userModel.Email),
                    new SqlParameter("@PASSWORD", password),
                    new SqlParameter("@FIRSTNAME", userModel.FirstName ?? string.Empty),
                    new SqlParameter("@LASTNAME", userModel.LastName ?? string.Empty),
                    retVal
                };
                recInsert = Convert.ToInt32(UtilityDL.ExecuteNonQuery(stProc, pList, true));
                return recInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<UserPassword>> CheckPasswordAsync(UserModel userModel)
        {
            try
            {
                var stProc = FindUserByEmail;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@USEREMAIL", userModel.Email)
                };
                var userPassword = UtilityDL.FillData<UserPassword>(stProc, pList);
                return userPassword;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
