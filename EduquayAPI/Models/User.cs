using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class User : IFill
    {
        public int ID { get; set; }
        public int UserType_ID { get; set; }
        public string Usertype { get; set; }
        public int UserRole_ID { get; set; }
        public string Userrolename { get; set; }
        public string User_gov_code { get; set; }
        public string Username { get; set; }
        //  public string Password { get; set; }
        public int StateID { get; set; }
        public string Statename { get; set; }
        public int DistrictID { get; set; }
        public string Districtname { get; set; }
        public int BlockID { get; set; }
        public string Blockname { get; set; }
        public int CHCID { get; set; }
        public string CHCname { get; set; }
        public int PHCID { get; set; }
        public string PHCname { get; set; }
        public int SCID { get; set; }
        public string SCname { get; set; }
        public int RIID { get; set; }
        public string RISite { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string ContactNo1 { get; set; }
        public string ContactNo2 { get; set; }
        public string Email { get; set; }
        public int? GovIDType_ID { get; set; }
        public string GovIDType { get; set; }
        public string GovIDDetails { get; set; }
        public string Address { get; set; }
        public string Pincode { get; set; }
        public string Comments { get; set; }
        public string IsActive { get; set; }
        public string DigitalSignature { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserType_ID"))
                this.UserType_ID = Convert.ToInt32(reader["UserType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Usertype"))
                this.Usertype = Convert.ToString(reader["Usertype"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UserRole_ID"))
                this.UserRole_ID = Convert.ToInt32(reader["UserRole_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Userrolename"))
                this.Userrolename = Convert.ToString(reader["Userrolename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "User_gov_code"))
                this.User_gov_code = Convert.ToString(reader["User_gov_code"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Username"))
                this.Username = Convert.ToString(reader["Username"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateID"))
                this.StateID = Convert.ToInt32(reader["StateID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Statename"))
                this.Statename = Convert.ToString(reader["Statename"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.DistrictID = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.Districtname = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BlockID"))
                this.BlockID = Convert.ToInt32(reader["BlockID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Blockname"))
                this.Blockname = Convert.ToString(reader["Blockname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCID"))
                this.CHCID = Convert.ToInt32(reader["CHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.CHCname = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCID"))
                this.PHCID = Convert.ToInt32(reader["PHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.PHCname = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.SCID = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCname"))
                this.SCname = Convert.ToString(reader["SCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIID"))
                this.RIID = Convert.ToInt32(reader["RIID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.RISite = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstName"))
                this.FirstName = Convert.ToString(reader["FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MiddleName"))
                this.MiddleName = Convert.ToString(reader["MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastName"))
                this.LastName = Convert.ToString(reader["LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo1"))
                this.ContactNo1 = Convert.ToString(reader["ContactNo1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo2"))
                this.ContactNo2 = Convert.ToString(reader["ContactNo2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Email"))
                this.Email = Convert.ToString(reader["Email"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIDType_ID"))
                this.GovIDType_ID = Convert.ToInt32(reader["GovIDType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIDType"))
                this.GovIDType = Convert.ToString(reader["GovIDType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIDType"))
                this.GovIDType = Convert.ToString(reader["GovIDType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIDDetails"))
                this.GovIDDetails = Convert.ToString(reader["GovIDDetails"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.Address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.Pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.Comments = Convert.ToString(reader["Comments"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Isactive"))
                this.IsActive = Convert.ToString(reader["Isactive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DigitalSignature"))
                this.DigitalSignature = Convert.ToString(reader["DigitalSignature"]);

        }
    }

}
