using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.CHCNotifications
{
    public class CHCNotificationSample : IFill
    {
        public int sampleCollectionId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string barcodeNo { get; set; }
        public string contactNo { get; set; }
        public string gestationalAge { get; set; }
        public string notifiedStatus { get; set; }
        public string sampleType { get; set; }
        public string reason { get; set; }
        public string sampleCollectionDateTime { get; set; }
        public string sampleCollectionDate { get; set; }
        public string sampleCollectionTime { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionId"))
                this.sampleCollectionId = Convert.ToInt32(reader["SampleCollectionId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

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
                this.reason = Convert.ToString(reader["Reason"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDateTime"))
                this.sampleCollectionDateTime = Convert.ToString(reader["SampleDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionTime"))
                this.sampleCollectionTime = Convert.ToString(reader["SampleCollectionTime"]);

        }
    }
}
