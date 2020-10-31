using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.PNDT
{
    public class PostPNDTCounselling : IFill
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
        public string spouseCBCTestResult { get; set; }
        public string spouseSSTestResult { get; set; }
        public string spouseHPLCTestResult { get; set; }
        public string prePNDTCounsellingDateTime { get; set; }
        public string prePNDTCounsellorName { get; set; }
        public string prePNDTCounsellingRemarks { get; set; }
        public string prePNDTCounsellingStatus { get; set; }
        public string schedulePrePNDTDate { get; set; }
        public string schedulePrePNDTTime { get; set; }
        public string pndtDateTime { get; set; }
        public string pndtObstetrician { get; set; }
        public string pndtResults { get; set; }
        public bool foetalDisease { get; set; }
        public string pndtCounsellorName { get; set; }
        public string pndtDiagnosis { get; set; }
        public int postPNDTCounsellorId { get; set; }
        public string postPNDTCounsellorName { get; set; }
        public int postPNDTSchedulingId { get; set; }
        public string postPNDTCounsellingDateTime { get; set; }
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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PreNDTCounsellingStatus"))
                this.prePNDTCounsellingStatus = Convert.ToString(reader["PreNDTCounsellingStatus"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "foetalDisease"))
                this.foetalDisease = Convert.ToBoolean(reader["foetalDisease"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PrePNDTCounsellorName"))
                this.pndtCounsellorName = Convert.ToString(reader["PrePNDTCounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDiagnosisName"))
                this.pndtDiagnosis = Convert.ToString(reader["PNDTDiagnosisName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellorName"))
                this.postPNDTCounsellorName = Convert.ToString(reader["PostPNDTCounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTSchedulingId"))
                this.postPNDTSchedulingId = Convert.ToInt32(reader["PostPNDTSchedulingId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellorId"))
                this.postPNDTCounsellorId = Convert.ToInt32(reader["CounsellorId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "CounsellingDateTime"))
                this.postPNDTCounsellingDateTime = Convert.ToString(reader["CounsellingDateTime"]);

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