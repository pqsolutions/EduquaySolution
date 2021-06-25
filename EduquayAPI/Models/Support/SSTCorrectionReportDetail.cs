using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Support
{
    public class SSTCorrectionReportDetail : IFill
    {
        public string subjectName { get; set; }
        public string subjectId { get; set; }
        public string barcodeNo { get; set; }
        public string oldSSTResult { get; set; }
        public string revisedSSTResult { get; set; }
        public string dateChanged { get; set; }
        public string anmName { get; set; }
        public string anmContact { get; set; }
        public string districtName { get; set; }
        public string chcName { get; set; }
        public string phcName { get; set; }
        public string dcName { get; set; }
        public string dcContact { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToString(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Barcode"))
                this.barcodeNo = Convert.ToString(reader["Barcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "OldSSTResult"))
                this.oldSSTResult = Convert.ToString(reader["OldSSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RevisedSSTResult"))
                this.revisedSSTResult = Convert.ToString(reader["RevisedSSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DateChanged"))
                this.dateChanged = Convert.ToString(reader["DateChanged"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMContact"))
                this.anmContact = Convert.ToString(reader["ANMContact"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DistrictName"))
                this.districtName = Convert.ToString(reader["DistrictName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCName"))
                this.chcName = Convert.ToString(reader["CHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PHCName"))
                this.phcName = Convert.ToString(reader["PHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCName"))
                this.dcName = Convert.ToString(reader["DCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCContact"))
                this.dcContact = Convert.ToString(reader["DCContact"]);
        }
    }
}