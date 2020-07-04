using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMNotifications
{
    public class ANMNotificationSample : IFill
    {

        public int sampleCollectionId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchID { get; set; }
        public string barcodeNo { get; set; }
        public string contactNo { get; set; }
        public string gestationalAge { get; set; }
        public string notifiedStatus { get; set; }
        public string sampleType { get; set; }
        public string Reason { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionId"))
                this.sampleCollectionId = Convert.ToInt32(reader["SampleCollectionId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchID = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NotifiedStatus"))
                this.notifiedStatus = Convert.ToString(reader["NotifiedStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleType"))
                this.sampleType = Convert.ToString(reader["SampleType"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Reason"))
                this.Reason = Convert.ToString(reader["Reason"]);
        }
    }
}
