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
        public string rchId { get; set; }
        public string lmpDate { get; set; }
        public string subjectName { get; set; }
        public string sampleCollectionDate { get; set; }
        public string subjectMobileNo { get; set; }
        public string anmMobileNo { get; set; }
        public string anmName { get; set; }
        public string anmSCName { get; set; }
        public string existUniqueSubjectId { get; set; }
        public string existSubjectName { get; set; }
        public string existSampleCollectionDate { get; set; }
        public string existSubjectMobileNo { get; set; }
        public string existANMMobileNo { get; set; }
        public string existANMName { get; set; }
        public string existANMSCName { get; set; }
        public int existANMId { get; set; }
        public int anmId { get; set; }
        public string chcName { get; set; }
        public string existCHCName { get; set; }
        public string phcName { get; set; }
        public string existPHCName { get; set; }
        public string regDate { get; set; }
        public string existRegDate { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCName"))
                this.chcName = Convert.ToString(reader["CHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistCHCName"))
                this.existCHCName = Convert.ToString(reader["ExistCHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCName"))
                this.phcName = Convert.ToString(reader["PHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistPHCName"))
                this.existPHCName = Convert.ToString(reader["ExistPHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RegDate"))
                this.regDate = Convert.ToString(reader["RegDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistRegDate"))
                this.existRegDate = Convert.ToString(reader["ExistRegDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMId"))
                this.anmId = Convert.ToInt32(reader["ANMId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistANMId"))
                this.existANMId = Convert.ToInt32(reader["ExistANMId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcode = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectMobilNo"))
                this.subjectMobileNo = Convert.ToString(reader["SubjectMobilNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMMobileNo"))
                this.anmMobileNo = Convert.ToString(reader["ANMMobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMSCName"))
                this.anmSCName = Convert.ToString(reader["ANMSCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistUniqueSubjectID"))
                this.existUniqueSubjectId = Convert.ToString(reader["ExistUniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistSubjectName"))
                this.existSubjectName = Convert.ToString(reader["ExistSubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistSampleCollectionDate"))
                this.existSampleCollectionDate = Convert.ToString(reader["ExistSampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistSubjectMobilNo"))
                this.existSubjectMobileNo = Convert.ToString(reader["ExistSubjectMobilNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistANMMobileNo"))
                this.existANMMobileNo = Convert.ToString(reader["ExistANMMobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistANMName"))
                this.existANMName = Convert.ToString(reader["ExistANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ExistANMSCName"))
                this.existANMSCName = Convert.ToString(reader["ExistANMSCName"]);
        }
    }
}
