using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileMetricSummaryMessage : IFill
    {
        public string responseMsg { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Comments"))
                this.responseMsg = Convert.ToString(reader["Comments"]);
        }
    }
}
