using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
using EduquayAPI.Services.CHCReceipt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CHCReceiptProcessingController : ControllerBase
    {
        private readonly ICHCReceiptService _chcReceiptService;
        private readonly ILogger<CHCReceiptProcessingController> _logger;
        public CHCReceiptProcessingController(ICHCReceiptService chcReceiptService, ILogger<CHCReceiptProcessingController> logger)
        {
            _chcReceiptService = chcReceiptService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get shipment list receipt  for processing 
        [HttpGet]
        [Route("RetrieveCHCReceipt/{testingCHCId}")]
        public async Task<IActionResult> GetShipmentList(int testingCHCId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var chcReceiptResponse = await _chcReceiptService.RetrieveCHCReceipts(testingCHCId);

            return Ok(new CHCReceiptResponse
            {
                Status = chcReceiptResponse.Status,
                Message = chcReceiptResponse.Message,
                CHCReceipts = chcReceiptResponse.CHCReceipts,
            });
        }

        [HttpPost]
        [Route("AddReceivedShipments")]
        public async Task<IActionResult> AddMultipleSamples(AddCHCShipmentReceiptRequest chcSRRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"collect multiple samples in Mobile App- {JsonConvert.SerializeObject(chcSRRequest)}");
            var rsResponse = await _chcReceiptService.AddReceivedShipment(chcSRRequest);

            return Ok(new CHCReceivedShipmentResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }
    }
}