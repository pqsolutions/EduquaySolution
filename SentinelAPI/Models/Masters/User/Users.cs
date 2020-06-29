using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Masters.User
{
    public class Users : IFill
    {
        public int id { get; set; }
        public int userRoleId { get; set; }
        public string userRoleName { get; set; }
        public string userName { get; set; }
        public int stateId { get; set; }
        public string stateName { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int hospitalId { get; set; }
        public string hospitalName { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string contactNo { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserRoleId"))
                this.userRoleId = Convert.ToInt32(reader["UserRoleId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserRoleName"))
                this.userRoleName = Convert.ToString(reader["UserRoleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserName"))
                this.userName = Convert.ToString(reader["UserName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Name"))
                this.name = Convert.ToString(reader["Name"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateId"))
                this.stateId = Convert.ToInt32(reader["StateId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateName"))
                this.stateName = Convert.ToString(reader["StateName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictName"))
                this.districtName = Convert.ToString(reader["DistrictName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalId"))
                this.hospitalId = Convert.ToInt32(reader["HospitalId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalName"))
                this.hospitalName = Convert.ToString(reader["HospitalName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Email"))
                this.email = Convert.ToString(reader["Email"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

        }
    }
}
