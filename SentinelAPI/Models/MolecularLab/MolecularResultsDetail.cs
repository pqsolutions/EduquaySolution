using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class MolecularResultsDetail : IFill
    {
        public string babyName { get; set; }
        public string babySubjectId { get; set; }
        public string motherName { get; set; }
        public string motherSubjectId { get; set; }
        public string motherRCHID { get; set; }
        public string barcodeNo { get; set; }
        public string babyHospitalNo { get; set; }
        public string district { get; set; }
        public string gender { get; set; }
        public string birthWeight { get; set; }
        public string contactNo { get; set; }
        public string datetimeDelivery { get; set; }
        public string MotherHospitalNo { get; set; }
        public string fatherName { get; set; }
        public string guardianName { get; set; }
        public string address { get; set; }
        public string barcodes { get; set; }
        public string geneticDiagnosis { get; set; }
        public string geneticTestResult { get; set; }
        public string Remarks { get; set; }
        public  int diagnosisId { get; set; }
        public int resultId { get; set; }
        public bool isDamaged { get; set; }
        public bool isProcessed { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BirthWeight"))
                this.birthWeight = Convert.ToString(reader["BirthWeight"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherContactNo"))
                this.contactNo = Convert.ToString(reader["MotherContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DeliveryDateTime"))
                this.datetimeDelivery = Convert.ToString(reader["DeliveryDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherHospitalNo"))
                this.MotherHospitalNo = Convert.ToString(reader["MotherHospitalNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FatherName"))
                this.fatherName = Convert.ToString(reader["FatherName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GuardianName"))
                this.guardianName = Convert.ToString(reader["GuardianName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Address"))
                this.address = Convert.ToString(reader["Address"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNO"))
                this.barcodes = Convert.ToString(reader["BarcodeNO"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GeniticDiagnosis"))
                this.geneticDiagnosis = Convert.ToString(reader["GeniticDiagnosis"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GeneticTestResults"))
                this.geneticTestResult = Convert.ToString(reader["GeneticTestResults"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PathologistRemarks"))
                this.Remarks = Convert.ToString(reader["PathologistRemarks"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DiagnosisId"))
                this.diagnosisId = Convert.ToInt32(reader["DiagnosisId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ResultId"))
                this.resultId = Convert.ToInt32(reader["ResultId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsDamaged"))
                this.isDamaged = Convert.ToBoolean(reader["IsDamaged"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsProcessed"))
                this.isProcessed = Convert.ToBoolean(reader["IsProcessed"]);

        }
    }
}
