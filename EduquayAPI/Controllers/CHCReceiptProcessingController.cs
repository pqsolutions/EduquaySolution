using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.CHCReceiptProcessing;
using EduquayAPI.Contracts.V1.Response.CHCReceipt;
using EduquayAPI.Models.CHCReceipt;
using EduquayAPI.Services.CHCReceipt;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
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
        /// </summary>
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

        /// <summary>
        /// Used for add receipt  for processing 
        /// </summary>
        [HttpPost]
        [Route("AddReceivedShipments")]
        public async Task<IActionResult> AddMultipleSamples(AddCHCShipmentReceiptRequest chcSRRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Received shipments to add samples for verification  - {JsonConvert.SerializeObject(chcSRRequest)}");
            var rsResponse = await _chcReceiptService.AddReceivedShipment(chcSRRequest);

            return Ok(new CHCReceivedShipmentResponse
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
        [Route("RetrieveCBC/{testingCHCId}")]
        public CBCResponse GetCBC(int testingCHCId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Test CBC for received samples- {JsonConvert.SerializeObject(testingCHCId)}");
                var cbc = _chcReceiptService.RetrieveCBC(testingCHCId);
                return cbc.Count == 0 ? new CBCResponse { Status = "true", Message = "No sample found", CBCDetail = new List<CBCSSTest>() } : new CBCResponse { Status = "true", Message = string.Empty, CBCDetail = cbc };
            }
            catch (Exception e)
            {
                return new CBCResponse { Status = "false", Message = e.Message, CBCDetail = null };
            }
        }

        /// <summary>
        /// Used for add samples to CBC Test 
        /// </summary>
        [HttpPost]
        [Route("AddCBCTest")]
        public async Task<IActionResult> AddCBCTest(CBCTestAddRequest cbcRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"CBC test for multiple samples - {JsonConvert.SerializeObject(cbcRequest)}");
            var rsResponse = await _chcReceiptService.AddCBCTest(cbcRequest);

            return Ok(new CBCSSTAddResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for  SS Test 
        /// </summary>
        [HttpGet]
        [Route("RetrieveSST/{testingCHCId}")]
        public SSTResponse GetSST(int testingCHCId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Test SST for received samples- {JsonConvert.SerializeObject(testingCHCId)}");
                var sst = _chcReceiptService.RetrieveSST(testingCHCId);
                return sst.Count == 0 ? new SSTResponse { Status = "true", Message = "No sample found", SSTDetail = new List<CBCSSTest>() } : new SSTResponse { Status = "true", Message = string.Empty, SSTDetail = sst };
            }
            catch (Exception e)
            {
                return new SSTResponse { Status = "false", Message = e.Message, SSTDetail = null };
            }
        }

        /// <summary>
        /// Used for add samples to SS Test 
        /// </summary>
        [HttpPost]
        [Route("AddSSTest")]
        public async Task<IActionResult> AddSSTest(SSTestAddRequest ssRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"SS test for multiple samples - {JsonConvert.SerializeObject(ssRequest)}");
            var rsResponse = await _chcReceiptService.AddSSTest(ssRequest);

            return Ok(new CBCSSTAddResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for Pick and Pack 
        /// </summary>
        [HttpGet]
        [Route("RetrievePickandPack/{testingCHCId}")]
        public CHCCentralPickandPackResponse GetPickandPack(int testingCHCId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received positive samples for pick and pack- {JsonConvert.SerializeObject(testingCHCId)}");
                var pickpack = _chcReceiptService.RetrievePickandPack(testingCHCId);
                return pickpack.Count == 0 ? new CHCCentralPickandPackResponse { Status = "true", Message = "No sample found", PickandPack = new List<CHCCentralPickandPackSample>() } : new CHCCentralPickandPackResponse { Status = "true", Message = string.Empty, PickandPack = pickpack };
            }
            catch (Exception e)
            {
                return new CHCCentralPickandPackResponse { Status = "false", Message = e.Message, PickandPack = null };
            }
        }

        /// <summary>
        /// Used for add samples to shipment for Central Lab  
        /// </summary>
        [HttpPost]
        [Route("AddShipment")]
        public async Task<IActionResult> AddCHCShipment(AddCHCShipmentRequest csData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Adding CHC shipment data - {JsonConvert.SerializeObject(csData)}");
            var sampleShipment = await _chcReceiptService.AddCHCShipment (csData);
            return Ok(new CHCShipmentResponse
            {
                Status = sampleShipment.Status,
                Message = sampleShipment.Message,
                Shipment = sampleShipment.Shipment,
            });
        }

        /// <summary>
        /// Used for get shipment list of particular Testing CHC 
        [HttpGet]
        [Route("RetrieveShipmentLog/{testingCHCId}")]
        public async Task<IActionResult> GetCHCShipmentList(int testingCHCId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var shipmentLogResponse = await _chcReceiptService.RetrieveCHCShipmentLogs(testingCHCId);

            return Ok(new CHCShipmentLogsResponse
            {
                Status = shipmentLogResponse.Status,
                Message = shipmentLogResponse.Message,
                ShipmentLogs = shipmentLogResponse.ShipmentLogs,
            });
        }

        /// <summary>
        /// Used for get  reports for Central Lab result 
        /// </summary>
        [HttpPost]
        [Route("RetrieveCHCSampleStatusReports")]
        public CHCReportResponse GETCHCSampleStatusReports(CHCReportsRequest mrData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for chc test reports  - {JsonConvert.SerializeObject(mrData)}");
                var subjects = _chcReceiptService.RetriveCHCReports(mrData);
                return subjects.Count == 0 ? new CHCReportResponse { Status = "true", Message = "No subjects found", Subjects = new List<CHCSampleStatusReports>() }
                : new CHCReportResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                return new CHCReportResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get sample status in CHC  
        /// </summary>
        [HttpGet]
        [Route("RetrieveCHCSampleStatus")]
        public CHCSampleStatusResponse GetSampleStatus()
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var sampleStatus = _chcReceiptService.RetrieveSampleStatus();
                return sampleStatus.Count == 0 ? new CHCSampleStatusResponse { Status = "true", Message = "No subjects found", sampleStatus = new List<CHCSampleStatus>() }
                : new CHCSampleStatusResponse { Status = "true", Message = string.Empty, sampleStatus = sampleStatus };
            }
            catch (Exception e)
            {
                return new CHCSampleStatusResponse { Status = "false", Message = e.Message, sampleStatus = null };
            }
        }

    }
}