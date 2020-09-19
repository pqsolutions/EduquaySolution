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
        private const string FetchMobileLoginStatus = "SPC_FetchMobileLoginStatus";
        private const string FetchWebLoginStatus = "SPC_FetchWebLoginStatus";
        private const string ResetANMLogin = "SPC_ResetANMLogin";
        private const string LogoutUser = "SPC_Logout";
        private const string LoginUserDetail = "SPC_AddLoginDetails";

        public UsersData()
        {

        }

        public async Task<MobileLogin> Logout(int anmId)
        {
            try
            {
                var stProc = LogoutUser;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ANMId", anmId),
                };
                var allData = UtilityDL.FillEntity<MobileLogin>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MobileLogin> ResetLogin(string userName)
        {
            try
            {
                var stProc = ResetANMLogin;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UserName", userName),
                };
                var allData = UtilityDL.FillEntity<MobileLogin>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<WebLogin> CheckWebLogin(int userId, string userName)
        {
            try
            {
                var stProc = FetchWebLoginStatus;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ANMId", userId),
                    new SqlParameter("@UserName", userName),
                };
                var allData = UtilityDL.FillEntity<WebLogin>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MobileLogin> CheckMobileLogin(int userId, string userName, string deviceId)
        {
            try
            {
                var stProc = FetchMobileLoginStatus;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ANMId", userId),
                    new SqlParameter("@UserName", userName),
                    new SqlParameter("@DeviceId", deviceId),
                };
                var allData = UtilityDL.FillEntity<MobileLogin>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<List<UsersPassword>> CheckPasswordAsync(User user)
        {
            try
            {
                var stProc = FetchUserByUsername;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@Username", user.userName)
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
                    new SqlParameter("@UserType_ID", addUser.userTypeId),
                    new SqlParameter("@UserRole_ID", addUser.userRoleId),
                    new SqlParameter("@User_gov_code", addUser.userGovCode),
                    new SqlParameter("@Username", addUser.userName),
                    new SqlParameter("@Password", password),
                    new SqlParameter("@StateID", addUser.stateId),
                    new SqlParameter("@CentralLabId", addUser.centralLabId),
                    new SqlParameter("@MolecularLabId", addUser.molecularLabId),
                    new SqlParameter("@DistrictID", addUser.districtId),
                    new SqlParameter("@BlockID", addUser.blockId),
                    new SqlParameter("@CHCID", addUser.chcId),
                    new SqlParameter("@PHCID", addUser.phcId),
                    new SqlParameter("@SCID", addUser.scId),
                    new SqlParameter("@RIID", addUser.riId ?? string.Empty ),
                    new SqlParameter("@FirstName", addUser.firstName ?? addUser.firstName),
                    new SqlParameter("@MiddleName", addUser.middleName ?? string.Empty),
                    new SqlParameter("@LastName", addUser.lastName ?? string.Empty),
                    new SqlParameter("@ContactNo1", addUser.contactNo1 ?? string.Empty),
                    new SqlParameter("@ContactNo2", addUser.contactNo2 ?? string.Empty),
                    new SqlParameter("@Email", addUser.email ?? addUser.email),
                    new SqlParameter("@GovIDType_ID", addUser.govIdTypeId),
                    new SqlParameter("@GovIDDetails", addUser.govIdDetails ?? string.Empty),
                    new SqlParameter("@Address", addUser.address ?? string.Empty),
                    new SqlParameter("@Pincode", addUser.pincode ?? string.Empty),
                    new SqlParameter("@CreatedBy", addUser.createdBy),
                    new SqlParameter("@UpdatedBy", addUser.updatedBy),
                    new SqlParameter("@Comments", addUser.comments ?? string.Empty),
                    new SqlParameter("@IsActive", addUser.isActive ?? addUser.isActive),
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

        public void AddLoginDetails(int userId, string userName, string deviceId, string loginFrom)
        {
            try
            {
                var stProc = LoginUserDetail;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UserId", userId),
                    new SqlParameter("@UserName", userName ?? userName),
                    new SqlParameter("@DeviceId", deviceId.ToCheckNull()),
                    new SqlParameter("@LoginFrom", loginFrom ?? loginFrom),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
