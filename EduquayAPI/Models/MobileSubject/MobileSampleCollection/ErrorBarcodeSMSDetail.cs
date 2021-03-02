using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject.MobileSampleCollection
{
    public class ErrorBarcodeSMSDetail : IFill
    {
        public string barcode { get; set; }
        public string uniqueSubjectId { get; set; }
        public string sampleCollectionDate { get; set; }
        public string subjectMobileNo { get; set; }
        public string anmMobileNo { get; set; }
        public string anmName { get; set; }
        public string existUniqueSubjectId { get; set; }
        public string existSampleCollectionDate { get; set; }
        public string existSubjectMobileNo { get; set; }
        public string existANMMobileNo { get; set; }
        public string existANMName { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcode = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectMobilNo"))
                this.subjectMobileNo = Convert.ToString(reader["SubjectMobilNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMMobileNo"))
                this.anmMobileNo = Convert.ToString(reader["ANMMobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistUniqueSubjectID"))
                this.existUniqueSubjectId = Convert.ToString(reader["ExistUniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistSampleCollectionDate"))
                this.existSampleCollectionDate = Convert.ToString(reader["ExistSampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistSubjectMobilNo"))
                this.existSubjectMobileNo = Convert.ToString(reader["ExistSubjectMobilNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistANMMobileNo"))
                this.existANMMobileNo = Convert.ToString(reader["ExistANMMobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistANMName"))
                this.existANMName = Convert.ToString(reader["ExistANMName"]);
        }
    }
}
