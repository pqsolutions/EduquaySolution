using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDTObstetrician
{
    public class PNDTNotCompleted : IFill
    {
        public string anwSubjectId { get; set; }
        public string subjectName { get; set; }
        public string spouseSubjectId { get; set; }
        public string spouseName { get; set; }
        public string rchId { get; set; }
        public string contactNo { get; set; }
        public int age { get; set; }
        public int spouseAge { get; set; }
        public string ecNumber { get; set; }
        public decimal ga { get; set; }
        public string obstetricScore { get; set; }
        public string lmpDate { get; set; }
        public string anwCBCTestResult { get; set; }
        public string anwSSTestResult { get; set; }
        public string anwHPLCTestResult { get; set; }
        public string anwHPLCDiagnosis { get; set; }
        public string spouseCBCTestResult { get; set; }
        public string spouseSSTestResult { get; set; }
        public string spouseHPLCTestResult { get; set; }
        public string spouseHPLCDiagnosis { get; set; }
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
        public int procedureOfTestingId { get; set; }
        public string othersProcedureofTesting { get; set; }
        public string pndtComplecationsId { get; set; }
        public string othersComplecations { get; set; }
        public int pndtDiagnosisId { get; set; }
        public int pndtResultId { get; set; }
        public Boolean? motherVoided { get; set; }
        public Boolean? motherVitalStable { get; set; }
        public Boolean? foetalHeartRateDocumentScan { get; set; }
        public Boolean? planForPregnencyContinue { get; set; }
        public string anwMCV { get; set; }
        public string anwRDW { get; set; }
        public string anwRBC { get; set; }
        public string anwHbA0 { get; set; }
        public string anwHbA2 { get; set; }
        public string anwHbF { get; set; }
        public string anwHbS { get; set; }
        public string anwHbD { get; set; }
        public string spouseMCV { get; set; }
        public string spouseRDW { get; set; }
        public string spouseRBC { get; set; }
        public string spouseHbA0 { get; set; }
        public string spouseHbA2 { get; set; }
        public string spouseHbF { get; set; }
        public string spouseHbS { get; set; }
        public string spouseHbD { get; set; }
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


            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWHPLCDiagnosis"))
                this.anwHPLCDiagnosis = Convert.ToString(reader["ANWHPLCDiagnosis"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SPouseHPLCDiagnosis"))
                this.spouseHPLCDiagnosis = Convert.ToString(reader["SPouseHPLCDiagnosis"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ProcedureOfTestingId"))
                this.procedureOfTestingId = Convert.ToInt32(reader["ProcedureOfTestingId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "OthersProcedureofTesting"))
                this.othersProcedureofTesting = Convert.ToString(reader["OthersProcedureofTesting"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTComplecationsId"))
                this.pndtComplecationsId = Convert.ToString(reader["PNDTComplecationsId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "OthersComplecations"))
                this.othersComplecations = Convert.ToString(reader["OthersComplecations"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDiagnosisId"))
                this.pndtDiagnosisId = Convert.ToInt32(reader["PNDTDiagnosisId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTResultId"))
                this.pndtResultId = Convert.ToInt32(reader["PNDTResultId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherVoided"))
                this.motherVoided = Convert.ToBoolean(reader["MotherVoided"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MotherVitalStable"))
                this.motherVitalStable = Convert.ToBoolean(reader["MotherVitalStable"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FoetalHeartRateDocumentScan"))
                this.foetalHeartRateDocumentScan = Convert.ToBoolean(reader["FoetalHeartRateDocumentScan"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PlanForPregnencyContinue"))
                this.planForPregnencyContinue = Convert.ToBoolean(reader["PlanForPregnencyContinue"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseAge"))
                this.spouseAge = Convert.ToInt32(reader["SpouseAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_MCV"))
                this.anwMCV = Convert.ToString(reader["ANW_MCV"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_RDW"))
                this.anwRDW = Convert.ToString(reader["ANW_RDW"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_RBC"))
                this.anwRBC = Convert.ToString(reader["ANW_RBC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_HbA0"))
                this.anwHbA0 = Convert.ToString(reader["ANW_HbA0"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_HbA2"))
                this.anwHbA2 = Convert.ToString(reader["ANW_HbA2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_HbF"))
                this.anwHbF = Convert.ToString(reader["ANW_HbF"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_HbD"))
                this.anwHbD = Convert.ToString(reader["ANW_HbD"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANW_HbS"))
                this.anwHbS = Convert.ToString(reader["ANW_HbS"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_MCV"))
                this.spouseMCV = Convert.ToString(reader["Spouse_MCV"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_RDW"))
                this.spouseRDW = Convert.ToString(reader["Spouse_RDW"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_RBC"))
                this.spouseRBC = Convert.ToString(reader["Spouse_RBC"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_HbA0"))
                this.spouseHbA0 = Convert.ToString(reader["Spouse_HbA0"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_HbA2"))
                this.spouseHbA2 = Convert.ToString(reader["Spouse_HbA2"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_HbF"))
                this.spouseHbF = Convert.ToString(reader["Spouse_HbF"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_HbS"))
                this.spouseHbS = Convert.ToString(reader["Spouse_HbS"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Spouse_HbD"))
                this.spouseHbD = Convert.ToString(reader["Spouse_HbD"]);


        }
    }
}
