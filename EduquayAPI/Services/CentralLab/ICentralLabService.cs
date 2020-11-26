using EduquayAPI.Contracts.V1.Request.CentralLab;
using EduquayAPI.Contracts.V1.Response.CentralLab;
using EduquayAPI.Models.CentralLab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CentralLab
{
    public interface ICentralLabService
    {
        Task<CentralLabReceiptResponse> RetrieveCentralLabReceipts(int CentralLabId);
        Task<CentralLabReceivedShipmentResponse> AddReceivedShipment(AddCentralLabShipmentReceiptRequest clRequest);
        List<HPLCTest> RetrieveHPLC(int CentralLabId);
        Task<HPLCAddResponse> AddHPLCTest(HPLCTestAddRequest hplcRequest);
        List<CentralLabPickandPack> RetrievePickandPack(int centralLabId);
        Task<CentralLabShipmentResponse> AddCentralLabShipment(AddCentralLabShipmentRequest csData);
        Task<CentralLabShipmentLogsResponse> RetrieveCentralLabShipmentLog(int centralLabId);
        List<CentralLabReports> RetriveCentralLabReports(CentralLabReportRequest mrData);
        List<CentralLabSampleStatus> RetrieveSampleStatus();
        List<HPLCTestSamples> RetrieveSubjectForHPLCTest(int centralLabId);
        Task<AddHPLCResponse> AddHPLCTestResult(AddHPLCTestResultRequest hplcData);
        Task<AddHPLCResponse> UpdateHPLCTestResult(UpdateStagingRequest hplcData);
        Task<AddHPLCResponse> UpdateProcessedHPLCTestResult(UpdateProcessedResultRequest hplcData);
    }
}
