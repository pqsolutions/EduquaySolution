using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMShipment
{
    public class ANMPickandPackSamples : IFill
    {
        public int subjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public int sampleCollectionId { get; set; }
        public string subjectName { get; set; }
        public string barcodeNo { get; set; }
        public string sampleDateTime { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionID"))
                this.sampleCollectionId = Convert.ToInt32(reader["SampleCollectionID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDateTime"))
                this.sampleDateTime = Convert.ToString(reader["SampleDateTime"]);
        }
    }
}
