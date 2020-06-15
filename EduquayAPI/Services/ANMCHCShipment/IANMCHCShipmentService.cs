using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
using EduquayAPI.Models.ANMCHCShipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Services.ANMCHCShipment
{
    public interface IANMCHCShipmentService
    {
        List<ANMCHCShipmentID> ANMCHCGenerateShipmentId(ShipmentIdGenerateRequest sgData);
        string AddANMCHCShipment(AddANMCHCShipmentRequest asData);
        List<ANMCHCShipmentLogs> RetrieveShipmentLog(ANMCHCShipmentLogRequest asData);
        List<ANMCHCShipmentDetail> RetrieveShipmentDetail(ANMCHCShipmentDetailRequest asData);
    }
}
