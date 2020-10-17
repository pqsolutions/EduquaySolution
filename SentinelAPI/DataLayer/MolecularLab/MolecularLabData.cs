using SentinelAPI.Contracts.V1.Request.MolecularLab;
using SentinelAPI.Models;
using SentinelAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.DataLayer.MolecularLab
{
    public class MolecularLabData : IMolecularLabData
    {
        private const string FetchShipmentReceiptInMolecularLab = "SPC_FetchShipmentReceiptInMolecularLab";
        private const string AddMolecularLabReceipts = "SPC_AddMolecularLabReceipt";
        private const string FetchSubjectsForMolecularTest = "SPC_FetchSubjectsForMolecularTest";
        private const string AddMolecularTestResult = "SPC_AddMolecularTestResult";
        private const string FetchrMolecularTestResultsDetail = "SPC_FetchrMolecularTestResultsDetail";
        private const string FetchMolecularTestReports = "SPC_FetchMolecularTestReports";
        public MolecularLabData()
        {

        }

        public string AddMolecularResult(AddMolecularResultRequest mrData)
        {
            try
            {
                var stProc = AddMolecularTestResult;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@BabySubjectId", mrData.babySubjectId ?? mrData.babySubjectId),
                    new SqlParameter("@Barcode", mrData.barcodeNo ?? mrData.barcodeNo),
                    new SqlParameter("@DiagnosisId", mrData.diagnosisId),
                    new SqlParameter("@ResultId", mrData.resultId),
                    new SqlParameter("@UpdatedBy", mrData.userId),
                    new SqlParameter("@IsProcessed",mrData.processSample),
                    new SqlParameter("@Remarks",mrData.remarks.ToCheckNull()),

                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
                return $"Molecular test result updated successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddReceivedShipment(AddMolecularReceiptRequest mrData)
        {
            try
            {
                var stProc = AddMolecularLabReceipts;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ShipmentId", mrData.shipmentId ?? mrData.shipmentId),
                    new SqlParameter("@ReceivedDate", mrData.receivedDate ?? mrData.receivedDate),
                    new SqlParameter("@SampleDamaged", mrData.sampleDamaged),
                    new SqlParameter("@BarcodeDamaged", mrData.barcodeDamaged),
                    new SqlParameter("@IsAccept", mrData.isAccept),
                    new SqlParameter("@Barcode", mrData.barcodeNo ?? mrData.barcodeNo),
                    new SqlParameter("@UpdatedBy", mrData.userId),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public MolecularLabReceipts RetrieveMolecularLabReceipts(int molecularLabId)
        {
            string stProc = FetchShipmentReceiptInMolecularLab;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allMolecularLabReceiptLog = UtilityDL.FillData<MolecularReceiptsLog>(stProc, pList);
            var allReceiptDetail = UtilityDL.FillData<MolecularLabReceiptDetail>(stProc, pList);
            var molecularLabReceipt = new MolecularLabReceipts();
            molecularLabReceipt.ReceiptLog = allMolecularLabReceiptLog;
            molecularLabReceipt.ReceiptDetail = allReceiptDetail;
            return molecularLabReceipt;
        }

        public List<MolecularReportsDetail> RetriveMolecularReports(FetchMolecularReportsRequest mrData)
        {
            string stProc = FetchMolecularTestReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SampleStatus", mrData.sampleStatus),
                new SqlParameter("@MolecularLabId", mrData.molecularLabId),
                new SqlParameter("@HospitalId", mrData.hospitalId),
                new SqlParameter("@FromDate", mrData.fromDate.ToCheckNull()),
                new SqlParameter("@ToDate", mrData.toDate.ToCheckNull()),

            };
            var allSubjects = UtilityDL.FillData<MolecularReportsDetail>(stProc, pList);
            return allSubjects;
        }

        public List<MolecularResultsDetail> RetriveMolecularTestResultsDetail(int molecularLabId)
        {
            string stProc = FetchrMolecularTestResultsDetail;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId)
            };
            var allSubjects = UtilityDL.FillData<MolecularResultsDetail>(stProc, pList);
            return allSubjects;
        }

        public List<SubjectDetailsForTest> RetriveSubjectForMolecularTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<SubjectDetailsForTest>(stProc, pList);
            return allReceivedSubject;
        }
    }
}
