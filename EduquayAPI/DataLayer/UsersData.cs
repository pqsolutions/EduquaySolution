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
    public class UsersData : IUsersData
    {
        private const string FetchAllUser = "SPC_FetchAllUser";
        private const string FetchUser = "SPC_FetchUser";
        private const string AddUser = "SPC_AddUser";
        private const string FetchUserByEmail = "SPC_FetchUserByEmail";
        private const string FetchUserByUsername = "SPC_FetchUserByUsername";
        private const string FetchUserByUserRole = "SPC_FetchUserByRole";
        private const string FetchUserByUserType = "SPC_FetchUserByType";
        private const string CheckUserPassword = "SPC_CheckUserPassword";

        public UsersData()
        {

        }

        public async Task<List<UsersPassword>> CheckPasswordAsync(User user)
        {
            try
            {
                var stProc = FetchUserByUsername;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@Username", user.Username)
                };
                var userPassword = UtilityDL.FillData<UsersPassword>(stProc, pList);
                return userPassword;

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<int> AddNewUserAsync(AddUserRequest addUser,string password)
        {
            var recInsert = 0;
            try
            {
                var stProc = AddUser;
                var retVal = new SqlParameter("@SCOPE_OUTPUT", 1) { Direction = ParameterDirection.Output };
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UserType_ID", addUser.UserType_ID),
                    new SqlParameter("@UserRole_ID", addUser.UserRole_ID),
                    new SqlParameter("@User_gov_code", addUser.User_gov_code),
                    new SqlParameter("@Username", addUser.Username),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@StateID", addUser.StateID),
                    new SqlParameter("@DistrictID", addUser.DistrictID),
                    new SqlParameter("@BlockID", addUser.BlockID),
                    new SqlParameter("@CHCID", addUser.CHCID),
                    new SqlParameter("@PHCID", addUser.PHCID),
                    new SqlParameter("@SCID", addUser.SCID),
                    new SqlParameter("@RIID", addUser.RIID ?? string.Empty ),
                    new SqlParameter("@FirstName", addUser.FirstName ?? addUser.FirstName),
                    new SqlParameter("@MiddleName", addUser.MiddleName ?? string.Empty),
                    new SqlParameter("@LastName", addUser.LastName ?? string.Empty),
                    new SqlParameter("@ContactNo1", addUser.ContactNo1 ?? string.Empty),
                    new SqlParameter("@ContactNo2", addUser.ContactNo2 ?? string.Empty),
                    new SqlParameter("@Email", addUser.Email ?? addUser.Email),
                    new SqlParameter("@GovIDType_ID", addUser.GovIDType_ID),
                    new SqlParameter("@GovIDDetails", addUser.GovIDDetails ?? string.Empty),
                    new SqlParameter("@Address", addUser.Address ?? string.Empty),
                    new SqlParameter("@Pincode", addUser.Pincode ?? string.Empty),
                    new SqlParameter("@CreatedBy", addUser.CreatedBy),
                    new SqlParameter("@UpdatedBy", addUser.UpdatedBy),
                    new SqlParameter("@Comments", addUser.Comments ?? string.Empty),
                    new SqlParameter("@IsActive", addUser.IsActive ?? addUser.IsActive),
                  //  new SqlParameter("@DigitalSignature", addUser.DigitalSignature ?? string.Empty),
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

        public async Task<List<User>> FindByEmailAsync(string email)
        {
            var stProc = FetchUserByEmail;
            var pList = new List<SqlParameter>() { new SqlParameter("@Email", email) };
            var userDetail = UtilityDL.FillData<User>(stProc, pList);
            return userDetail;
        }

        public async Task<List<User>> FindByUsernameAsync(string userName)
        {
            var stProc = FetchUserByUsername;
            var pList = new List<SqlParameter>() { new SqlParameter("@Username", userName) };
            var userDetail = UtilityDL.FillData<User>(stProc, pList);
            return userDetail;
        }

        public List<User> RetrieveByUserRole(int userRoleId)
        {
            string stProc = FetchUserByUserRole;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserRoleId", userRoleId) };
            var allData = UtilityDL.FillData<User>(stProc, pList);
            return allData;
        }

        public List<User> RetrieveByUserType(int userTypeId)
        {
            string stProc = FetchUserByUserType;
            var pList = new List<SqlParameter>() { new SqlParameter("@UserTypeId", userTypeId) };
            var allData = UtilityDL.FillData<User>(stProc, pList);
            return allData;
        }

        public List<User> RetrieveByEmail(string email)
        {
            string stProc = FetchUserByEmail;
            var pList = new List<SqlParameter>() { new SqlParameter("@Email", email) };
            var allData = UtilityDL.FillData<User>(stProc, pList);
            return allData;
        }

        public List<User> RetrieveByUsername(string username)
        {
            string stProc = FetchUserByUsername;
            var pList = new List<SqlParameter>() { new SqlParameter("@Username", username) };
            var allData = UtilityDL.FillData<User>(stProc, pList);
            return allData;
        }

        public List<User> Retrieve(int code)
        {
            string stProc = FetchUser;
            var pList = new List<SqlParameter>() { new SqlParameter("@ID", code) };
            var allData = UtilityDL.FillData<User>(stProc, pList);
            return allData;
        }

        public List<User> Retrieve()
        {
            string stProc = FetchAllUser;
            var pList = new List<SqlParameter>();
            var allData = UtilityDL.FillData<User>(stProc, pList);
            return allData;
        }
    }
}
