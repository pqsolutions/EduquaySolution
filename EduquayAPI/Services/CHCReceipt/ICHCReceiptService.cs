using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
using EduquayAPI.Models.CHCReceipt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.CHCReceipt
{
    public interface ICHCReceiptService
    {
        Task<CHCReceiptResponse> RetrieveCHCReceipts(int testingCHCId);
        Task<CHCReceivedShipmentResponse> AddReceivedShipment(AddCHCShipmentReceiptRequest chcSRRequest);
        Task<CBCSSTAddResponse> AddCBCTest(CBCTestAddRequest cbcRequest);
        Task<CBCSSTAddResponse> AddSSTest(SSTestAddRequest ssRequest);
        List<CBCSSTest> RetrieveCBC(int testingCHCId);
        List<CBCSSTest> RetrieveSST(int testingCHCId);
        List<CHCCentralPickandPackSample> RetrievePickandPack(int testingCHCId);
        Task<CHCShipmentResponse> AddCHCShipment(AddCHCShipmentRequest csData);
        Task<CHCShipmentLogsResponse> RetrieveCHCShipmentLogs(int testingCHCId);
    }
}
