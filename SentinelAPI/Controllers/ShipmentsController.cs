using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SentinelAPI.Contracts.V1.Response.Shipments;
using SentinelAPI.Services.Shipments;

namespace SentinelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentService _shipmentService;
        private readonly ILogger<ShipmentsController> _logger;
        public ShipmentsController(IShipmentService shipmentService, ILogger<ShipmentsController> logger)
        {
            _shipmentService = shipmentService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get shipment list of particular Hospital 
        [HttpPost]
        [Route("RetrieveShipmentLog")]
        public async Task<IActionResult> GetShipmentList(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var shipmentLogResponse = await _shipmentService.RetrieveShipmentLogs(userId);

            return Ok(new ShipmentLogResponse
            {
                Status = shipmentLogResponse.Status,
                Message = shipmentLogResponse.Message,
                ShipmentLogs = shipmentLogResponse.ShipmentLogs,
            });
        }
    }
}