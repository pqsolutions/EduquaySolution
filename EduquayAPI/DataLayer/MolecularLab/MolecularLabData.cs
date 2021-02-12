using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Models;
using EduquayAPI.Models.MolecularLab;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.MolecularLab
{
    public class MolecularLabData : IMolecularLabData
    {
        private const string FetchShipmentReceiptInMolecularLab = "SPC_FetchShipmentReceiptInMolecularLab";
        private const string AddMolecularLabReceipts = "SPC_AddMolecularLabReceipt";
        private const string FetchSubjectsForMolecularTest = "SPC_FetchSubjectsForMolecularTest";
        private const string AddMolecularTestResult = "SPC_AddMolecularTestResult";
        private const string FetchMolecularTestReports = "SPC_FetchMolecularTestReports";
        private const string FetchMolecularSampleStatus = "SPC_FetchMolecularSampleStatus";

        private const string FetchPNDTShipmentReceiptInMolLab = "SPC_FetchPNDTShipmentReceiptInMolLab";


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
                    new SqlParameter("@UniqueSubjectId", mrData.uniqueSubjectId ?? mrData.uniqueSubjectId),
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
            var allMolecularLabReceiptLog = UtilityDL.FillData<MolecularLabReceiptsLog>(stProc, pList);
            var allReceiptDetail = UtilityDL.FillData<MolecularLabReceiptDetail>(stProc, pList);
            var molecularLabReceipt = new MolecularLabReceipts();
            molecularLabReceipt.ReceiptLog = allMolecularLabReceiptLog;
            molecularLabReceipt.ReceiptDetail = allReceiptDetail;
            return molecularLabReceipt;
        }

        public MolPNDTReceipts RetrieveMolPNDTReceipts(int molecularLabId)
        {
            string stProc = FetchPNDTShipmentReceiptInMolLab;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allMolecularLabReceiptLog = UtilityDL.FillData<MolPNDTReceiptsLog>(stProc, pList);
            var allReceiptDetail = UtilityDL.FillData<MolPNDTReceiptDetail>(stProc, pList);
            var molecularLabReceipt = new MolPNDTReceipts();
            molecularLabReceipt.ReceiptLog = allMolecularLabReceiptLog;
            molecularLabReceipt.ReceiptDetail = allReceiptDetail;
            return molecularLabReceipt;
        }

        public List<MolecularSampleStatus> RetrieveSampleStatus()
        {
            string stProc = FetchMolecularSampleStatus;
            var pList = new List<SqlParameter>();
           
            var allSampleStatus = UtilityDL.FillData<MolecularSampleStatus>(stProc, pList);
            return allSampleStatus;
        }

        public List<MolecularReports> RetriveMolecularReports(MolecularReportRequest mrData)
        {
            string stProc = FetchMolecularTestReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SampleStatus", mrData.sampleStatus),
                new SqlParameter("@MolecularLabId", mrData.molecularLabId),
                new SqlParameter("@DistrictId", mrData.districtId),
                new SqlParameter("@CHCID", mrData.chcId),
                new SqlParameter("@PHCID", mrData.phcId),
                new SqlParameter("@ANMID", mrData.anmId),
                new SqlParameter("@FromDate", mrData.fromDate.ToCheckNull()),
                new SqlParameter("@ToDate", mrData.toDate.ToCheckNull()),


            };
            var allReceivedSubject = UtilityDL.FillData<MolecularReports>(stProc, pList);
            return allReceivedSubject;
        }

        public List<MolecularSubjectsForTest> RetriveSubjectForMolecularTest(int molecularLabId)
        {
            string stProc = FetchSubjectsForMolecularTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@MolecularLabId", molecularLabId),
            };
            var allReceivedSubject = UtilityDL.FillData<MolecularSubjectsForTest>(stProc, pList);
            return allReceivedSubject;
        }
    }
}
