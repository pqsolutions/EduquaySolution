using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDT
{
    public class CounsellingDateTime : IFill
    {
        public string counsellingDate { get; set; }
        public string counsellingTime { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingDate"))
                this.counsellingDate = Convert.ToString(reader["CounsellingDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingTime"))
                this.counsellingTime = Convert.ToString(reader["CounsellingTime"]);
        }
    }
}
