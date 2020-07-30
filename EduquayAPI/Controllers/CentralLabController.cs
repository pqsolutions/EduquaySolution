using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.CentralLab;
using EduquayAPI.Contracts.V1.Response.CentralLab;
using EduquayAPI.Models.CentralLab;
using EduquayAPI.Services.CentralLab;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class CentralLabController : ControllerBase
    {
        private readonly ICentralLabService _centralLabService;
        private readonly ILogger<CentralLabController> _logger;
        public CentralLabController(ICentralLabService centralLabService, ILogger<CentralLabController> logger)
        {
            _centralLabService = centralLabService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get shipment list receipt  for processing 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCentralLabReceipt/{centralLabId}")]
        public async Task<IActionResult> GetShipmentList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var centralLabReceiptResponse = await _centralLabService.RetrieveCentralLabReceipts(centralLabId);

            return Ok(new CentralLabReceiptResponse
            {
                Status = centralLabReceiptResponse.Status,
                Message = centralLabReceiptResponse.Message,
                CentralLabReceipts = centralLabReceiptResponse.CentralLabReceipts,
            });
        }

        /// <summary>
        /// Used for add receipt  for processing 
        /// </summary>
        [HttpPost]
        [Route("AddReceivedShipments")]
        public async Task<IActionResult> AddMultipleSamples(AddCentralLabShipmentReceiptRequest clRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Received shipments to add samples for verification  - {JsonConvert.SerializeObject(clRequest)}");
            var rsResponse = await _centralLabService.AddReceivedShipment(clRequest);

            return Ok(new CentralLabReceivedShipmentResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for  CBC Test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveHPLC/{centralLabId}")]
        public HPLCResponse GetHPLC(int centralLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Test HPLC for received samples- {JsonConvert.SerializeObject(centralLabId)}");
                var hplc = _centralLabService.RetrieveHPLC(centralLabId);
                return hplc.Count == 0 ? new HPLCResponse { Status = "true", Message = "No sample found", HPLCDetail = new List<HPLCTest>() } : new HPLCResponse  { Status = "true", Message = string.Empty, HPLCDetail = hplc };
            }
            catch (Exception e)
            {
                return new HPLCResponse { Status = "false", Message = e.Message, HPLCDetail = null };
            }
        }

        /// <summary>
        /// Used for add samples to HPLC Test 
        /// </summary>
        [HttpPost]
        [Route("AddHPLCTest")]
        public async Task<IActionResult> AddCBCTest(HPLCTestAddRequest hplcRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"HPLC test for multiple samples - {JsonConvert.SerializeObject(hplcRequest)}");
            var rsResponse = await _centralLabService.AddHPLCTest(hplcRequest);

            return Ok(new HPLCAddResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }


    }
}