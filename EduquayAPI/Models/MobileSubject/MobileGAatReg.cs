using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileGAatReg : IFill
    {
        public int lt10Weeks { get; set; }
        public int gte10WeeksAndLt15Weeks { get; set; }
        public int gte15Weeks { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GALT10"))
                this.lt10Weeks = Convert.ToInt32(reader["GALT10"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GAGTE10GALT15"))
                this.gte10WeeksAndLt15Weeks = Convert.ToInt32(reader["GAGTE10GALT15"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GAGTE15"))
                this.gte15Weeks = Convert.ToInt32(reader["GAGTE15"]);
        }
    }
}
