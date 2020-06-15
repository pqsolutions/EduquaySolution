using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMNotifications
{
    public class ANMSubjectSample : IFill
    {
        public int subjectId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public int reasonId { get; set; }
        public string reason { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.subjectId = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReasonId"))
                this.reasonId = Convert.ToInt32(reader["ReasonId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Reason"))
                this.reason = Convert.ToString(reader["Reason"]);
        }
    }
}
