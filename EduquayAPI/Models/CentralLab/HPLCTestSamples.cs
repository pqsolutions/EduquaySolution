using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CentralLab
{
    public class HPLCTestSamples : IFill
    {
        public string subjectName { get; set; }
        public string subjectId { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string HbF { get; set; }
        public string HbA0 { get; set; }
        public string HbA2 { get; set; }
        public string HbS { get; set; }
        public string HbD { get; set; }
        public string testedDate { get; set; }
        public int testId { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCID"))
                this.testId = Convert.ToInt32(reader["HPLCID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TestedDate"))
                this.testedDate = Convert.ToString(reader["TestedDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbF"))
                this.HbF = Convert.ToString(reader["HbF"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA0"))
                this.HbA0 = Convert.ToString(reader["HbA0"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbA2"))
                this.HbA2 = Convert.ToString(reader["HbA2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbS"))
                this.HbS = Convert.ToString(reader["HbS"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HbD"))
                this.HbD = Convert.ToString(reader["HbD"]);
        }
    }

}
