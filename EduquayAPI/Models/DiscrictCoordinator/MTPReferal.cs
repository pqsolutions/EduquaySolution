using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Models.DiscrictCoordinator
{
    public class MTPReferal : IFill
    {
        public string anmName { get; set; }
        public string anmContactNo { get; set; }

        public string anwSubjectId { get; set; }
        public string anwSubjectName { get; set; }
        public string rchId { get; set; }
        public string anwBarcodes { get; set; }
        public string anwContactNo { get; set; }
        public string anwAge { get; set; }
        public string ecNumber { get; set; }
        public string anwGender { get; set; }
        public string address { get; set; }
        public string gestationalAge { get; set; }
        public string lmpDate { get; set; }
        public string gpla { get; set; }
        public string anwDOB { get; set; }
        public string anwDistrictName { get; set; }
        public string anwCHCName { get; set; }
        public string anwPHCName { get; set; }
        public string anwSCName { get; set; }
        public string anwRIPoint { get; set; }
        public string anwReligion { get; set; }
        public string anwCaste { get; set; }
        public string anwCommunity { get; set; }
        public string spouseSubjectId { get; set; }
        public string spouseSubjectName { get; set; }
        public string spouseBarcodes { get; set; }
        public string spouseContactNo { get; set; }
        public string spouseAge { get; set; }
        public string spouseGender { get; set; }
        public string spouseDOB { get; set; }
        public string spouseDistrictName { get; set; }
        public string spouseCHCName { get; set; }
        public string spousePHCName { get; set; }
        public string spouseSCName { get; set; }
        public string spouseRIPoint { get; set; }
        public string spouseReligion { get; set; }
        public string spouseCaste { get; set; }
        public string spouseCommunity { get; set; }

        public string anwCBCTestResult { get; set; }
        public string anwSSTestResult { get; set; }
        public string anwHPLCTestResult { get; set; }

        public string spouseCBCTestResult { get; set; }
        public string spouseSSTestResult { get; set; }
        public string spouseHPLCTestResult { get; set; }

        public string pndtCounsellorName { get; set; }
        public string pndtCounsellingRemarks { get; set; }
        public string pndtCounsellingStatus { get; set; }
        public string schedulePNDTDate { get; set; }
        public string schedulePNDTTime { get; set; }

        public string pndtDateTime { get; set; }
        public string pndtObstetricianName { get; set; }
        public string clinicalHistory { get; set; }
        public string examination { get; set; }
        public string pndtDiagnosisName { get; set; }
        public string pndtResults { get; set; }
        public string pndtProcedureOfTesting { get; set; }
        public string pndtSideEffects { get; set; }

        public string postPNDTCounsellingDate { get; set; }
        public string mtpDate { get; set; }
        public int mtpReferalId { get; set; }
        public string followUpStatus { get; set; }


        public void Fill(SqlDataReader reader)
        {
            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMName"))
                this.anmName = Convert.ToString(reader["ANMName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANMContactNo"))
                this.anmContactNo = Convert.ToString(reader["ANMContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectId"))
                this.anwSubjectId = Convert.ToString(reader["ANWSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectId"))
                this.spouseSubjectId = Convert.ToString(reader["SpouseSubjectId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSubjectName"))
                this.anwSubjectName = Convert.ToString(reader["ANWSubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSubjectName"))
                this.spouseSubjectName = Convert.ToString(reader["SpouseSubjectName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "RCHID"))
                this.rchId = Convert.ToString(reader["RCHID"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWBarcodeNo"))
                this.anwBarcodes = Convert.ToString(reader["ANWBarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseBarcodeNo"))
                this.spouseBarcodes = Convert.ToString(reader["SpouseBarcodeNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWContactNo"))
                this.anwContactNo = Convert.ToString(reader["ANWContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseContactNo"))
                this.spouseContactNo = Convert.ToString(reader["SpouseContactNo"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWAge"))
                this.anwAge = Convert.ToString(reader["ANWAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseAge"))
                this.spouseAge = Convert.ToString(reader["SpouseAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ECNumber"))
                this.ecNumber = Convert.ToString(reader["ECNumber"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWGender"))
                this.anwGender = Convert.ToString(reader["ANWGender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseGender"))
                this.spouseGender = Convert.ToString(reader["SpouseGender"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SubjectAddress"))
                this.address = Convert.ToString(reader["SubjectAddress"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseDateOFBirth"))
                this.spouseDOB = Convert.ToString(reader["SpouseDateOFBirth"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWDateOFBirth"))
                this.anwDOB = Convert.ToString(reader["ANWDateOFBirth"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "LMPDate"))
                this.lmpDate = Convert.ToString(reader["LMPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GPLA"))
                this.gpla = Convert.ToString(reader["GPLA"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "GestationalAge"))
                this.gestationalAge = Convert.ToString(reader["GestationalAge"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWDistrict"))
                this.anwDistrictName = Convert.ToString(reader["ANWDistrict"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWCHCName"))
                this.anwCHCName = Convert.ToString(reader["ANWCHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWPHCName"))
                this.anwPHCName = Convert.ToString(reader["ANWPHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWSCName"))
                this.anwSCName = Convert.ToString(reader["ANWSCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWRIPoint"))
                this.anwRIPoint = Convert.ToString(reader["ANWRIPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWReligion"))
                this.anwReligion = Convert.ToString(reader["ANWReligion"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWCaste"))
                this.anwCaste = Convert.ToString(reader["ANWCaste"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ANWCommunity"))
                this.anwCommunity = Convert.ToString(reader["ANWCommunity"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseDistrict"))
                this.spouseDistrictName = Convert.ToString(reader["SpouseDistrict"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseCHCName"))
                this.spouseCHCName = Convert.ToString(reader["SpouseCHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpousePHCName"))
                this.spousePHCName = Convert.ToString(reader["SpousePHCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseSCName"))
                this.spouseSCName = Convert.ToString(reader["SpouseSCName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseRIPoint"))
                this.spouseRIPoint = Convert.ToString(reader["SpouseRIPoint"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseReligion"))
                this.spouseReligion = Convert.ToString(reader["SpouseReligion"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseCaste"))
                this.spouseCaste = Convert.ToString(reader["SpouseCaste"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SpouseCommunity"))
                this.spouseCommunity = Convert.ToString(reader["SpouseCommunity"]);

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

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PostPNDTCounsellingDate"))
                this.postPNDTCounsellingDate = Convert.ToString(reader["PostPNDTCounsellingDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPDate"))
                this.mtpDate = Convert.ToString(reader["MTPDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "FollowUpStatus"))
                this.followUpStatus = Convert.ToString(reader["FollowUpStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "MTPReferalId"))
                this.mtpReferalId = Convert.ToInt32(reader["MTPReferalId"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTCounsellorName"))
                this.pndtCounsellorName = Convert.ToString(reader["PNDTCounsellorName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTCounsellingRemarks"))
                this.pndtCounsellingRemarks = Convert.ToString(reader["PNDTCounsellingRemarks"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTCounsellingStatus"))
                this.pndtCounsellingStatus = Convert.ToString(reader["PNDTCounsellingStatus"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchedulePNDTDate"))
                this.schedulePNDTDate = Convert.ToString(reader["SchedulePNDTDate"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "SchedulePNDTTime"))
                this.schedulePNDTTime = Convert.ToString(reader["SchedulePNDTTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDateTime"))
                this.pndtDateTime = Convert.ToString(reader["PNDTDateTime"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTObstetricianName"))
                this.pndtObstetricianName = Convert.ToString(reader["PNDTObstetricianName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "ClinicalHistory"))
                this.clinicalHistory = Convert.ToString(reader["ClinicalHistory"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "Examination"))
                this.examination = Convert.ToString(reader["Examination"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTDiagnosisName"))
                this.pndtDiagnosisName = Convert.ToString(reader["PNDTDiagnosisName"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTResults"))
                this.pndtResults = Convert.ToString(reader["PNDTResults"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTProcedureOfTesting"))
                this.pndtProcedureOfTesting = Convert.ToString(reader["PNDTProcedureOfTesting"]);

            if (CommonUtility.IsColumnExistsAndNotNull(reader, "PNDTSideEffects"))
                this.pndtSideEffects = Convert.ToString(reader["PNDTSideEffects"]);
        }
    }
}
