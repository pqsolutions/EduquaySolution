using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.DiscrictCoordinator
{
    public class DCPostMTPFollowUp : IFill
    {
        public int mtpId { get; set; }
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string anmContactNo { get; set; }
        public string anmName { get; set; }
        public string mtpDateTime { get; set; }
        public string chcName { get; set; }
        public string firstFollowUp { get; set; }
        public string secondFollowUp { get; set; }
        public string thirdFollowUp { get; set; }
        public bool followupStatus { get; set; }
        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectName"))
                this.subjectName = Convert.ToString(reader["ANWSubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMContactNo"))
                this.anmContactNo = Convert.ToString(reader["ANMContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPDateTime"))
                this.mtpDateTime = Convert.ToString(reader["MTPDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CHCname"))
                this.chcName = Convert.ToString(reader["CHCname"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FirstFollowup"))
                this.firstFollowUp = Convert.ToString(reader["FirstFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SecondFollowup"))
                this.secondFollowUp = Convert.ToString(reader["SecondFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ThirdFollowup"))
                this.thirdFollowUp = Convert.ToString(reader["ThirdFollowup"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPID"))
                this.mtpId = Convert.ToInt32(reader["MTPID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FollowUpStatus"))
                this.followupStatus = Convert.ToBoolean(reader["FollowUpStatus"]);
        }
    }
}