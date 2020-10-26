using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Profile
{
    public class MotherBabiesDetail : IFill
    {
        public string motherSubjectId { get; set; }
        public string babySubjectId { get; set; }
        public string babyName { get; set; }
        public string gender { get; set; }
        public string deliveryDateTime { get; set; }
        public string birthWeight { get; set; }
        public string birthStatus { get; set; }
        public string geneticResult { get; set; }
        public string geneticDiagnosis { get; set; }
        public string pathologistRemarks { get; set; }
        public string babyHospitalName { get; set; }
        public string babyHospitalAddress { get; set; }
        public string babyHospitalContactNo { get; set; }
        public string babyHospital { get; set; }
        public string barcodeNo { get; set; }
        public string babyFirstName { get; set; }
        public string babyLastName { get; set; }
        public int birthStatusId { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BirthStatusId"))
                this.birthStatusId = Convert.ToInt32(reader["BirthStatusId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyFirstName"))
                this.babyFirstName = Convert.ToString(reader["BabyFirstName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyLastName"))
                this.babyLastName = Convert.ToString(reader["BabyLastName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyHospital"))
                this.babyHospital = Convert.ToString(reader["BabyHospital"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PathologistRemarks"))
                this.pathologistRemarks = Convert.ToString(reader["PathologistRemarks"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GeniticDiagnosis"))
                this.geneticDiagnosis = Convert.ToString(reader["GeniticDiagnosis"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyHospitalContactNo"))
                this.babyHospitalContactNo = Convert.ToString(reader["BabyHospitalContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyHospitalName"))
                this.babyHospitalName = Convert.ToString(reader["BabyHospitalName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyHospitalAddress"))
                this.babyHospitalAddress = Convert.ToString(reader["BabyHospitalAddress"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.motherSubjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabyName"))
                this.babyName = Convert.ToString(reader["BabyName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Gender"))
                this.gender = Convert.ToString(reader["Gender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DeliveryDatetime"))
                this.deliveryDateTime = Convert.ToString(reader["DeliveryDatetime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BirthWeight"))
                this.birthWeight = Convert.ToString(reader["BirthWeight"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BirthStatus"))
                this.birthStatus = Convert.ToString(reader["BirthStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GeniticResult"))
                this.geneticResult = Convert.ToString(reader["GeniticResult"]);

        }
    }
}
