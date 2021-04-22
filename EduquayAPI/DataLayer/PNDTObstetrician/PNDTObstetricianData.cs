using EduquayAPI.Contracts.V1.Request.Obstetrician;
using EduquayAPI.Models.PNDTObstetrician;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.PNDTObstetrician
{
    public class PNDTObstetricianData : IPNDTObstetricianData
    {
        private const string FetchSubjectsPNDTPending = "SPC_FetchSubjectsPNDTPending";
        private const string AddPNDTestData = "SPC_AddPNDTest";
        private const string FetchSubjectsPNDTNotCompleted = "SPC_FetchSubjectsPNDTNotCompleted";
        private const string FetchSubjectsPNDTCompleted = "SPC_FetchSubjectsPNDTCompleted";

        #region New Changes in PNDT Obstetrician
        private const string AddPNDT = "SPC_AddPNDT";

        #endregion

        public PNDTObstetricianData()
        {

        }

        public PNDTMsg AddPNDTest(AddPNDTestRequest aData)
        {
            string stProc = AddPNDTestData;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PrePNDTCounsellingId", aData.prePNDTCounsellingId),
                new SqlParameter("@ANWSubjectId", aData.anwsubjectId ?? aData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", aData.spouseSubjectId ?? aData.spouseSubjectId),
                new SqlParameter("@PNDTDateTime", aData.pndtDateTime ?? aData.pndtDateTime),
                new SqlParameter("@CounsellorId", aData.counsellorId),
                new SqlParameter("@ObstetricianId", aData.obstetricianId),
                new SqlParameter("@ClinicalHistory", aData.clinicalHistory ?? aData.clinicalHistory),
                new SqlParameter("@Examination", aData.examination ?? aData.examination),
                new SqlParameter("@ProcedureOfTestingId", aData.procedureOfTestingId),
                new SqlParameter("@OthersPOT", aData.othersProcedureofTesting ?? aData.othersProcedureofTesting),
                new SqlParameter("@PNDTComplecationsId", aData.pndtComplecationsId ?? aData.pndtComplecationsId),
                new SqlParameter("@OthersComplecations", aData.othersComplecations ?? aData.othersComplecations),
                new SqlParameter("@PNDTDiagnosisId", aData.pndtDiagnosisId),
                new SqlParameter("@PNDTResultId", aData.pndtResultId),
                new SqlParameter("@MotherVoided", aData.motherVoided ?? aData.motherVoided),
                new SqlParameter("@MotherVitalStable", aData.motherVitalStable ?? aData.motherVitalStable),
                new SqlParameter("@FoetalHeartRateDocumentScan", aData.foetalHeartRateDocumentScan ?? aData.foetalHeartRateDocumentScan),
                new SqlParameter("@PlanForPregnencyContinue", aData.planForPregnencyContinue ?? aData.planForPregnencyContinue),
                new SqlParameter("@IsCompletePNDT", aData.isCompletePNDT),
                new SqlParameter("@CreatedBy", aData.userId),
            };
            var schedulingData = UtilityDL.FillEntity<PNDTMsg>(stProc, pList);
            return schedulingData;
        }

        public PNDTMsg AddPNDTestNew(AddPNDTRequest aData)
        {
            string stProc = AddPNDT;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@PrePNDTCounsellingId", aData.prePNDTCounsellingId),
                new SqlParameter("@ANWSubjectId", aData.anwsubjectId ?? aData.anwsubjectId),
                new SqlParameter("@SpouseSubjectId", aData.spouseSubjectId ?? aData.spouseSubjectId),
                new SqlParameter("@PNDTDateTime", aData.pndtDateTime ?? aData.pndtDateTime),
                new SqlParameter("@CounsellorId", aData.counsellorId),
                new SqlParameter("@ObstetricianId", aData.obstetricianId),
                new SqlParameter("@ClinicalHistory", aData.clinicalHistory ?? aData.clinicalHistory),
                new SqlParameter("@Examination", aData.examination ?? aData.examination),
                new SqlParameter("@ProcedureOfTestingId", aData.procedureOfTestingId),
                new SqlParameter("@OthersPOT", aData.othersProcedureofTesting ?? aData.othersProcedureofTesting),
                new SqlParameter("@PNDTComplecationsId", aData.pndtComplecationsId ?? aData.pndtComplecationsId),
                new SqlParameter("@OthersComplecations", aData.othersComplecations ?? aData.othersComplecations),
                new SqlParameter("@MotherVoided", aData.motherVoided),
                new SqlParameter("@MotherVitalStable", aData.motherVitalStable),
                new SqlParameter("@FoetalHeartRateDocumentScan", aData.foetalHeartRateDocumentScan),
                new SqlParameter("@UserId", aData.userId),
                new SqlParameter("@PregnancyType", aData.pregnancyType),
                new SqlParameter("@SampleRefId", aData.sampleRefId ?? aData.sampleRefId),
                new SqlParameter("@FoetusName", aData.foetusName ?? aData.foetusName),
                new SqlParameter("@CVSSampleRefId", aData.cvsSampleRefId ?? aData.cvsSampleRefId),
                new SqlParameter("@PNDTLocationId", aData.pndtLocationId),
                new SqlParameter("@AssistedBy", aData.assistedBy ?? aData.assistedBy),
            };
            var pndtTest = UtilityDL.FillEntity<PNDTMsg>(stProc, pList);
            return pndtTest;
        }

        public PNDTCompletedSummary GetPNDTCompletedSummary()
        {
            string stProc = FetchSubjectsPNDTCompleted;
            var pList = new List<SqlParameter>();
            //{
            //    new SqlParameter("@MolecularLabId", molecularLabId),
            //};
            var allANWDetail = UtilityDL.FillData<PNDTCompletedANWDetail>(stProc, pList);
            var allFoetusDetail = UtilityDL.FillData<PNDTCompletedFoetusDetail>(stProc, pList);
            var allPNDTDetail = new PNDTCompletedSummary();
            allPNDTDetail.anwDetail = allANWDetail;
            allPNDTDetail.foetusDetail = allFoetusDetail;
            return allPNDTDetail;
        }

        public List<PNDTNotCompleted> GetPNDTNotCompleted(ObstetricianRequest oData)
        {
            string stProc = FetchSubjectsPNDTNotCompleted;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", oData.districtId),
                new SqlParameter("@CHCId", oData.chcId),
                new SqlParameter("@PHCId", oData.phcId),
                new SqlParameter("@ANMId", oData.anmId)
            };
            var notCompletedData = UtilityDL.FillData<PNDTNotCompleted>(stProc, pList);
            return notCompletedData;
        }

        public List<PNDTPending> GetPNDTPending(ObstetricianRequest oData)
        {
            string stProc = FetchSubjectsPNDTPending;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@DistrictId", oData.districtId),
                new SqlParameter("@CHCId", oData.chcId),
                new SqlParameter("@PHCId", oData.phcId),
                new SqlParameter("@ANMId", oData.anmId)
            };
            var pendingData = UtilityDL.FillData<PNDTPending>(stProc, pList);
            return pendingData;
        }
    }
}
