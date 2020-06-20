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
        public string userRoleName { get; set; }
        public string userGovCode { get; set; }
        public string userName { get; set; }
        //  public string Password { get; set; }
        public int stateId { get; set; }
        public string stateShortName { get; set; }
        public string stateName { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int blockId { get; set; }
        public string blockName { get; set; }
        public int chcId { get; set; }
        public string chcName { get; set; }
        public int phcId { get; set; }
        public string phcName { get; set; }
        public int scId { get; set; }
        public string scName { get; set; }
        public string RiId { get; set; }
       // public string RISite { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string contactNo1 { get; set; }
        public string contactNo2 { get; set; }
        public string email { get; set; }
        public int govIdTypeId { get; set; }
        public string govIdType { get; set; }
        public string govIdDetails { get; set; }
        public string address { get; set; }
        public string pincode { get; set; }
        public string comments { get; set; }
        public string isActive { get; set; }
       // public string DigitalSignature { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserType_ID"))
                this.userTypeId = Convert.ToInt32(reader["UserType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Usertype"))
                this.userType = Convert.ToString(reader["Usertype"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserRole_ID"))
                this.userRoleId = Convert.ToInt32(reader["UserRole_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Userrolename"))
                this.userRoleName = Convert.ToString(reader["Userrolename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "User_gov_code"))
                this.userGovCode = Convert.ToString(reader["User_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Username"))
                this.userName = Convert.ToString(reader["Username"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateID"))
                this.stateId = Convert.ToInt32(reader["StateID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.stateName = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Shortname"))
                this.stateShortName = Convert.ToString(reader["Shortname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.districtName = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockID"))
                this.blockId = Convert.ToInt32(reader["BlockID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.blockName = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCID"))
                this.chcId = Convert.ToInt32(reader["CHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.chcName = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCID"))
                this.phcId = Convert.ToInt32(reader["PHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.phcName = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.scId = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCname"))
                this.scName = Convert.ToString(reader["SCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIID"))
                this.RiId = Convert.ToString(reader["RIID"]);

            //if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
            //    this.RISite = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstName"))
                this.firstName = Convert.ToString(reader["FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MiddleName"))
                this.middleName = Convert.ToString(reader["MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastName"))
                this.lastName = Convert.ToString(reader["LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo1"))
                this.contactNo1 = Convert.ToString(reader["ContactNo1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo2"))
                this.contactNo2 = Convert.ToString(reader["ContactNo2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Email"))
                this.email = Convert.ToString(reader["Email"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIDType_ID"))
                this.govIdTypeId = Convert.ToInt32(reader["GovIDType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIDType"))
                this.govIdType = Convert.ToString(reader["GovIDType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIDDetails"))
                this.govIdDetails = Convert.ToString(reader["GovIDDetails"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Isactive"))
                this.isActive = Convert.ToString(reader["Isactive"]);

            //if (CommonUtility.IsColumnExistsAndNotNull(reader, "DigitalSignature"))
            //    this.DigitalSignature = Convert.ToString(reader["DigitalSignature"]);

        }
    }

}
