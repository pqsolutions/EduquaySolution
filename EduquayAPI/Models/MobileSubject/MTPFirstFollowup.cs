using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MTPFirstFollowup : IFill
    {
      
        public string uniqueSubjectId { get; set; }
        public int followUpNo { get; set; }
        public int firstFollowUpStatusId { get; set; }
        public string firstFollowUpStatusDetail { get; set; }
      

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstFollowup"))
                this.firstFollowUpStatusId = Convert.ToInt32(reader["FirstFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstFollowupStatusDetail"))
                this.firstFollowUpStatusDetail = Convert.ToString(reader["FirstFollowupStatusDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstFollowupNo"))
                this.followUpNo = Convert.ToInt32(reader["FirstFollowupNo"]);
           
        }
    }
}