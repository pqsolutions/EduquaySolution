using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MTPThirdFollowup : IFill
    {

        public string uniqueSubjectId { get; set; }
        public int followUpNo { get; set; }
        public int thirdFollowUpStatusId { get; set; }
        public string thirdFollowUpStatusDetail { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThirdFollowup"))
                this.thirdFollowUpStatusId = Convert.ToInt32(reader["ThirdFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThirdFollowupStatusDetail"))
                this.thirdFollowUpStatusDetail = Convert.ToString(reader["ThirdFollowupStatusDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThirdFollowupNo"))
                this.followUpNo = Convert.ToInt32(reader["ThirdFollowupNo"]);

        }
    }
}