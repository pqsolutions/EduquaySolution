using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Profile
{
    public class MotherProfile : IFill
    {
        public string motherSubjectId { get; set; }
        public string dateofRegistration { get; set; }
        public string hospitalNo { get; set; }
        public string motherFirstName { get; set; }
        public string motherLastName { get; set; }
        public string dob { get; set; }
        public int age { get; set; }
        public string rchId { get; set; }
        public int motherGovIdTypeId { get; set; }
        public string motherGovIdDetail { get; set; }
        public string motherContactNo { get; set; }
        public string ecNumber { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string address3 { get; set; }
        public int districtId { get; set; }
        public string districtName { get; set; }
        public int stateId { get; set; }
        public string stateName { get; set; }
        public string pincode { get; set; }
        public string fatherFirstName { get; set; }
        public string fatherLastName { get; set; }
        public string fatherContactNo { get; set; }
        public string guardianFirstName { get; set; }
        public string guardianLastName { get; set; }
        public string guardianContactNo { get; set; }
        public string religionName { get; set; }
        public string casteName { get; set; }
        public string communityName { get; set; }
        public string gpla { get; set; }
        public string motherHospitalName { get; set; }
        public string motherHospitalAddress { get; set; }
        public string motherHospitalContactNo { get; set; }
        public List<MotherBabiesDetail> babyDetail { get; set; }
        public void Fill(SqlDataReader reader)
        {
           

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictId"))
                this.districtId = Convert.ToInt32(reader["DistrictId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictName"))
                this.districtName = Convert.ToString(reader["DistrictName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "StateName"))
                this.stateName = Convert.ToString(reader["StateName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateofRegistration"))
                this.dateofRegistration = Convert.ToString(reader["DateofRegistration"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalNo"))
                this.hospitalNo = Convert.ToString(reader["HospitalNo"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherHospitalContactNo"))
                this.motherHospitalContactNo = Convert.ToString(reader["MotherHospitalContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherHospitalName"))
                this.motherHospitalName = Convert.ToString(reader["MotherHospitalName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherHospitalAddress"))
                this.motherHospitalAddress = Convert.ToString(reader["MotherHospitalAddress"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GPLA"))
                this.gpla = Convert.ToString(reader["GPLA"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CommunityName"))
                this.communityName = Convert.ToString(reader["CommunityName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CasteName"))
                this.casteName = Convert.ToString(reader["CasteName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReligionName"))
                this.religionName = Convert.ToString(reader["ReligionName"]);
        }
    }
}
