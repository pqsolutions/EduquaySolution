using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class SubjectPrimary:IFill
    {
        public int subjectTypeId { get; set; }
        public int childSubjectTypeId { get; set; }
        public string uniqueSubjectId { get; set; }
        public int districtId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int scId { get; set; }
        public int riId { get; set; }
        public string subjectTitle { get; set; }
        public string firstName { get; set; }
        public string middleName { get; set; }
        public string lastName { get; set; }
        public string dob { get; set; }
        public int age { get; set; }
        public string gender { get; set; }
        public Boolean? maritalStatus { get; set; }
        public string mobileNo { get; set; }
        public string emailId { get; set; }
        public int govIdTypeId { get; set; }
        public string govIdDetail { get; set; }
        public string spouseSubjectId { get; set; }
        public string spouseFirstName { get; set; }
        public string spouseMiddleName { get; set; }
        public string spouseLastName { get; set; }
        public string spouseContactNo { get; set; }
        public int spouseGovIdTypeId { get; set; }
        public string spouseGovIdDetail { get; set; }
        public int assignANMId { get; set; }
        public string dateOfRegister { get; set; }
        public int registeredFrom { get; set; }
        public Boolean isActive { get; set; }
        public int createdBy { get; set; }
        public int updatedBy { get; set; }
        public string source { get; set; }
        public bool spouseWillingness { get; set; }
        public void Fill(SqlDataReader reader)
        {
           

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTypeID"))
                this.subjectTypeId = Convert.ToInt32(reader["SubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ChildSubjectTypeID"))
                this.childSubjectTypeId = Convert.ToInt32(reader["ChildSubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictID"))
                this.districtId = Convert.ToInt32(reader["DistrictID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCID"))
                this.chcId = Convert.ToInt32(reader["CHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCID"))
                this.phcId = Convert.ToInt32(reader["PHCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCID"))
                this.scId = Convert.ToInt32(reader["SCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RIID"))
                this.riId = Convert.ToInt32(reader["RIID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTitle"))
                this.subjectTitle = Convert.ToString(reader["SubjectTitle"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstName"))
                this.firstName = Convert.ToString(reader["FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MiddleName"))
                this.middleName = Convert.ToString(reader["MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LastName"))
                this.lastName = Convert.ToString(reader["LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfBirth"))
                this.dob = Convert.ToString(reader["DateOfBirth"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToInt32(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MobileNo"))
                this.mobileNo = Convert.ToString(reader["MobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MaritalStatus"))
                this.maritalStatus = Convert.ToBoolean(reader["MaritalStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "EmailId"))
                this.emailId = Convert.ToString(reader["EmailId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegisterDate"))
                this.dateOfRegister = Convert.ToString(reader["RegisterDate"]);

              if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIdType_ID"))
                this.govIdTypeId = Convert.ToInt32(reader["GovIdType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GovIdDetail"))
                this.govIdDetail = Convert.ToString(reader["GovIdDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_FirstName"))
                this.spouseFirstName = Convert.ToString(reader["Spouse_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_MiddleName"))
                this.spouseMiddleName = Convert.ToString(reader["Spouse_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_LastName"))
                this.spouseLastName = Convert.ToString(reader["Spouse_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectID"))
                this.spouseSubjectId = Convert.ToString(reader["SpouseSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_ContactNo"))
                this.spouseContactNo = Convert.ToString(reader["Spouse_ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_GovIdType_ID"))
                this.spouseGovIdTypeId = Convert.ToInt32(reader["Spouse_GovIdType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_GovIdDetail"))
                this.spouseGovIdDetail = Convert.ToString(reader["Spouse_GovIdDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AssignANM_ID"))
                this.assignANMId = Convert.ToInt32(reader["AssignANM_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegisteredFrom"))
                this.registeredFrom = Convert.ToInt32(reader["RegisteredFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.createdBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.updatedBy = Convert.ToInt32(reader["UpdatedBy"]);
           
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsActive"))
                this.isActive = Convert.ToBoolean(reader["IsActive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegSource"))
                this.source = Convert.ToString(reader["RegSource"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseWillingness"))
                this.spouseWillingness = Convert.ToBoolean(reader["SpouseWillingness"]);

        }
    }
}
