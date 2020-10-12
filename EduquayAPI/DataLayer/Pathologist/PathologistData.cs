using EduquayAPI.Contracts.V1.Request.Pathologist;
using EduquayAPI.Models;
using EduquayAPI.Models.Pathologist;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.Pathologist
{
    public class PathologistData : IPathologistData
    {
        private const string FetchPathoDiognosticSubjectsList = "SPC_FetchPathoDiognosticSubjectsList";
        private const string FetchAllHPLCResult = "SPC_FetchAllHPLCResult";
        private const string AddHPLCDiagnosisResults = "SPC_AddHPLCDiagnosisResult";
        private const string FetchPathoEditDiognosisSubjectsList = "SPC_FetchPathoEditDiognosisSubjectsList";
        private const string AddHPLCDiagnosisResultByAutomatic = "SPC_AddHPLCDiagnosisResultByAutomatic";
        private const string FetchPathologistSampleStatus = "SPC_FetchPathologistSampleStatus";


        public PathologistData()
        {

        }

        public string AddHPLCDiagnosisResult(AddHPLCDiagnosisResultRequest aData)
        {
            try
            {
                var stProc = AddHPLCDiagnosisResults;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", aData.uniqueSubjectId ?? aData.uniqueSubjectId),
                    new SqlParameter("@CentralLabId", aData.centralLabId),
                    new SqlParameter("@BarcodeNo", aData.barcodeNo ?? aData.barcodeNo),
                    new SqlParameter("@HPLCTestResultId", aData.hplcTestResultId),
                    new SqlParameter("@ClinicalDiagnosisId", aData.clinicalDiagnosisId ?? aData.clinicalDiagnosisId),
                    new SqlParameter("@HPLCResultMasterId", aData.hplcResultMasterId ?? aData.hplcResultMasterId),
                    new SqlParameter("@IsNormal", aData.isNormal),
                    new SqlParameter("@DiagnosisSummary", aData.diagnosisSummary ?? aData.diagnosisSummary),
                    new SqlParameter("@IsConsultSeniorPathologist", aData.isConsultSeniorPathologist),
                    new SqlParameter("@SeniorPathologistName", aData.seniorPathologistName  ?? aData.seniorPathologistName),
                    new SqlParameter("@SeniorPathologistRemarks", aData.seniorPathologistRemarks  ?? aData.seniorPathologistRemarks),
                    new SqlParameter("@CreatedBy", aData.userId ),
                    new SqlParameter("@IsDiagnosisComplete", aData.isDiagnosisComplete),
                    new SqlParameter("@OthersResult", aData.othersResult.ToCheckNull()),

                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return $"HPLC diagnosis result updated successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AutomaticHPLCDiagnosisUpdate(int centralLabId)
        {
            try
            {
                var stProc = AddHPLCDiagnosisResultByAutomatic;
                var pList = new List<SqlParameter>()
                {
                     new SqlParameter("@CentralLabId", centralLabId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<HPLCDiagnosisDetails> EditHPLCDiagnosisDetail(int centralLabId)
        {
            string stProc = FetchPathoEditDiognosisSubjectsList;
            var pList = new List<SqlParameter>() { new SqlParameter("@CentralLabId", centralLabId) };
            var allSampleData = UtilityDL.FillData<HPLCDiagnosisDetails>(stProc, pList);
            return allSampleData;
        }

        public List<HPLCResult> HPLCResult()
        {
            string stProc = FetchAllHPLCResult;
            var pList = new List<SqlParameter>();
            var hplcResult = UtilityDL.FillData<HPLCResult>(stProc, pList);
            return hplcResult;
        }

        public List<HPLCTestDetails> HPLCResultDetail(int centralLabId)
        {
            string stProc = FetchPathoDiognosticSubjectsList;
            var pList = new List<SqlParameter>() { new SqlParameter("@CentralLabId", centralLabId) };
            var allSampleData = UtilityDL.FillData<HPLCTestDetails>(stProc, pList);
            return allSampleData;
        }

        public List<PathologistSampleStatus> RetrieveSampleStatus()
        {
            string stProc = FetchPathologistSampleStatus;
            var pList = new List<SqlParameter>();

            var allSampleStatus = UtilityDL.FillData<PathologistSampleStatus>(stProc, pList);
            return allSampleStatus;
        }
    }
}
