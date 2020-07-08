using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
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


    }
}
