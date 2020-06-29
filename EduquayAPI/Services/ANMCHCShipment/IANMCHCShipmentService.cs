using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
using EduquayAPI.Contracts.V1.Response.ANMCHCShipment;
using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMCHCShipment
{
    public interface IANMCHCShipmentService
    {
       // List<ANMCHCShipmentID> AddANMCHCShipment(AddShipmentANMCHCRequest asData);

        Task<AddShipmentResponse> AddANMCHCShipment(AddShipmentANMCHCRequest asData);

        Task<ANMCHCShipmentLogsResponse> RetrieveShipmentLogs(ANMCHCShipmentLogRequest asData);
    }
}
