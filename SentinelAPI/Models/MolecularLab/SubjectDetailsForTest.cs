using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.MolecularLab
{
    public class SubjectDetailsForTest : IFill
    {
        public string babyName { get; set; }
        public string babySubjectId { get; set; }
        public string motherName { get; set; }
        public string motherRCHID { get; set; }
        public string barcodeNo { get; set; }
        public string babyHospitalNo { get; set; }
        public string district { get; set; }

        public void Fill(SqlDataReader reader)
        {
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
