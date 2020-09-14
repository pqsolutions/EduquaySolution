using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class NotificationMTPService : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public bool isNotified { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPDate"))
                this.date = Convert.ToString(reader["MTPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPTime"))
                this.time = Convert.ToString(reader["MTPTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "NoitifiedStatus"))
                this.isNotified = Convert.ToBoolean(reader["NoitifiedStatus"]);
        }
    }
}
