using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MobileTestMetrics:IFill
    {
        public int anwPositive { get; set; }
        public int spouseEvaluationCompleted { get; set; }
        public int spouseEvaluationPending { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWPositive"))
                this.anwPositive = Convert.ToInt32(reader["ANWPositive"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseEvaluationCompleted"))
                this.spouseEvaluationCompleted = Convert.ToInt32(reader["SpouseEvaluationCompleted"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseEvaluationPending"))
                this.spouseEvaluationPending = Convert.ToInt32(reader["SpouseEvaluationPending"]);
        }
    }
}
