using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Mother
{
    public class MotherDetail: IFill
    {
        public string motherSubjectId { get; set; }
        public string dateofRegistration { get; set; }
        public int districtId { get; set; }
        public int hospitalId { get; set; }
        public string hospitalNo { get; set; }
        public int collectionSiteId { get; set; }
        public string motherFirstName { get; set; }
        public string motherLastName { get; set; }
        public string dob { get; set; }
        public int age { get; set; }
        public string rchId { get; set; }
        public int motherGovIdTypeId { get; set; }
        public string motherGovIdDetail { get; set; }
        public string motherContactNo { get; set; }
        public int g { get; set; }
        public int p { get; set; }
        public int l { get; set; }
        public int a { get; set; }
        public string ecNumber { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int stateId { get; set; }
        public string pincode { get; set; }
        public int religionId { get; set; }
        public int casteId { get; set; }
        public int communityId { get; set; }
        public string fatherFirstName { get; set; }
        public string fatherLastName { get; set; }
        public string fatherContactNo { get; set; }
        public string guardianFirstName { get; set; }
        public string guardianLastName { get; set; }
        public string guardianContactNo { get; set; }
        public List<MothersBabyDetail> babyDetail { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateofRegistration"))
                this.dateofRegistration = Convert.ToString(reader["DateofRegistration"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

           

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictId"))
                this.districtId = Convert.ToInt32(reader["DistrictId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalId"))
                this.hospitalId = Convert.ToInt32(reader["HospitalId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalNo"))
                this.hospitalNo = Convert.ToString(reader["HospitalNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CollectionSiteId"))
                this.collectionSiteId = Convert.ToInt32(reader["CollectionSiteId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherFirstName"))
                this.motherFirstName = Convert.ToString(reader["MotherFirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherLastName"))
                this.motherLastName = Convert.ToString(reader["MotherLastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DOB"))
                this.dob = Convert.ToString(reader["DOB"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToInt32(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherGovIdTypeId"))
                this.motherGovIdTypeId = Convert.ToInt32(reader["MotherGovIdTypeId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherGovIdDetail"))
                this.motherGovIdDetail = Convert.ToString(reader["MotherGovIdDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherContactNo"))
                this.motherContactNo = Convert.ToString(reader["MotherContactNo"]);


            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "G"))
                this.g = Convert.ToInt32(reader["G"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "P"))
                this.p = Convert.ToInt32(reader["P"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "L"))
                this.l = Convert.ToInt32(reader["L"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "A"))
                this.a = Convert.ToInt32(reader["A"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address1"))
                this.address1 = Convert.ToString(reader["Address1"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address2"))
                this.address2 = Convert.ToString(reader["Address2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address3"))
                this.address3 = Convert.ToString(reader["Address3"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateId"))
                this.stateId = Convert.ToInt32(reader["StateId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Pincode"))
                this.pincode = Convert.ToString(reader["Pincode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReligionId"))
                this.religionId = Convert.ToInt32(reader["ReligionId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CasteId"))
                this.casteId = Convert.ToInt32(reader["CasteId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CommunityId"))
                this.communityId = Convert.ToInt32(reader["CommunityId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FatherFirstName"))
                this.fatherFirstName = Convert.ToString(reader["FatherFirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FatherLastName"))
                this.fatherLastName = Convert.ToString(reader["FatherLastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FatherContactNo"))
                this.fatherContactNo = Convert.ToString(reader["FatherContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GuardianFirstName"))
                this.guardianFirstName = Convert.ToString(reader["GuardianFirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GuardianLastName"))
                this.guardianLastName = Convert.ToString(reader["GuardianLastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GuardianContactNo"))
                this.guardianContactNo = Convert.ToString(reader["GuardianContactNo"]);
        }
    }
}