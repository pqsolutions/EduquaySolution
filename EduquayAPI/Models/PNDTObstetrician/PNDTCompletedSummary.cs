using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDTObstetrician
{
    public class PNDTCompletedSummary : IFill
    {
        public string anwSubjectId { get; set; }
        public string subjectName { get; set; }
        public string spouseSubjectId { get; set; }
        public string spouseName { get; set; }
        public string rchId { get; set; }
        public string contactNo { get; set; }
        public int age { get; set; }
        public string ecNumber { get; set; }
        public decimal ga { get; set; }
        public string obstetricScore { get; set; }
        public string lmpDate { get; set; }
        public string anwCBCTestResult { get; set; }
        public string anwSSTestResult { get; set; }
        public string anwHPLCTestResult { get; set; }
        public string spouseCBCTestResult { get; set; }
        public string spouseSSTestResult { get; set; }
        public string spouseHPLCTestResult { get; set; }
        public int prePNDTCounsellingId { get; set; }
        public int schedulingId { get; set; }
        public string counsellingDateTime { get; set; }
        public int counsellorId { get; set; }
        public string counsellorName { get; set; }
        public int obstetricianId { get; set; }
        public string obstetricianName { get; set; }
        public string schedulePNDTDate { get; set; }
        public string schedulePNDTTime { get; set; }
        public string counsellingRemarks { get; set; }
        public string counsellingStatus { get; set; }
        public int pndTestId { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public string procedureofTesting { get; set; }
        public string pndtComplecations { get; set; }
        public string pndtDiagnosis { get; set; }
        public string pndtResult { get; set; }
        public string motherVoided { get; set; }
        public string motherVitalStable { get; set; }
        public string foetalHeartRateDocumentScan { get; set; }
        public string planForPregnency { get; set; }


        public void Fill(SqlDataReader reader)
        {


            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.anwSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectName"))
                this.subjectName = Convert.ToString(reader["SubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectID"))
                this.spouseSubjectId = Convert.ToString(reader["SpouseSubjectID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseName"))
                this.spouseName = Convert.ToString(reader["SpouseName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ContactNo"))
                this.contactNo = Convert.ToString(reader["ContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.ga = Convert.ToDecimal(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObstetricScore"))
                this.obstetricScore = Convert.ToString(reader["ObstetricScore"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Age"))
                this.age = Convert.ToInt32(reader["Age"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWCBCResult"))
                this.anwCBCTestResult = Convert.ToString(reader["ANWCBCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSSTResult"))
                this.anwSSTestResult = Convert.ToString(reader["ANWSSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWHPLCResult"))
                this.anwHPLCTestResult = Convert.ToString(reader["ANWHPLCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseCBCResult"))
                this.spouseCBCTestResult = Convert.ToString(reader["SpouseCBCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSSTResult"))
                this.spouseSSTestResult = Convert.ToString(reader["SpouseSSTResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseHPLCResult"))
                this.spouseHPLCTestResult = Convert.ToString(reader["SpouseHPLCResult"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingId"))
                this.prePNDTCounsellingId = Convert.ToInt32(reader["CounsellingId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellorId"))
                this.counsellorId = Convert.ToInt32(reader["CounsellorId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingDateTime"))
                this.counsellingDateTime = Convert.ToString(reader["CounsellingDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchedulingId"))
                this.schedulingId = Convert.ToInt32(reader["SchedulingId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellorName"))
                this.counsellorName = Convert.ToString(reader["CounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AssignedObstetricianId"))
                this.obstetricianId = Convert.ToInt32(reader["AssignedObstetricianId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ObsetricianName"))
                this.obstetricianName = Convert.ToString(reader["ObsetricianName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchedulePNDTDate"))
                this.schedulePNDTDate = Convert.ToString(reader["SchedulePNDTDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchedulePNDTTime"))
                this.schedulePNDTTime = Convert.ToString(reader["SchedulePNDTTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingRemarks"))
                this.counsellingRemarks = Convert.ToString(reader["CounsellingRemarks"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingStatus"))
                this.counsellingStatus = Convert.ToString(reader["CounsellingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTTestID"))
                this.pndTestId = Convert.ToInt32(reader["PNDTTestID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ClinicalHistory"))
                this.clinicalHistory = Convert.ToString(reader["ClinicalHistory"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Examination"))
                this.examination = Convert.ToString(reader["Examination"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ProcedureOfTesting"))
                this.procedureofTesting = Convert.ToString(reader["ProcedureOfTesting"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Complications"))
                this.pndtComplecations = Convert.ToString(reader["Complications"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDiagnosis"))
                this.pndtDiagnosis = Convert.ToString(reader["PNDTDiagnosis"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTResults"))
                this.pndtResult = Convert.ToString(reader["PNDTResults"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherVoided"))
                this.motherVoided = Convert.ToString(reader["MotherVoided"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherVitalStable"))
                this.motherVitalStable = Convert.ToString(reader["MotherVitalStable"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FoetalHeartRatedocumentedinScan"))
                this.foetalHeartRateDocumentScan = Convert.ToString(reader["FoetalHeartRatedocumentedinScan"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PlanforPregnancy"))
                this.planForPregnency = Convert.ToString(reader["PlanforPregnancy"]);

        }
    }
}
