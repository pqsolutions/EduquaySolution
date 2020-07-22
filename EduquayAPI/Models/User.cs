using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{

    public class User : IFill
    {
        public int id { get; set; }
        public int userTypeId { get; set; }
        public string userType { get; set; }
        public int userRoleId { get; set; }
        public string userRole { get; set; }
        public string userGovCode { get; set; }
        public string userName { get; set; }
        public int stateId { get; set; }
        public int districtId { get; set; }
        public int blockId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int scId { get; set; }
        public string riId { get; set; }
        public string name { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public int registeredFrom { get; set; }
        public int sampleCollectionFrom { get; set; }
        public int shipmentFrom { get; set; }

        //public string DigitalSignature { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserType_ID"))
                this.userTypeId = Convert.ToInt32(reader["UserType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Usertype"))
                this.userType  = Convert.ToString(reader["Usertype"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserRole_ID"))
                this.userRoleId = Convert.ToInt32(reader["UserRole_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Userrolename"))
                this.userRole  = Convert.ToString(reader["Userrolename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "User_gov_code"))
                this.userGovCode = Convert.ToString(reader["User_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Username"))
                this.userName = Convert.ToString(reader["Username"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateID"))
                this.stateId = Convert.ToInt32(reader["StateID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockID"))
                this.blockId = Convert.ToInt32(reader["BlockID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCID"))
                this.chcId = Convert.ToInt32(reader["CHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCID"))
                this.phcId = Convert.ToInt32(reader["PHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.scId = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIID"))
                this.riId  = Convert.ToString(reader["RIID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Name"))
                this.name = Convert.ToString(reader["Name"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstName"))
                this.firstName = Convert.ToString(reader["FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MiddleName"))
                this.middleName = Convert.ToString(reader["MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastName"))
                this.lastName = Convert.ToString(reader["LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Email"))
                this.email = Convert.ToString(reader["Email"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegisteredFrom"))
                this.registeredFrom = Convert.ToInt32(reader["RegisteredFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionFrom"))
                this.sampleCollectionFrom = Convert.ToInt32(reader["SampleCollectionFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ShipmentFrom"))
                this.shipmentFrom = Convert.ToInt32(reader["ShipmentFrom"]);

        }
    }
   

}
