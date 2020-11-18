using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileCharts : IFill
    {
        public int year { get; set; }
        public int month { get; set; }
        public string monthName { get; set; }
        public int totalCount { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Year"))
                this.year = Convert.ToInt32(reader["Year"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Month"))
                this.month = Convert.ToInt32(reader["Month"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MonthName"))
                this.monthName = Convert.ToString(reader["MonthName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "TotalCount"))
                this.totalCount = Convert.ToInt32(reader["TotalCount"]);
        }
    }
}
