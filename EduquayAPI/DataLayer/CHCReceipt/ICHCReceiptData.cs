using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CHCReceipt
{
    public interface ICHCReceiptData
    {
        CHCReceipts RetrieveCHCReceipts(int testingCHCId);
        void AddReceivedShipment(AddReceivedShipmentRequest rsData);
        List<CBCSSTest> RetrieveCBC(int testingCHCId);
        List<CBCSSTest> RetrieveSST(int testingCHCId);
        void AddCBCTest(AddCBCTestRequest cbcData);
        void AddSSTest(AddSSTestRequest ssData);
        List<CHCCentralPickandPackSample> RetrievePickandPack(int testingCHCId);
        List<CHCShipmentID> AddCHCShipment(AddCHCShipmentRequest csData);
        CHCShipments RetrieveCHCShipmentLog(int testingCHCId);
        List<CHCSampleStatusReports> RetriveCHCReports(CHCReportsRequest mrData);
        List<CHCSampleStatus> RetrieveSampleStatus();
        List<CBCTest> RetrieveCBCTest(int testingCHCId);
        CBCResultMsg AddCBCTestResult(AddCBCTestResultRequest cbcData);

        #region Report
        List<CHCReceiptReportDetails> RetrieveSampleRecpReport(CHCSampleReportRequest rData);
        List<CHCReceiptReportDetails> RetrieveTimeoutDamagedReport(CHCSampleReportRequest rData);
        List<CHCReceiptReportDetails> RetrieveCBCPendingReport(CHCSampleReportRequest rData);
        List<CHCReceiptReportDetails> RetrieveSSTPendingReport(CHCSampleReportRequest rData);
        List<CHCReceiptReportDetails> RetrievePositiveReport(CHCSampleReportRequest rData);
        List<CHCReceiptReportDetails> RetrieveNegativeReport(CHCSampleReportRequest rData);
        List<CHCReceiptReportDetails> RetrieveShipmentStatusReport(CHCSampleReportRequest rData);
        #endregion
    }
    public interface ICHCReceiptDataFactory
    {
        ICHCReceiptData Create();
    }
    public class CHCReceiptDataFactory : ICHCReceiptDataFactory
    {
        public ICHCReceiptData Create()
        {
            return new CHCReceiptData();
        }
    }
}
