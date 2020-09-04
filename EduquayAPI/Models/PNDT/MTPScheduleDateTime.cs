using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDT
{
    public class MTPScheduleDateTime : IFill
    {
        public string scheduleMTPDate { get; set; }
        public string scheduleMTPTime { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ScheduleMTPDate"))
                this.scheduleMTPDate = Convert.ToString(reader["ScheduleMTPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ScheduleMTPTime"))
                this.scheduleMTPTime = Convert.ToString(reader["ScheduleMTPTime"]);
        }
    }
}
