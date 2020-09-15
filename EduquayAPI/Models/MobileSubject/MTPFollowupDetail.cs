using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MobileSubject
{
    public class MTPFollowupDetail : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string subjectName { get; set; }
        public string rchId { get; set; }
        public string contactNo { get; set; }
        public string mtpDateTime { get; set; }
        public string obstetricianName { get; set; }
        public List<MTPFirstFollowup> firstFollowUp { get; set; }
        public List<MTPSecondFollowup> secondFollowUp { get; set; }
        public List<MTPThirdFollowup> thirdFollowUp { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.uniqueSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectName"))
                this.subjectName = Convert.ToString(reader["ANWSubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWContactNo"))
                this.contactNo = Convert.ToString(reader["ANWContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPDateTime"))
                this.mtpDateTime = Convert.ToString(reader["MTPDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObstetritianName"))
                this.obstetricianName = Convert.ToString(reader["ObstetritianName"]);

        }
    }
}