using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Models;
using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCReceipt
{
    public class CHCReceiptData : ICHCReceiptData 
    {
        private const string FetchShipmentReceiptInCHC = "SPC_FetchShipmentReceiptInCHC";
        private const string AddCHCReceipt = "SPC_AddCHCReceipt";
        private const string FetchDetailforSSTest = "SPC_FetchDetailforSSTest";
        private const string FetchDetailforCBCTest = "SPC_FetchDetailforCBCTest";
        private const string AddCBCTests = "SPC_AddCBCTest";
        private const string AddSSTests = "SPC_AddSSTest";
        private const string FetchSamplesCHCCentralPickPack = "SPC_FetchSamplesCHCCentralPickPack";
        private const string AddCHCShipments = "SPC_AddCHCCentralShipments";
        private const string FetchCHCCentralShipmentLog = "SPC_FetchCHCCentralShipmentLog";
        private const string FetchCHCSampleStatus = "SPC_FetchCHCSampleStatus";
        private const string FetchCHCStatusReports = "SPC_FetchCHCStatusReports";

        private const string FetchReceivedSubjectforCBCTest = "SPC_FetchReceivedSubjectforCBCTest";
        private const string AddCBCTestResults = "SPC_AddCBCTestResults";

        #region Reports
        private const string CHCSampleRecpReport = "SPC_CHCSampleRecpReport";
        private const string CHCRecTimeoutDamagedReport = "SPC_CHCRecTimeoutDamagedReport";
        private const string CHCSampleCBCPendingReport = "SPC_CHCSampleCBCPendingReport";
        private const string CHCSampleSSTPendingReport = "SPC_CHCSampleSSTPendingReport";
        private const string CHCSampleTestPositiveReport = "SPC_CHCSampleTestPositiveReport";
        private const string CHCSampleTestNegativeReport = "SPC_CHCSampleTestNegativeReport";
        private const string CHCSampleShipmentStatusReport = "SPC_CHCSampleShipmentStatusReport";
        #endregion


        public CHCReceiptData()
        {

        }
        public void AddReceivedShipment(AddReceivedShipmentRequest rsData)
        {
            try
            {
                var stProc = AddCHCReceipt;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@ShipmentId", rsData.shipmentId ?? rsData.shipmentId),
                    new SqlParameter("@ReceivedDate", rsData.receivedDate ?? rsData.receivedDate),
                    new SqlParameter("@ProcessingDateTime", rsData.proceesingDateTime ?? rsData.proceesingDateTime),
                    new SqlParameter("@ILRInDateTime", rsData.ilrInDateTime ?? rsData.ilrInDateTime),
                    new SqlParameter("@ILROutDateTime", rsData.ilrOutDateTime ?? rsData.ilrOutDateTime),
                    new SqlParameter("@SampleDamaged", rsData.sampleDamaged),
                    new SqlParameter("@SampleTimeout", rsData.sampleTimeout),
                    new SqlParameter("@BarcodeDamaged", rsData.barcodeDamaged),
                    new SqlParameter("@IsAccept", rsData.isAccept),
                    new SqlParameter("@Barcode", rsData.barcodeNo ?? rsData.barcodeNo),
                    new SqlParameter("@UpdatedBy", rsData.updatedBy),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CBCSSTest> RetrieveCBC(int testingCHCId)
        {
            string stProc = FetchDetailforCBCTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCId", testingCHCId),
            };
            var allCBC = UtilityDL.FillData<CBCSSTest>(stProc, pList);
            return allCBC;
        }

        public List<CBCSSTest> RetrieveSST(int testingCHCId)
        {
            string stProc = FetchDetailforSSTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCId", testingCHCId),
            };
            var allSST = UtilityDL.FillData<CBCSSTest>(stProc, pList);
            return allSST;
        }

        public CHCReceipts RetrieveCHCReceipts(int testingCHCId)
        {
            string stProc = FetchShipmentReceiptInCHC;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCId", testingCHCId),
            };
            var allCHCReceiptLog = UtilityDL.FillData<CHCReceiptLog>(stProc, pList);
            var allReceiptDetail = UtilityDL.FillData<CHCReceiptDetail>(stProc, pList);
            var chcReceipt = new CHCReceipts();
            chcReceipt.ReceiptLog = allCHCReceiptLog;
            chcReceipt.ReceiptDetail = allReceiptDetail;
            return chcReceipt;
        }
        public void AddCBCTest(AddCBCTestRequest cbcData)
        {
            try
            {
                var stProc = AddCBCTests;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", cbcData.subjectId ?? cbcData.subjectId),
                    new SqlParameter("@Barcode", cbcData.barcodeNo ?? cbcData.barcodeNo),
                    new SqlParameter("@TestingCHCId",Convert.ToInt32(cbcData.testingCHCId)),
                    new SqlParameter("@MCV",Convert.ToDecimal(cbcData.mcv)),
                    new SqlParameter("@RDW",Convert.ToDecimal(cbcData.rdw)),
                    new SqlParameter("@TestCompleteOn", cbcData.testCompleteOn ?? cbcData.testCompleteOn),
                    new SqlParameter("@SampleDateTime", cbcData.sampleDateTime ?? cbcData.sampleDateTime),
                    new SqlParameter("@CreatedBy", Convert.ToInt32(cbcData.createdBy)),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AddSSTest(AddSSTestRequest ssData)
        {
            try
            {
                var stProc = AddSSTests;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", ssData.subjectId ?? ssData.subjectId),
                    new SqlParameter("@Barcode", ssData.barcodeNo ?? ssData.barcodeNo),
                    new SqlParameter("@TestingCHCId",Convert.ToInt32(ssData.testingCHCId)),
                    new SqlParameter("@IsPositive",ssData.isPositive),
                    new SqlParameter("@CreatedBy", Convert.ToInt32(ssData.createdBy)),
                };
                UtilityDL.ExecuteNonQuery(stProc, pList);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CHCCentralPickandPackSample> RetrievePickandPack(int testingCHCId)
        {
            string stProc = FetchSamplesCHCCentralPickPack;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@CHCID", testingCHCId),
            };
            var allData = UtilityDL.FillData<CHCCentralPickandPackSample>(stProc, pList);
            return allData;
        }

        public List<CHCShipmentID> AddCHCShipment(AddCHCShipmentRequest csData)
        {
            try
            {
                string stProc = AddCHCShipments;
                var pList = new List<SqlParameter>
                {
                    new SqlParameter("@BarcodeNo", csData.barcodeNo ?? csData.barcodeNo),
                    new SqlParameter("@LabTechnicianName", csData.labTechnicianName ?? csData.labTechnicianName),
                    new SqlParameter("@CHCUserID", csData.chcUserId),
                    new SqlParameter("@TestingCHCID", csData.testingCHCId),
                    new SqlParameter("@ReceivingCentralLabId", csData.receivingCentralLabId),
                    new SqlParameter("@LogicsProviderID", csData.logisticsProviderId),
                    new SqlParameter("@DeliveryExecutiveName", csData.deliveryExecutiveName ?? csData.deliveryExecutiveName),
                    new SqlParameter("@ExecutiveContactNo", csData.executiveContactNo ?? csData.executiveContactNo),
                    new SqlParameter("@DateofShipment", csData.dateOfShipment ?? csData.dateOfShipment),
                    new SqlParameter("@TimeofShipment", csData.timeOfShipment ?? csData.timeOfShipment),
                    new SqlParameter("@Createdby", csData.createdBy),
                    new SqlParameter("@Source",csData.source ?? csData.source),
                };
                var allData = UtilityDL.FillData<CHCShipmentID>(stProc, pList);
                return allData;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public CHCShipments RetrieveCHCShipmentLog(int testingCHCId)
        {
            string stProc = FetchCHCCentralShipmentLog;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCID", testingCHCId ),
            };
            var allCHCShipmentLogs = UtilityDL.FillData<CHCShipmentLogs>(stProc, pList);
            var allCHCShipmentSubjects = UtilityDL.FillData<CHCShipmentLogsDetail>(stProc, pList);
            var shiplogDetail = new CHCShipments();
            shiplogDetail.ShipmentLog = allCHCShipmentLogs;
            shiplogDetail.ShipmentSubjectDetail = allCHCShipmentSubjects;
            return shiplogDetail;
        }

        public List<CHCSampleStatus> RetrieveSampleStatus()
        {
            string stProc = FetchCHCSampleStatus;
            var pList = new List<SqlParameter>();

            var allSampleStatus = UtilityDL.FillData<CHCSampleStatus>(stProc, pList);
            return allSampleStatus;
        }

        public List<CHCSampleStatusReports> RetriveCHCReports(CHCReportsRequest mrData)
        {
            string stProc = FetchCHCStatusReports;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@SampleStatus", mrData.sampleStatus),
                new SqlParameter("@TestingCHCId", mrData.testingCHCId),
                new SqlParameter("@CHCID", mrData.chcId),
                new SqlParameter("@PHCID", mrData.phcId),
                new SqlParameter("@ANMID", mrData.anmId),
                new SqlParameter("@FromDate", mrData.fromDate.ToCheckNull()),
                new SqlParameter("@ToDate", mrData.toDate.ToCheckNull()),
            };
            var allSubjects = UtilityDL.FillData<CHCSampleStatusReports>(stProc, pList);
            return allSubjects;
        }

        public List<CBCTest> RetrieveCBCTest(int testingCHCId)
        {
            string stProc = FetchReceivedSubjectforCBCTest;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@TestingCHCId", testingCHCId),
            };
            var allCBC = UtilityDL.FillData<CBCTest>(stProc, pList);
            return allCBC;
        }

        public CBCResultMsg AddCBCTestResult(AddCBCTestResultRequest cbcData)
        {
             try
            {
                var stProc = AddCBCTestResults;
                var pList = new List<SqlParameter>()
                {
                    new SqlParameter("@UniqueSubjectId", cbcData.subjectId ?? cbcData.subjectId),
                    new SqlParameter("@ConfirmStatus", Convert.ToInt32(cbcData.confirmStatus)),
                    new SqlParameter("@TestingCHCId",Convert.ToInt32(cbcData.testingCHCId)),
                    new SqlParameter("@TestedId", Convert.ToInt32(cbcData.testedId)),
                    new SqlParameter("@CreatedBy", Convert.ToInt32(cbcData.userId)),
                };
               var msg= UtilityDL.FillEntity<CBCResultMsg>(stProc, pList);
                return msg;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public List<CHCReceiptReportDetails> RetrieveSampleRecpReport(CHCSampleReportRequest rData)
        {
            string stProc = CHCSampleRecpReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<CHCReceiptReportDetails>(stProc, pList);
            return allData;
        }

        public List<CHCReceiptReportDetails> RetrieveTimeoutDamagedReport(CHCSampleReportRequest rData)
        {
            string stProc = CHCRecTimeoutDamagedReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<CHCReceiptReportDetails>(stProc, pList);
            return allData;
        }

        public List<CHCReceiptReportDetails> RetrieveCBCPendingReport(CHCSampleReportRequest rData)
        {
            string stProc = CHCSampleCBCPendingReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<CHCReceiptReportDetails>(stProc, pList);
            return allData;
        }

        public List<CHCReceiptReportDetails> RetrieveSSTPendingReport(CHCSampleReportRequest rData)
        {
            string stProc = CHCSampleSSTPendingReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<CHCReceiptReportDetails>(stProc, pList);
            return allData;
        }

        public List<CHCReceiptReportDetails> RetrievePositiveReport(CHCSampleReportRequest rData)
        {
            string stProc = CHCSampleTestPositiveReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<CHCReceiptReportDetails>(stProc, pList);
            return allData;
        }

        public List<CHCReceiptReportDetails> RetrieveNegativeReport(CHCSampleReportRequest rData)
        {
            string stProc = CHCSampleTestNegativeReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<CHCReceiptReportDetails>(stProc, pList);
            return allData;
        }

        public List<CHCReceiptReportDetails> RetrieveShipmentStatusReport(CHCSampleReportRequest rData)
        {
            string stProc = CHCSampleShipmentStatusReport;
            var pList = new List<SqlParameter>()
            {
                new SqlParameter("@FromDate", rData.fromDate),
                new SqlParameter("@ToDate", rData.toDate),
                new SqlParameter("@CHCID", rData.chcId),
                new SqlParameter("@PHCID", rData.phcId),
                new SqlParameter("@ANMID", rData.anmId),
                new SqlParameter("@Status", rData.status)
            };
            var allData = UtilityDL.FillData<CHCReceiptReportDetails>(stProc, pList);
            return allData;
        }
    }
}
