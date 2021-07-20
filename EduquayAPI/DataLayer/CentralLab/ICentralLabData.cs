using EduquayAPI.Contracts.V1.Request.CentralLab;
using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.DataLayer.CentralLab
{
    public interface ICentralLabData
    {
        CentralLabReceipts RetrieveCentralLabReceipts(int centralLabId);
        void AddReceivedShipment(AddCentralShipmentRequest csData);
        List<HPLCTest> RetrieveHPLC(int centralLabId);
        List<HPLCTestSamples> RetrieveSubjectForHPLCTest(int centralLabId);
        void AddHPLCTest(AddHPLCTestRequest hplcData);
        List<CentralLabPickandPack> RetrievePickandPack(int centralLabId);
        List<CentralLabShipmentId> AddCentralLabShipment(AddCentralLabShipmentRequest csData);
        CentralLabShipments RetrieveCentralLabShipmentLog(int centralLabId);
        List<CentralLabReports> RetriveCentralLabReports(CentralLabReportRequest mrData);
        List<CentralLabSampleStatus> RetrieveSampleStatus();
        HPLCResultMsg AddHPLCTestResult(AddHPLCTestResultRequest hplcData);
        HPLCResultMsg UpdateHPLCTestResult(UpdateStagingRequest hplcData);
        HPLCResultMsg UpdateProcessedHPLCTestResult(UpdateProcessedResultRequest hplcData);

        #region Report
        List<CentralLabReportdetails> RetrieveSampleRecpReport(CLReportRequest rData);
        List<CentralLabReportdetails> RetrieveTimeoutDamagedReport(CLReportRequest rData);
        List<CentralLabReportdetails> RetrieveTestPendingReport(CLReportRequest rData);
        List<CentralLabReportdetails> RetrieveAbnormalReport(CLReportRequest rData);
        List<CentralLabReportdetails> RetrieveNormalReport(CLReportRequest rData);
        List<CentralLabReportdetails> RetrieveShipmentStatusReport(CLReportRequest rData);
        #endregion
    }

    public interface ICentralLabDataFactory
    {
        ICentralLabData Create();
    }
    public class CentralLabDataFactory : ICentralLabDataFactory
    {
        public ICentralLabData Create()
        {
            return new CentralLabData();
        }
    }
}
