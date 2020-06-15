using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMNotifications
{
    public class ANMNotificationSample : IFill
    {

        public int id { get; set; }
        public int subjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchID { get; set; }
        public int subjectTypeId { get; set; }
        public string subjectType { get; set; }
        public string barcodeNo { get; set; }
        public string contactNo { get; set; }
        public string gestationalAge { get; set; }
        public string dateOfCollection { get; set; }
        public string notifiedStatus { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ID"))
                this.id = Convert.ToInt32(reader["ID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectTypeID"))
                this.subjectTypeId = Convert.ToInt32(reader["SubjectTypeID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectType"))
                this.subjectType = Convert.ToString(reader["SubjectType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateofCollection"))
                this.dateOfCollection = Convert.ToString(reader["DateofCollection"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NotifiedStatus"))
                this.notifiedStatus = Convert.ToString(reader["NotifiedStatus"]);

        }
    }
}
