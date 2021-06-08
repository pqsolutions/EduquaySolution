using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MolLabResultProcess
{
    public class MLResultProcessData : IMLResultProcessData
    {

        private const string FetchSubjectsForMolecularBloodTest = "SPC_FetchSubjectsForMolecularBloodTest";
        private const string FetchSubjectsForMolecularBloodTestEdit = "SPC_FetchSubjectsForMolecularBloodTestEdit";
        private const string FetchSubjectsForMolecularBloodTestComplete = "SPC_FetchSubjectsForMolecularBloodTestComplete";
        private const string FetchSubjectsForMolecularSpecimenTest = "SPC_FetchSubjectsForMolecularSpecimenTest";
        private const string FetchSubjectsForMolecularSpecimenEditTest = "SPC_FetchSubjectsForMolecularSpecimenEditTest";
        private const string FetchSubjectsForMolecularSpecimenTestComplete = "SPC_FetchSubjectsForMolecularSpecimenTestComplete";
        private const string AddMolecularBloodTestResult = "SPC_AddMolecularBloodTestResult";
        private const string AddMolecularSpecimenTestResult = "SPC_AddMolecularSpecimenTestResult";

        private const string FetchMolecularLabBloodTestReports = "SPC_FetchMolecularLabBloodTestReports";
        private const string FetchMolecularLabSpecimenTestReports = "SPC_FetchMolecularLabSpecimenTestReports";

        public MLResultProcessData()
        {

        }

        public MolecularMsg AddBloodSamplesTestResult(AddBloodSampleTestRequest rData)
        {
            string stProc = AddMolecularBloodTestResult;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UniqueSubjectId", rData.uniqueSubjectId),
                new SqlParameter("@Barcode", rData.barcodeNo),
                new SqlParameter("@ZygosityId", rData.zygosityId),
                new SqlParameter("@Mutation1Id", rData.mutation1Id),
                new SqlParameter("@Mutation2Id", rData.mutation2Id),
                new SqlParameter("@Mutation3", rData.mutation3),
                new SqlParameter("@TestResult", rData.testResult),
                new SqlParameter("@IsDamaged", rData.sampleDamaged),
                new SqlParameter("@IsProcessed", rData.sampleProcessed),
                new SqlParameter("@IsComplete", rData.completeStatus),
                new SqlParameter("@ReasonForClose", rData.reasonForClose),
                new SqlParameter("@TestDate", rData.testDate),
                new SqlParameter("@UserId", rData.userId),
                new SqlParameter("@MolecularLabId", rData.molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillEntity<MolecularMsg>(stProc, pList);
            return allReceivedSubject;
        }

        public MolecularMsg AddSpecimenSamplesTestResult(AddSpecimenSampleTestRequest rData)
        {
            string stProc = AddMolecularSpecimenTestResult;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@UniqueSubjectId", rData.uniqueSubjectId),
                new SqlParameter("@PNDTFoetusId", rData.pndtFoetusId),
                new SqlParameter("@ZygosityId", rData.zygosityId),
                new SqlParameter("@Mutation1Id", rData.mutation1Id),
                new SqlParameter("@Mutation2Id", rData.mutation2Id),
                new SqlParameter("@Mutation3", rData.mutation3),
                new SqlParameter("@TestResult", rData.testResult),
                new SqlParameter("@IsDamaged", rData.sampleDamaged),
                new SqlParameter("@IsProcessed", rData.sampleProcessed),
                new SqlParameter("@IsComplete", rData.completeStatus),
                new SqlParameter("@ReasonForClose", rData.reasonForClose),
                new SqlParameter("@TestDate", rData.testDate),
                new SqlParameter("@UserId", rData.userId),
                new SqlParameter("@MolecularLabId", rData.molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillEntity<MolecularMsg>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularEditTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularSpecimenEditTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MLabSpecimenForTestStatus>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MLabSpecimenForTestStatus> RetriveSpecimenForMolecularTestComplete(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularSpecimenTestComplete;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MLabSpecimenForTestStatus>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MLabSpecimenForTest> RetriveSpecimenSubjectForMolecularTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularSpecimenTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MLabSpecimenForTest>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MolecularSubjectsForTest> RetriveSubjectForMolecularBloodTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularBloodTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MolecularSubjectsForTest>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestComplete(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularBloodTestComplete;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MolecularSubjectsForBloodTestStatus>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MolecularSubjectsForBloodTestStatus> RetriveSubjectForMolecularBloodTestEdit(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularBloodTestEdit;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MolecularSubjectsForBloodTestStatus>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MolecularLabBloodReport> RetriveSubjectForMolecularBloodTestReports(MolecularLabReportRequest rData)
        {
            string stProc = FetchMolecularLabBloodTestReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", rData.molecularLabId),
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@DistrictID", rData.districtId),
                new SqlParameter("@CHCID", rData.chcId),
            };
            var allReceivedSubject = UtilityDL.FillData<MolecularLabBloodReport>(stProc, pList);
            return allReceivedSubject;
        }

        public SpecimenReport RetriveSubjectForMolecularSpecimenTestReports(MolecularLabReportRequest rData)
        {
            string stProc = FetchMolecularLabSpecimenTestReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", rData.molecularLabId),
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@DistrictID", rData.districtId),
                new SqlParameter("@CHCID", rData.chcId),
            };
            var awDetail = UtilityDL.FillData<MolecularLabSpecimenReport>(stProc, pList);
            var foetusDetail = UtilityDL.FillData<MolecularLabFoetusResult>(stProc, pList);
            var report = new SpecimenReport();
            report.anwDetail = awDetail;
            report.foetusDetail = foetusDetail;
            return report;
        }
    }
}
