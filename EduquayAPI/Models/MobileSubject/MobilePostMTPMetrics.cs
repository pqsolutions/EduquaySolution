using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobilePostMTPMetrics : IFill
    {
        public int postMTP0to30Days { get; set; }
        public int postMTP31to45Days { get; set; }
        public int postMTP46to60Days { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostMTP0to30Days"))
                this.postMTP0to30Days = Convert.ToInt32(reader["PostMTP0to30Days"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostMTP31to45Days"))
                this.postMTP31to45Days = Convert.ToInt32(reader["PostMTP31to45Days"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostMTP46to60Days"))
                this.postMTP46to60Days = Convert.ToInt32(reader["PostMTP46to60Days"]);
        }
    }
}
