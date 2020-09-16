using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.ANMNotifications
{
    public class ANMPostMTPFollowUp : IFill
    {
        public int mtpId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string contactNo { get; set; }
        public string mtpDateTime { get; set; }
        public string obstetricianName { get; set; }
        public int firstFollowUp { get; set; }
        public string firstFollowUpStatusDetail { get; set; }
        public int secondFollowUp { get; set; }
        public string SecondFollowUpStatusDetail { get; set; }
        public int thirdFollowUp { get; set; }
        public string thirdFollowUpStatusDetail { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectName"))
                this.subjectName = Convert.ToString(reader["ANWSubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWContactNo"))
                this.contactNo  = Convert.ToString(reader["ANWContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPDateTime"))
                this.mtpDateTime = Convert.ToString(reader["MTPDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObstetritianName"))
                this.obstetricianName = Convert.ToString(reader["ObstetritianName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstFollowup"))
                this.firstFollowUp = Convert.ToInt32(reader["FirstFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstFollowupStatusDetail"))
                this.firstFollowUpStatusDetail = Convert.ToString(reader["FirstFollowupStatusDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SecondFollowup"))
                this.secondFollowUp  = Convert.ToInt32(reader["SecondFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SecondFollowupStatusDetail"))
                this.SecondFollowUpStatusDetail = Convert.ToString(reader["SecondFollowupStatusDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThirdFollowup"))
                this.thirdFollowUp  = Convert.ToInt32(reader["ThirdFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThirdFollowupStatusDetail"))
                this.thirdFollowUpStatusDetail  = Convert.ToString(reader["ThirdFollowupStatusDetail"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPID"))
                this.mtpId  = Convert.ToInt32(reader["MTPID"]);
        }
    }
}