using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMNotifications
{
    public class ANMSubjectSample : IFill
    {
        public int SubjectID { get; set; }
        public string UniqueSubjectID { get; set; }
        public string SubjectName { get; set; }
        public int ReasonId { get; set; }
        public string Reason { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectID"))
                this.SubjectID = Convert.ToInt32(reader["SubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.UniqueSubjectID = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.SubjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ReasonId"))
                this.ReasonId = Convert.ToInt32(reader["ReasonId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Reason"))
                this.Reason = Convert.ToString(reader["Reason"]);
        }
    }
}
