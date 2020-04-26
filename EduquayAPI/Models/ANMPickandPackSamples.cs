using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models
{
    public class ANMPickandPackSamples : IFill
    {
        public int SubjectID { get; set; }
        public string UniqueSubjectID { get; set; }
        public string SubjectName { get; set; }
        public string BarcodeNo { get; set; }
        public string SampleDateTime { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.SubjectID = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.SubjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.BarcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDateTime"))
                this.SampleDateTime = Convert.ToString(reader["SampleDateTime"]);
        }
    }
}
