using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.MTPObstetrician
{
    public class MTPPending : IFill
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
        public string anwHPLCDiagnosis { get; set; }
        public string spouseCBCTestResult { get; set; }
        public string spouseSSTestResult { get; set; }
        public string spouseHPLCTestResult { get; set; }
        public string spouseHPLCDiagnosis { get; set; }
        public string prePNDTCounsellingDateTime { get; set; }
        public string prePNDTCounsellorName { get; set; }
        public string prePNDTCounsellingRemarks { get; set; }
        public string prePNDTCounsellingStatus { get; set; }
        public string schedulePrePNDTDate { get; set; }
        public string schedulePrePNDTTime { get; set; }
        public string pndtDateTime { get; set; }
        public string pndtObstetrician { get; set; }
        public string pndtResults { get; set; }
        public string pndtClinicalHistory { get; set; }
        public string pndtExamination{ get; set; }
        public string pndtProcedureOfTesting { get; set; }
        public string pndtComplications { get; set; }
        public bool foetalDisease { get; set; }
        public string pndtCounsellorName { get; set; }
        public string pndtDiagnosis { get; set; }
        public int postPNDTCounsellorId { get; set; }
        public string postPNDTCounsellorName { get; set; }
        public int postPNDTSchedulingId { get; set; }
        public int postPNDTCounsellingId { get; set; }
        public int postPNDTObstetricianId { get; set; }
        public string mtpScheduleDate { get; set; }
        public string mtpScheduleTime { get; set; }
        public string postPNDTCounsellingDateTime { get; set; }
        public string postPNDTCounsellingRemarks { get; set; }
        public string postPNDTCounsellingStatus { get; set; }


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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTSchedulingId"))
                this.postPNDTSchedulingId = Convert.ToInt32(reader["PostPNDTSchedulingId"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellingDateTime"))
                this.prePNDTCounsellingDateTime = Convert.ToString(reader["PrePNDTCounsellingDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellorName"))
                this.prePNDTCounsellorName = Convert.ToString(reader["PrePNDTCounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellingRemarks"))
                this.prePNDTCounsellingRemarks = Convert.ToString(reader["PrePNDTCounsellingRemarks"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellingStatus"))
                this.prePNDTCounsellingStatus = Convert.ToString(reader["PrePNDTCounsellingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchedulePNDTDate"))
                this.schedulePrePNDTDate = Convert.ToString(reader["SchedulePNDTDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchedulePNDTTime"))
                this.schedulePrePNDTTime = Convert.ToString(reader["SchedulePNDTTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDDateTime"))
                this.pndtDateTime = Convert.ToString(reader["PNDDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTestObstetrician"))
                this.pndtObstetrician = Convert.ToString(reader["PNDTestObstetrician"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTResults"))
                this.pndtResults = Convert.ToString(reader["PNDTResults"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTClinicalHistory"))
                this.pndtClinicalHistory = Convert.ToString(reader["PNDTClinicalHistory"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTExamination"))
                this.pndtExamination = Convert.ToString(reader["PNDTExamination"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTProcedureOfTesting"))
                this.pndtProcedureOfTesting = Convert.ToString(reader["PNDTProcedureOfTesting"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTComplications"))
                this.pndtComplications = Convert.ToString(reader["PNDTComplications"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "foetalDisease"))
                this.foetalDisease = Convert.ToBoolean(reader["foetalDisease"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellorName"))
                this.pndtCounsellorName = Convert.ToString(reader["PrePNDTCounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDiagnosisName"))
                this.pndtDiagnosis = Convert.ToString(reader["PNDTDiagnosisName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellorId"))
                this.postPNDTCounsellorId = Convert.ToInt32(reader["CounsellorId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellorName"))
                this.postPNDTCounsellorName = Convert.ToString(reader["PostPNDTCounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingId"))
                this.postPNDTCounsellingId = Convert.ToInt32(reader["PostPNDTCounsellingId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "AssignedObstetricianId"))
                this.postPNDTObstetricianId = Convert.ToInt32(reader["AssignedObstetricianId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ScheduleMTPDate"))
                this.mtpScheduleDate = Convert.ToString(reader["ScheduleMTPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ScheduleMTPTime"))
                this.mtpScheduleTime = Convert.ToString(reader["ScheduleMTPTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingDateTime"))
                this.postPNDTCounsellingDateTime = Convert.ToString(reader["PostPNDTCounsellingDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingRemarks"))
                this.postPNDTCounsellingRemarks = Convert.ToString(reader["PostPNDTCounsellingRemarks"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingStatus"))
                this.postPNDTCounsellingStatus = Convert.ToString(reader["PostPNDTCounsellingStatus"]);

        }
    }
}
