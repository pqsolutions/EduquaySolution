using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Mother
{
    public class MotherRegistration : IFill
    {
        public string subjectId { get; set; }
        public string responseMsg { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherSubjectId"))
                this.subjectId = Convert.ToString(reader["MotherSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.responseMsg = Convert.ToString(reader["MSG"]);
        }
    }
}
