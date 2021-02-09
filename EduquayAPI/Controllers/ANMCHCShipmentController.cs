using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Services.ANMCHCShipment;
using EduquayAPI.Contracts.V1.Response.ANMCHCShipment;
using EduquayAPI.Contracts.V1.Request.ANMCHCShipment;
using EduquayAPI.Models.ANMCHCShipment;
using EduquayAPI.Contracts.V1.Response;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class ANMCHCShipmentController : ControllerBase
    {
        private readonly IANMCHCShipmentService _anmchcShipmentService;
        private readonly ILogger<ANMCHCShipmentController> _logger;
        public ANMCHCShipmentController(IANMCHCShipmentService anmchcShipmentService, ILogger<ANMCHCShipmentController> logger)
        {
            _anmchcShipmentService = anmchcShipmentService;
            _logger = logger;
        }


        /// <summary>
        /// Used for add samples to shipment for ANM user 
        /// </summary>
        [HttpPost]
        [Route("AddANMShipment")]
        public async Task<IActionResult> AddShipment(AddShipmentANMCHCRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Adding ANM shipment data - {JsonConvert.SerializeObject(asData)}");
            var sampleShipment = await _anmchcShipmentService.AddANMCHCShipment(asData);
            _logger.LogInformation($"add samples to shipment for ANM user {sampleShipment}");
            _logger.LogDebug($"Response - Adding ANM shipment data - {JsonConvert.SerializeObject(sampleShipment)}");
            return Ok(new AddShipmentResponse
            {
                Status = sampleShipment.Status,
                Message = sampleShipment.Message,
                Shipment = sampleShipment.Shipment,
            });
        }

        /// <summary>
        /// Used for get shipment list of particular ANM user 
        [HttpPost]
        [Route("RetrieveANMShipmentLog")]
        public async Task<IActionResult> GetShipmentList(ANMCHCShipmentLogRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(asData)}");
            var shipmentLogResponse = await _anmchcShipmentService.RetrieveShipmentLogs(asData);
            _logger.LogInformation($"get shipment list of particular ANM user {shipmentLogResponse}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(shipmentLogResponse)}");

            return Ok(new ANMCHCShipmentLogsResponse
            {
                Status = shipmentLogResponse.Status,
                Message = shipmentLogResponse.Message,
                ShipmentLogs = shipmentLogResponse.ShipmentLogs,
            });
        }

        /// <summary>
        /// Used for add samples to shipment for CHC  
        /// </summary>
        [HttpPost]
        [Route("AddCHCShipment")]
        public async Task<IActionResult> AddCHCShipment(AddShipmentCHCCHCRequest csData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Adding CHC shipment data - {JsonConvert.SerializeObject(csData)}");
            var sampleShipment = await _anmchcShipmentService.AddCHCCHCShipment(csData);
            _logger.LogInformation($"add samples to shipment for CHC {sampleShipment}");
            _logger.LogDebug($"Response - Adding CHC shipment data - {JsonConvert.SerializeObject(sampleShipment)}");
            return Ok(new AddShipmentResponse
            {
                Status = sampleShipment.Status,
                Message = sampleShipment.Message,
                Shipment = sampleShipment.Shipment,
            });
        }

        /// <summary>
        /// Used for get shipment list of particular CHC 
        [HttpPost]
        [Route("RetrieveCHCShipmentLog")]
        public async Task<IActionResult> GetCHCShipmentList(ANMCHCShipmentLogRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(asData)}");
            var shipmentLogResponse = await _anmchcShipmentService.RetrieveCHCShipmentLogs(asData);
            _logger.LogInformation($"get shipment list of particular CHC {shipmentLogResponse}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(shipmentLogResponse)}");
            return Ok(new CHCCHCShipmentLogsResponse
            {
                Status = shipmentLogResponse.Status,
                Message = shipmentLogResponse.Message,
                ShipmentLogs = shipmentLogResponse.ShipmentLogs,
            });
        }

    }
}