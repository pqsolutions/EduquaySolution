using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileMTPObsMetrics : IFill
    {
        public int mtpReffered { get; set; }
        public int mtpCompleted { get; set; }
        public int mtpPending { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPReffered"))
                this.mtpReffered = Convert.ToInt32(reader["MTPReffered"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPCompleted"))
                this.mtpCompleted = Convert.ToInt32(reader["MTPCompleted"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPPending"))
                this.mtpPending = Convert.ToInt32(reader["MTPPending"]);
        }
    }
}