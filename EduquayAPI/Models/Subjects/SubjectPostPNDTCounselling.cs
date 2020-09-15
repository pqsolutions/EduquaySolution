using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Subjects
{
    public class SubjectPostPNDTCounselling : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string counsellorName { get; set; }
        public string counsellingStatus { get; set; }
        public string counsellingNotes { get; set; }
        public string agreedForMtp { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingDate"))
                this.date = Convert.ToString(reader["PostPNDTCounsellingDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingTime"))
                this.time = Convert.ToString(reader["PostPNDTCounsellingTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellorName"))
                this.counsellorName = Convert.ToString(reader["CounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingStatus"))
                this.counsellingStatus = Convert.ToString(reader["CounsellingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingNotes"))
                this.counsellingNotes = Convert.ToString(reader["CounsellingNotes"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AgreeForMTP"))
                this.agreedForMtp = Convert.ToString(reader["AgreeForMTP"]);
        }
    }
}
