using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class MolecularLabReport : IFill
    {
        public string babyName { get; set; }
        public string babySubjectId { get; set; }
        public string babyDOB { get; set; }
        public string babyGender { get; set; }
        public string motherSubejctId { get; set; }
        public int motherAge { get; set; }
        public string address { get; set; }
        public string motherName { get; set; }
        public string contactNo { get; set; }
        public string fatherName { get; set; }
        public string motherRCHID { get; set; }
        public string barcodeNo { get; set; }
        public string babyHospitalNo { get; set; }
        public string hospitalName { get; set; }
        public string district { get; set; }
        public string testResult { get; set; }
        public string testDate { get; set; }
        public string sampleCollectionDate { get; set; }
        public string registrationDate { get; set; }
        public string molecularLabName { get; set; }
        public string orderingPhysician { get; set; }
        public string resultEnteredBy { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherAge"))
                this.motherAge = Convert.ToInt32(reader["MotherAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyGender"))
                this.babyGender = Convert.ToString(reader["BabyGender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateOfBirth"))
                this.babyDOB = Convert.ToString(reader["DateOfBirth"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherContactNo"))
                this.contactNo = Convert.ToString(reader["MotherContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubejctId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FatherName"))
                this.fatherName = Convert.ToString(reader["FatherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ResultEnteredBy"))
                this.resultEnteredBy = Convert.ToString(reader["ResultEnteredBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "OrderingPhysician"))
                this.orderingPhysician = Convert.ToString(reader["OrderingPhysician"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MolecularLabName"))
                this.molecularLabName = Convert.ToString(reader["MolecularLabName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HospitalName"))
                this.hospitalName = Convert.ToString(reader["HospitalName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegistrationDate"))
                this.registrationDate = Convert.ToString(reader["RegistrationDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestDate"))
                this.testDate = Convert.ToString(reader["TestDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestResult"))
                this.testResult = Convert.ToString(reader["TestResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherName"))
                this.motherName = Convert.ToString(reader["MotherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.motherRCHID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyHospitalNo"))
                this.babyHospitalNo = Convert.ToString(reader["BabyHospitalNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Districtname"))
                this.district = Convert.ToString(reader["Districtname"]);
        }
    }
}