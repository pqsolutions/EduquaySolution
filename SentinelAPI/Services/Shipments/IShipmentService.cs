using SentinelAPI.Contracts.V1.Response.Shipments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SentinelAPI.Services.Shipments
{
    public interface IShipmentService
    {
        Task<ShipmentLogResponse> RetrieveShipmentLogs(int userId);
    }
}
