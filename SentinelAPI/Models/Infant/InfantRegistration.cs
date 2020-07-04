using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Models.Infant
{
    public class InfantRegistration : IFill
    {
        public string infantSubjectId { get; set; }
        public string responseMsg { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "InfantSubjectId"))
                this.infantSubjectId = Convert.ToString(reader["InfantSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MSG"))
                this.responseMsg = Convert.ToString(reader["MSG"]);
        }
    }
}
