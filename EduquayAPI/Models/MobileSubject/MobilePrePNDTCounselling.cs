using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobilePrePNDTCounselling : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string counsellorName { get; set; }
        public string counsellingStatus { get; set; }
        public string counsellingNotes { get; set; }
        public string agreedForPndt { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellingDate"))
                this.date = Convert.ToString(reader["PrePNDTCounsellingDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellingTime"))
                this.time = Convert.ToString(reader["PrePNDTCounsellingTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellorName"))
                this.counsellorName = Convert.ToString(reader["CounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingStatus"))
                this.counsellingStatus = Convert.ToString(reader["CounsellingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingNotes"))
                this.counsellingNotes = Convert.ToString(reader["CounsellingNotes"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AgreeForPNDT"))
                this.agreedForPndt  = Convert.ToString(reader["AgreeForPNDT"]);
        }
    }
}
