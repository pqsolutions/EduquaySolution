using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.SMS
{
    public class SMSSamplesDetails : IFill
    {
        public string barcodeNo { get; set; }
        public string subjectId { get; set; }
        public string subjectName { get; set; }
        public string subjectMobileNo { get; set; }
        public string anmName { get; set; }
        public string anmMobileNo { get; set; }
        public int subjectTypeId { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTypeID"))
                this.subjectTypeId = Convert.ToInt32(reader["SubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectMobilNo"))
                this.subjectMobileNo = Convert.ToString(reader["SubjectMobilNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMMobileNo"))
                this.anmMobileNo = Convert.ToString(reader["ANMMobileNo"]);
        }
    }
}
