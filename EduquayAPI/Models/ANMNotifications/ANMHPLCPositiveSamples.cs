using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMNotifications
{
    public class ANMHPLCPositiveSamples : IFill
    {
        public int id { get; set; }
        public int subjectTypeId { get; set; }
        public int childSubjectTypeId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public int districtId { get; set; }
        public int chcId { get; set; }
        public int phcId { get; set; }
        public int scId { get; set; }
        public int riId { get; set; }
        public string contactNo { get; set; }
        public string gestationalAge { get; set; }
        public string spouseFirstName { get; set; }
        public string spouseMiddleName { get; set; }
        public string spouseLastName { get; set; }
        public string spouseContactNo { get; set; }
        public int spouseGovIdTypeId { get; set; }
        public string spouseGovIdDetail { get; set; }
        public int religionId { get; set; }
        public int casteId { get; set; }
        public int communityId { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public string pincode { get; set; }
        public string stateName { get; set; }
        public string rchId { get; set; }
        public string ecNumber { get; set; }
        public bool notifiedStatus { get; set; }
        public int registerSpouse { get; set; }
        public string barcodeNo { get; set; }
        public string hplcResult { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NotifiedStatus"))
                this.notifiedStatus = Convert.ToBoolean(reader["NotifiedStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegisterSpouse"))
                this.registerSpouse = Convert.ToInt32(reader["RegisterSpouse"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MobileNo"))
                this.contactNo = Convert.ToString(reader["MobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_FirstName"))
                this.spouseFirstName = Convert.ToString(reader["Spouse_FirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_MiddleName"))
                this.spouseMiddleName = Convert.ToString(reader["Spouse_MiddleName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_LastName"))
                this.spouseLastName = Convert.ToString(reader["Spouse_LastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_ContactNo"))
                this.spouseContactNo = Convert.ToString(reader["Spouse_ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_GovIdType_ID"))
                this.spouseGovIdTypeId = Convert.ToInt32(reader["Spouse_GovIdType_ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_GovIdDetail"))
                this.spouseGovIdDetail = Convert.ToString(reader["Spouse_GovIdDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Religion_Id"))
                this.religionId = Convert.ToInt32(reader["Religion_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Caste_Id"))
                this.casteId = Convert.ToInt32(reader["Caste_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Community_Id"))
                this.communityId = Convert.ToInt32(reader["Community_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address1"))
                this.address1 = Convert.ToString(reader["Address1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address2"))
                this.address2 = Convert.ToString(reader["Address2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address3"))
                this.address3 = Convert.ToString(reader["Address3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateName"))
                this.stateName = Convert.ToString(reader["StateName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCTestResult"))
                this.hplcResult = Convert.ToString(reader["HPLCTestResult"]);
        }
    }
}
