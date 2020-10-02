using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Baby
{
    public class BabyRegistration : IFill
    {
        public string babySubjectId { get; set; }
        public string responseMsg { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "BabySubjectId"))
                this.babySubjectId = Convert.ToString(reader["BabySubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.responseMsg = Convert.ToString(reader["MSG"]);
        }
    }
}
