using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Support
{
    public class BarcodeUpdationDetails : IFill
    {
        public string subjectName { get; set; }
        public string subjectId { get; set; }
        public string anmName { get; set; }
        public string anmMobile { get; set; }
        public string anmEmail { get; set; }
        public string dcName { get; set; }
        public string dcMobile { get; set; }
        public string dcEmail { get; set; }
        public string scName { get; set; }
        public string scMobile { get; set; }
        public string scEmail { get; set; }
        public string oldBarcode { get; set; }
        public string revisedBarcode { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectId"))
                this.subjectId = Convert.ToString(reader["UniqueSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMMobile"))
                this.anmMobile = Convert.ToString(reader["ANMMobile"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMEmail"))
                this.anmEmail = Convert.ToString(reader["ANMEmail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCName"))
                this.dcName = Convert.ToString(reader["DCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCMobile"))
                this.dcMobile = Convert.ToString(reader["DCMobile"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DCEmail"))
                this.dcEmail = Convert.ToString(reader["DCEmail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCName"))
                this.scName = Convert.ToString(reader["SCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCMobileNo"))
                this.scMobile = Convert.ToString(reader["SCMobileNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SCEmail"))
                this.scEmail = Convert.ToString(reader["SCEmail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "OldBarcode"))
                this.oldBarcode = Convert.ToString(reader["OldBarcode"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NewBarcode"))
                this.revisedBarcode = Convert.ToString(reader["NewBarcode"]);

        }
    }
}
