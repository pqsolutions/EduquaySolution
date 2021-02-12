using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CentralLab
{
    public class CentralLabPickandPack : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string spouseSubjectId { get; set; }
        public int sampleCollectionId { get; set; }
        public string subjectName { get; set; }
        public string spouseName { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string spouseBarcodeNo { get; set; }
        public string sampleDateTime { get; set; }
        public string gestationalAge { get; set; }
        public string hplcTestResult { get; set; }

        public void Fill(SqlDataReader reader)
        {

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectId"))
                this.spouseSubjectId = Convert.ToString(reader["SpouseSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionID"))
                this.sampleCollectionId = Convert.ToInt32(reader["SampleCollectionID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "spouseName"))
                this.spouseName = Convert.ToString(reader["spouseName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseBarcodeNo"))
                this.spouseBarcodeNo = Convert.ToString(reader["SpouseBarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDateTime"))
                this.sampleDateTime = Convert.ToString(reader["SampleDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "HPLCResult"))
                this.hplcTestResult = Convert.ToString(reader["HPLCResult"]);

        }
    }
}