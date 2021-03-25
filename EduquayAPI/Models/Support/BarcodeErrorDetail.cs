using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Support
{
    public class BarcodeErrorDetail : IFill
    {
        public string barcodeNo { get; set; }
        public string subjectId { get; set; }
        public string rchId { get; set; }
        public string lmpDate { get; set; }
        public string subjectName { get; set; }
        public string anmName { get; set; }
        public string anmCode { get; set; }
        public string anmContact { get; set; }
        public string chc { get; set; }
        public string dcName { get; set; }
        public string dcContact { get; set; }
        public string loginStatus { get; set; }
        public bool loginIconEnableStatus { get; set; }
        public bool barcodeValid { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeNo"))
                this.barcodeNo = Convert.ToString(reader["BarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToString(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMCode"))
                this.anmCode = Convert.ToString(reader["ANMCode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMContact"))
                this.anmContact = Convert.ToString(reader["ANMContact"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCName"))
                this.chc = Convert.ToString(reader["CHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCName"))
                this.dcName = Convert.ToString(reader["DCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCContact"))
                this.dcContact = Convert.ToString(reader["DCContact"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LoginStatus"))
                this.loginStatus = Convert.ToString(reader["LoginStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LoginIconEnableStatus"))
                this.loginIconEnableStatus = Convert.ToBoolean(reader["LoginIconEnableStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BarcodeValid"))
                this.barcodeValid = Convert.ToBoolean(reader["BarcodeValid"]);
        }
    }
}
