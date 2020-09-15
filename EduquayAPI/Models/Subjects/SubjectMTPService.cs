using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Subjects
{
    public class SubjectMTPService : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string counsellorName { get; set; }
        public string obstetritionName { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public string procedureOfTesting { get; set; }
        public string conditionAtDischarge { get; set; }
        public string sideEffects { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPDate"))
                this.date = Convert.ToString(reader["MTPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPTime"))
                this.time = Convert.ToString(reader["MTPTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellorName"))
                this.counsellorName = Convert.ToString(reader["CounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObstetricianName"))
                this.obstetritionName = Convert.ToString(reader["ObstetricianName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ClinicalHistory"))
                this.clinicalHistory = Convert.ToString(reader["ClinicalHistory"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Examination"))
                this.examination = Convert.ToString(reader["Examination"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTProcedureOfTesting"))
                this.procedureOfTesting = Convert.ToString(reader["PNDTProcedureOfTesting"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "DischargeConditionName"))
                this.conditionAtDischarge = Convert.ToString(reader["DischargeConditionName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPComplications"))
                this.sideEffects = Convert.ToString(reader["MTPComplications"]);
        }
    }
}
