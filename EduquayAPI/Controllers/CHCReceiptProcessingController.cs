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
            _logger.LogDebug($"Request -  Retrieve shipment list receipt  for processing  - {JsonConvert.SerializeObject(testingCHCId)}");
            var chcReceiptResponse = await _chcReceiptService.RetrieveCHCReceipts(testingCHCId);
            _logger.LogInformation($"Retrieve shipment list receipt  for processing {chcReceiptResponse}");
            _logger.LogDebug($"Respone - Retrieve shipment list receipt  for processing - {JsonConvert.SerializeObject(chcReceiptResponse)}");
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
            _logger.LogDebug($"Request - Add Received shipments to add samples for verification  - {JsonConvert.SerializeObject(chcSRRequest)}");
            var rsResponse = await _chcReceiptService.AddReceivedShipment(chcSRRequest);
            _logger.LogInformation($" Add Received shipments to add samples for verification{rsResponse}");
            _logger.LogDebug($"Respone -Add Received shipments to add samples for verification- {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new CHCReceivedShipmentResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for  CBC Test Old
        /// </summary>
        [HttpGet]
        [Route("RetrieveCBC/{testingCHCId}")]
        public CBCResponse GetCBC(int testingCHCId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Request - Retrieve received samples for CBC Test - {JsonConvert.SerializeObject(testingCHCId)}");
                var cbc = _chcReceiptService.RetrieveCBC(testingCHCId);
                _logger.LogInformation($"Retrieve received samples for CBC Test{cbc}");
                _logger.LogDebug($"Respone - Retrieve received samples for CBC Test - {JsonConvert.SerializeObject(cbc)}");
                return cbc.Count == 0 ? new CBCResponse { Status = "true", Message = "No sample found", CBCDetail = new List<CBCSSTest>() } : new CBCResponse { Status = "true", Message = string.Empty, CBCDetail = cbc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in Retrieve received samples for CBC Test -  {e.StackTrace}");
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
            _logger.LogDebug($"Request - Add CBC test for multiple samples - {JsonConvert.SerializeObject(cbcRequest)}");
            var rsResponse = await _chcReceiptService.AddCBCTest(cbcRequest);
            _logger.LogInformation($"Add CBC test for multiple samples - {rsResponse}");
            _logger.LogDebug($"Respone - Add CBC test for multiple samples  - {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new CBCSSTAddResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for  CBC Test New
        /// </summary>
        [HttpGet]
        [Route("RetrieveCBCTest/{testingCHCId}")]
        public CBCTestResponse GetCBCTest(int testingCHCId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Request - Retrieve received samples for CBC Test- {JsonConvert.SerializeObject(testingCHCId)}");
                var cbc = _chcReceiptService.RetrieveCBCTest(testingCHCId);
                _logger.LogInformation($" Retrieve received samples for CBC Test - {cbc}");
                _logger.LogDebug($"Respone -  Retrieve received samples for CBC Test  - {JsonConvert.SerializeObject(cbc)}");
                return cbc.Count == 0 ? new CBCTestResponse { Status = "true", Message = "No sample found", CBCDetail = new List<CBCTest>() } 
                : new CBCTestResponse { Status = "true", Message = string.Empty, CBCDetail = cbc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in Retrieve received samples for CBC Test -  {e.StackTrace}");
                return new CBCTestResponse { Status = "false", Message = e.Message, CBCDetail = null };
            }
        }

        /// <summary>
        /// Used for add results to samples for CBC Test 
        /// </summary>
        [HttpPost]
        [Route("AddCBCTestResults")]
        public async Task<IActionResult> AddCBC(AddCBCTestResultRequest cbcData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Add CBC test for individual sample - {JsonConvert.SerializeObject(cbcData)}");
            var rsResponse = await _chcReceiptService.AddCBC(cbcData);
            _logger.LogInformation($"Add CBC test for individual sample - {rsResponse}");
            _logger.LogDebug($"Respone -  Add CBC test for individual sample  - {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new AddCBCResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
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
                _logger.LogDebug($"Request - received samples for SST Test- {JsonConvert.SerializeObject(testingCHCId)}");
                var sst = _chcReceiptService.RetrieveSST(testingCHCId);
                _logger.LogInformation($" Retrieve received samples for SST Test - {sst}");
                _logger.LogDebug($"Respone -  Retrieve received samples for SST Test  - {JsonConvert.SerializeObject(sst)}");
                return sst.Count == 0 ? new SSTResponse { Status = "true", Message = "No sample found", SSTDetail = new List<CBCSSTest>() } 
                : new SSTResponse { Status = "true", Message = string.Empty, SSTDetail = sst };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in Retrieve received samples for SST Test -  {e.StackTrace}");
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
            _logger.LogDebug($"Request - Add SST test for multiple samples - {JsonConvert.SerializeObject(ssRequest)}");
            var rsResponse = await _chcReceiptService.AddSSTest(ssRequest);
            _logger.LogInformation($"Add SST test for multiple samples - {rsResponse}");
            _logger.LogDebug($"Respone -  Add SST test for multiple samples  - {JsonConvert.SerializeObject(rsResponse)}");
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
                _logger.LogDebug($"Request - Received positive samples for pick and pack- {JsonConvert.SerializeObject(testingCHCId)}");
                var pickpack = _chcReceiptService.RetrievePickandPack(testingCHCId);
                _logger.LogInformation($"Received positive samples for pick and pack - {pickpack}");
                _logger.LogDebug($"Respone - Received positive samples for pick and pack - {JsonConvert.SerializeObject(pickpack)}");
                return pickpack.Count == 0 ? new CHCCentralPickandPackResponse { Status = "true", Message = "No sample found", PickandPack = new List<CHCCentralPickandPackSample>() } 
                : new CHCCentralPickandPackResponse { Status = "true", Message = string.Empty, PickandPack = pickpack };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in Received positive samples for pick and pack -  {e.StackTrace}");
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
            _logger.LogDebug($"Request - Adding CHC shipment data - {JsonConvert.SerializeObject(csData)}");
            var sampleShipment = await _chcReceiptService.AddCHCShipment (csData);
            _logger.LogInformation($"Adding CHC shipment data - {sampleShipment}");
            _logger.LogDebug($"Respone - Adding CHC shipment data - {JsonConvert.SerializeObject(sampleShipment)}");
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
            _logger.LogDebug($"Request - Retrieve shipment list of particular Testing CHC   - {JsonConvert.SerializeObject(testingCHCId)}");
            var shipmentLogResponse = await _chcReceiptService.RetrieveCHCShipmentLogs(testingCHCId);
            _logger.LogInformation($"Retrieve shipment list of particular Testing CHC  - {shipmentLogResponse}");
            _logger.LogDebug($"Respone - Retrieve shipment list of particular Testing CHC  - {JsonConvert.SerializeObject(shipmentLogResponse)}");
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
                _logger.LogDebug($"Request - Retrieve subject for chc test reports  - {JsonConvert.SerializeObject(mrData)}");
                var subjects = _chcReceiptService.RetriveCHCReports(mrData);
                _logger.LogInformation($"Retrieve subject for chc test reports  - {subjects}");
                _logger.LogDebug($"Respone - Retrieve subject for chc test reports  - {JsonConvert.SerializeObject(subjects)}");
                return subjects.Count == 0 ? new CHCReportResponse { Status = "true", Message = "No subjects found", Subjects = new List<CHCSampleStatusReports>() }
                : new CHCReportResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in Retrieve subject for chc test reports -  {e.StackTrace}");
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
                _logger.LogInformation($" Fetch sample status in chc Lab  {sampleStatus}");
                _logger.LogDebug($"Response - Fetch sample status in chc Lab   - {JsonConvert.SerializeObject(sampleStatus)}");
                return sampleStatus.Count == 0 ? new CHCSampleStatusResponse { Status = "true", Message = "No subjects found", sampleStatus = new List<CHCSampleStatus>() }
                : new CHCSampleStatusResponse { Status = "true", Message = string.Empty, sampleStatus = sampleStatus };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve sample status in chc Lab  - {e.StackTrace}");
                return new CHCSampleStatusResponse { Status = "false", Message = e.Message, sampleStatus = null };
            }
        }

        /// <summary>
        /// Used to fetch subjects detail for chc receipt reports
        /// </summary>
        [HttpPost]
        [Route("CHCReceiptReportsDetail")]
        public async Task<IActionResult> RetrieveCHCReceiptsReports(CHCSampleReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve subject detail for chc receipt report- {JsonConvert.SerializeObject(rData)}");
            var chcReports = await _chcReceiptService.RetriveCHCReciptReportsDetail(rData);
            _logger.LogInformation($"Fetch Subjects for chc receipt reports {chcReports}");
            return Ok(new CHCReciptReportResponse
            {
                status = chcReports.status,
                message = chcReports.message,
                data = chcReports.data,
            });
        }

    }
}