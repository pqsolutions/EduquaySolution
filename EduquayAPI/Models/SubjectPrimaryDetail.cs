using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EduquayAPI.Models
{
    public class SubjectPrimaryDetail:IFill
    {
        public int ID { get; set; }
        public int SubjectTypeID { get; set; }
        public string SubjectType { get; set; }
        public string UniqueSubjectID { get; set; }
        public int DistrictID { get; set; }
        public string Districtname { get; set; }
        public int CHCID { get; set; }
        public string CHCname { get; set; }
        public int PHCID { get; set; }
        public string PHCname { get; set; }
        public int SCID { get; set; }
        public string SCname { get; set; }
        public int RIID { get; set; }
        public string RIsite { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string MaritalStatus { get; set; }
        public string MobileNo { get; set; }
        public string SpouseSubjectID { get; set; }
        public string Spouse_FirstName { get; set; }
        public string Spouse_MiddleName { get; set; }
        public string Spouse_LastName { get; set; }
        public string Spouse_ContactNo { get; set; }
        public int GovIdType_ID { get; set; }
        public string GovIdType { get; set; }
        public string GovIdDetail { get; set; }
        public int AssignANM_ID { get; set; }
        public string ANMName { get; set; }
        public string IsActive { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.ID = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTypeID"))
                this.SubjectTypeID = Convert.ToInt32(reader["SubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.SubjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.DistrictID = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.Districtname = Convert.ToString(reader["Districtname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCID"))
                this.CHCID  = Convert.ToInt32(reader["CHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.CHCname  = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCID"))
                this.PHCID  = Convert.ToInt32(reader["PHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCname"))
                this.PHCname = Convert.ToString(reader["PHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.SCID  = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCname"))
                this.SCname  = Convert.ToString(reader["SCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIID"))
                this.RIID  = Convert.ToInt32(reader["RIID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIsite"))
                this.RIsite  = Convert.ToString(reader["RIsite"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstName"))
                this.FirstName  = Convert.ToString(reader["FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MiddleName"))
                this.MiddleName  = Convert.ToString(reader["MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastName"))
                this.LastName   = Convert.ToString(reader["LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DOB"))
                this.DOB  = Convert.ToString(reader["DOB"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.Age  = Convert.ToInt32 (reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.Gender  = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MobileNo"))
                this.MobileNo  = Convert.ToString(reader["MobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MaritalStatus"))
                this.MaritalStatus   = Convert.ToString(reader["MaritalStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_FirstName"))
                this.Spouse_FirstName = Convert.ToString(reader["Spouse_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_MiddleName"))
                this.Spouse_MiddleName = Convert.ToString(reader["Spouse_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_LastName"))
                this.Spouse_LastName = Convert.ToString(reader["Spouse_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectID"))
                this.SpouseSubjectID = Convert.ToString(reader["SpouseSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_ContactNo"))
                this.Spouse_ContactNo = Convert.ToString(reader["Spouse_ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIdType_ID"))
                this.GovIdType_ID = Convert.ToInt32(reader["GovIdType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIdType"))
                this.GovIdType = Convert.ToString(reader["GovIdType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIdDetail"))
                this.GovIdDetail = Convert.ToString(reader["GovIdDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AssignANM_ID"))
                this.AssignANM_ID  = Convert.ToInt32(reader["AssignANM_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.ANMName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.IsActive  = Convert.ToString(reader["IsActive"]);

        }
    }
}
