using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MTPSecondFollowup : IFill
    {

        public string uniqueSubjectId { get; set; }
        public int followUpNo { get; set; }
        public int secondFollowUpStatusId { get; set; }
        public string secondFollowUpStatusDetail { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SecondFollowup"))
                this.secondFollowUpStatusId = Convert.ToInt32(reader["SecondFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SecondFollowupStatusDetail"))
                this.secondFollowUpStatusDetail = Convert.ToString(reader["SecondFollowupStatusDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SecondFollowupNo"))
                this.followUpNo = Convert.ToInt32(reader["SecondFollowupNo"]);

        }
    }
}