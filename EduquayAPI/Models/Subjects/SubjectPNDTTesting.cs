using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.Subjects
{
    public class SubjectPNDTTesting : IFill
    {
        public string uniqueSubjectId { get; set; }
        public string date { get; set; }
        public string time { get; set; }
        public string counsellorName { get; set; }
        public string obstetritionName { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public string procedureOfTesting { get; set; }
        public string pndtDiagnosis { get; set; }
        public string pndtresults { get; set; }
        public string pndtSideEffects { get; set; }

        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "UniqueSubjectID"))
                this.uniqueSubjectId = Convert.ToString(reader["UniqueSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDate"))
                this.date = Convert.ToString(reader["PNDTDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTTime"))
                this.time = Convert.ToString(reader["PNDTTime"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDiagnosisName"))
                this.pndtDiagnosis = Convert.ToString(reader["PNDTDiagnosisName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTResults"))
                this.pndtresults = Convert.ToString(reader["PNDTResults"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTSideEffects"))
                this.pndtSideEffects = Convert.ToString(reader["PNDTSideEffects"]);
        }
    }
}
