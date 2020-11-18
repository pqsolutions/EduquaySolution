using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobilePNDTObsMetrics : IFill
    {
        public int pndtAgreed { get; set; }
        public int pndtCompleted { get; set; }
        public int pndtPending { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTAgreed"))
                this.pndtAgreed = Convert.ToInt32(reader["PNDTAgreed"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTCompleted"))
                this.pndtCompleted = Convert.ToInt32(reader["PNDTCompleted"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTPending"))
                this.pndtPending = Convert.ToInt32(reader["PNDTPending"]);
        }
    }
}
