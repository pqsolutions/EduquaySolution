using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class SampleCollection :IFill
    {
        public string uniqueSubjectID { get; set; }
        public string barcodeNo { get; set; }
        public string sampleCollectionDate { get; set; }
        public string sampleCollectionTime { get; set; }
        public string barcodeDamaged { get; set; }
        public string sampleDamaged { get; set; }
        public string sampleTimeoutExpiry { get; set; }
        public string isAccept { get; set; }
        public int reasonId { get; set; }
        public int collectionFrom { get; set; }
        public int collectedBy { get; set; }
        public string notifiedStatus { get; set; }
        public string notifiedOn { get; set; }
        public string isRecollected { get; set; }
        public int createdBy { get; set; }
        public string createdOn { get; set; }
        public int updatedBy { get; set; }
        public string updatedOn { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionDate"))
                this.sampleCollectionDate = Convert.ToString(reader["SampleCollectionDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleCollectionTime"))
                this.sampleCollectionTime = Convert.ToString(reader["SampleCollectionTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeDamaged"))
                this.barcodeDamaged = Convert.ToString(reader["BarcodeDamaged"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleDamaged"))
                this.sampleDamaged = Convert.ToString(reader["SampleDamaged"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SampleTimeoutExpiry"))
                this.sampleTimeoutExpiry = Convert.ToString(reader["SampleTimeoutExpiry"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsAccept"))
                this.isAccept = Convert.ToString(reader["IsAccept"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Reason_Id"))
                this.reasonId = Convert.ToInt32(reader["Reason_Id"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CollectionFrom"))
                this.collectionFrom = Convert.ToInt32(reader["CollectionFrom"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CollectedBy"))
                this.collectedBy = Convert.ToInt32(reader["CollectedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NotifiedStatus"))
                this.notifiedStatus = Convert.ToString(reader["NotifiedStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NotifiedOn"))
                this.notifiedOn = Convert.ToString(reader["NotifiedOn"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "IsRecollected"))
                this.isRecollected = Convert.ToString(reader["IsRecollected"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedBy"))
                this.createdBy = Convert.ToInt32(reader["CreatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CreatedOn"))
                this.createdOn = Convert.ToString(reader["CreatedOn"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedBy"))
                this.updatedBy = Convert.ToInt32(reader["UpdatedBy"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UpdatedOn"))
                this.updatedOn = Convert.ToString(reader["UpdatedOn"]);

        }
    }
}
