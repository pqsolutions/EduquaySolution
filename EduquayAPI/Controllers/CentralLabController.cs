using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.CentralLab;
using EduquayAPI.Contracts.V1.Response.CentralLab;
using EduquayAPI.Models.CentralLab;
using EduquayAPI.Services.CentralLab;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;
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
        private readonly IConfiguration _config;
        public readonly IHostingEnvironment _hostingEnvironment;
        public CentralLabController(ICentralLabService centralLabService, ILogger<CentralLabController> logger, IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            _centralLabService = centralLabService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _config = config;
        }

        /// <summary>
        /// Used for get shipment list receipt  for processing 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCentralLabReceipt/{centralLabId}")]
        public async Task<IActionResult> GetShipmentList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Fetch shipment list receipt  for processing- {JsonConvert.SerializeObject(centralLabId)}");
            var centralLabReceiptResponse = await _centralLabService.RetrieveCentralLabReceipts(centralLabId);
            _logger.LogInformation($"Fetch shipment list receipt  for processing {centralLabReceiptResponse}");
            _logger.LogDebug($"Response - Fetch shipment list receipt  for processing- {JsonConvert.SerializeObject(centralLabReceiptResponse)}");
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
            _logger.LogDebug($"Request - Received shipments to add samples for verification  - {JsonConvert.SerializeObject(clRequest)}");
            var rsResponse = await _centralLabService.AddReceivedShipment(clRequest);
            _logger.LogInformation($"Received shipments to add samples for verification {rsResponse}");
            _logger.LogDebug($"Response - Received shipments to add samples for verification - {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new CentralLabReceivedShipmentResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for  HPLC Test  Old
        /// </summary>
        [HttpGet]
        [Route("RetrieveHPLC/{centralLabId}")]
        public HPLCResponse GetHPLC(int centralLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Request - Test HPLC for received samples- {JsonConvert.SerializeObject(centralLabId)}");
                var hplc = _centralLabService.RetrieveHPLC(centralLabId);
                _logger.LogInformation($"Test HPLC for received samples {hplc}");
                _logger.LogDebug($"Response - Test HPLC for received samples - {JsonConvert.SerializeObject(hplc)}");
                return hplc.Count == 0 ? new HPLCResponse { Status = "true", Message = "No sample found", HPLCDetail = new List<HPLCTest>() }
                : new HPLCResponse { Status = "true", Message = string.Empty, HPLCDetail = hplc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to Test HPLC for received samples - {e.StackTrace}");
                return new HPLCResponse { Status = "false", Message = e.Message, HPLCDetail = null };
            }
        }

        /// <summary>
        /// Used for add samples to HPLC Test  OLD
        /// </summary>
        [HttpPost]
        [Route("AddHPLCTest")]
        public async Task<IActionResult> AddHPLCTest(HPLCTestAddRequest hplcRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Add HPLC test for multiple samples - {JsonConvert.SerializeObject(hplcRequest)}");
            var rsResponse = await _centralLabService.AddHPLCTest(hplcRequest);
            _logger.LogInformation($"HPLC test for multiple samples {rsResponse}");
            _logger.LogDebug($"Response - Add Test HPLC test for multiple samples - {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new HPLCAddResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }

        /// <summary>
        /// Used to fetch sample  for  HPLC Test  New
        /// </summary>
        [HttpGet]
        [Route("RetrieveHPLCTest/{centralLabId}")]
        public HPLCTestResponse GetHPLCTest(int centralLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Request - Test HPLC for received samples- {JsonConvert.SerializeObject(centralLabId)}");
                var hplc = _centralLabService.RetrieveSubjectForHPLCTest(centralLabId);
                _logger.LogInformation($"Fetch sample  for  HPLC Test {hplc}");
                _logger.LogDebug($"Response - fetch sample  for  HPLC Test - {JsonConvert.SerializeObject(hplc)}");
                return hplc.Count == 0 ? new HPLCTestResponse { Status = "true", Message = "No sample found", HPLCDetail = new List<HPLCTestSamples>() }
                : new HPLCTestResponse { Status = "true", Message = string.Empty, HPLCDetail = hplc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to fetch sample  for  HPLC Test  - {e.StackTrace}");
                return new HPLCTestResponse { Status = "false", Message = e.Message, HPLCDetail = null };
            }
        }


        /// <summary>
        /// Used for add samples to HPLC Test  New
        /// </summary>
        [HttpPost]
        [Route("AddHPLCTestResult")]
        public async Task<IActionResult> AddHPLCTestResult(AddHPLCTestResultRequest hplcData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Add HPLC test for particular samples - {JsonConvert.SerializeObject(hplcData)}");
            var rsResponse = await _centralLabService.AddHPLCTestResult(hplcData);
            _logger.LogInformation($"Add HPLC test for particular samples {rsResponse}");
            _logger.LogDebug($"Response - Add HPLC test for particular samples - {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new AddHPLCResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Used for update samples to HPLC Test  New
        /// </summary>
        [HttpPost]
        [Route("UpdateHPLCTestResult")]
        public async Task<IActionResult> UpdateHPLCTestResult(UpdateStagingRequest hplcData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Update HPLC test for particular samples - {JsonConvert.SerializeObject(hplcData)}");
            var rsResponse = await _centralLabService.UpdateHPLCTestResult(hplcData);
            _logger.LogInformation($" Update HPLC test for particular samples {rsResponse}");
            _logger.LogDebug($"Response -  Update HPLC test for particular samples - {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new AddHPLCResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Used to fetch sample  for Pick and Pack 
        /// </summary>
        [HttpGet]
        [Route("RetrievePickandPack/{centralLabId}")]
        public CentralLabPickPackResponse GetPickandPack(int centralLabId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Request - Received hplc positive samples for pick and pack- {JsonConvert.SerializeObject(centralLabId)}");
                var pickpack = _centralLabService.RetrievePickandPack(centralLabId);
                _logger.LogInformation($" Received hplc positive samples for pick and pack {pickpack}");
                _logger.LogDebug($"Response - Received hplc positive samples for pick and pack - {JsonConvert.SerializeObject(pickpack)}");
                return pickpack.Count == 0 ? new CentralLabPickPackResponse { Status = "true", Message = "No sample found", PickandPack = new List<CentralLabPickandPack>() }
                : new CentralLabPickPackResponse { Status = "true", Message = string.Empty, PickandPack = pickpack };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve hplc positive samples for pick and pack - {e.StackTrace}");
                return new CentralLabPickPackResponse { Status = "false", Message = e.Message, PickandPack = null };
            }
        }

        /// <summary>
        /// Used for add samples to shipment for Central Lab to molecular lab  
        /// </summary>
        [HttpPost]
        [Route("AddShipment")]
        public async Task<IActionResult> AddCHCShipment(AddCentralLabShipmentRequest csData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Adding central lab shipment data - {JsonConvert.SerializeObject(csData)}");
            var sampleShipment = await _centralLabService.AddCentralLabShipment(csData);
            _logger.LogInformation($"Adding central lab shipment data  {sampleShipment}");
            _logger.LogDebug($"Response - Adding central lab shipment data  - {JsonConvert.SerializeObject(sampleShipment)}");
            return Ok(new CentralLabShipmentResponse
            {
                Status = sampleShipment.Status,
                Message = sampleShipment.Message,
                Shipment = sampleShipment.Shipment,
            });
        }

        /// <summary>
        /// Used for get shipment list of particular Central Lab 
        [HttpGet]
        [Route("RetrieveShipmentLog/{centralLabId}")]
        public async Task<IActionResult> GetCHCShipmentList(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - retrieve shipment list of particular Central Lab  - {JsonConvert.SerializeObject(centralLabId)}");
            var shipmentLogResponse = await _centralLabService.RetrieveCentralLabShipmentLog(centralLabId);
            _logger.LogInformation($" Retrieve shipment list of particular Central Lab  {shipmentLogResponse}");
            _logger.LogDebug($"Response - Retrieve shipment list of particular Central Lab  - {JsonConvert.SerializeObject(shipmentLogResponse)}");
            return Ok(new CentralLabShipmentLogsResponse
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
        [Route("RetrieveCentralLabReports")]
        public CentralLabReportResponse GetCentralLabReports(CentralLabReportRequest mrData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                _logger.LogDebug($"Request - Received subject for central lab test reports  - {JsonConvert.SerializeObject(mrData)}");
                var subjects = _centralLabService.RetriveCentralLabReports(mrData);
                _logger.LogInformation($" Received subject for central lab test reports  {subjects}");
                _logger.LogDebug($"Response - Received subject for central lab test reports   - {JsonConvert.SerializeObject(subjects)}");
                return subjects.Count == 0 ? new CentralLabReportResponse { Status = "true", Message = "No subjects found", Subjects = new List<CentralLabReports>() }
                : new CentralLabReportResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve subject for central lab test reports  - {e.StackTrace}");
                return new CentralLabReportResponse { Status = "false", Message = e.Message, Subjects = null };
            }
        }

        /// <summary>
        /// Used for get sample status in Central Lab 
        /// </summary>
        [HttpGet]
        [Route("RetrieveCentralLabSampleStatus")]
        public CentralLabSampleStatusResponse GetSampleStatus()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var sampleStatus = _centralLabService.RetrieveSampleStatus();
                _logger.LogInformation($" Fetch sample status in Central Lab  {sampleStatus}");
                _logger.LogDebug($"Response - Fetch sample status in Central Lab   - {JsonConvert.SerializeObject(sampleStatus)}");
                return sampleStatus.Count == 0 ? new CentralLabSampleStatusResponse { Status = "true", Message = "No subjects found", sampleStatus = new List<CentralLabSampleStatus>() }
                : new CentralLabSampleStatusResponse { Status = "true", Message = string.Empty, sampleStatus = sampleStatus };
            }
            catch (Exception e)
            {
                _logger.LogError($"Failed to retrieve sample status in Central Lab  - {e.StackTrace}");
                return new CentralLabSampleStatusResponse { Status = "false", Message = e.Message, sampleStatus = null };
            }
        }

        /// <summary>
        /// Used for update samples to HPLC Processed Test Results  
        /// </summary>
        [HttpPost]
        [Route("UpdateProcessedHPLCTestResult")]
        public async Task<IActionResult> UpdateProcessedHPLCTestResult(UpdateProcessedResultRequest hplcData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Update processed HPLC test results for particular samples - {JsonConvert.SerializeObject(hplcData)}");
            var rsResponse = await _centralLabService.UpdateProcessedHPLCTestResult(hplcData);
            _logger.LogInformation($" Update processed HPLC test results for particular samples  {rsResponse}");
            _logger.LogDebug($"Response - Update processed HPLC test results for particular samples   - {JsonConvert.SerializeObject(rsResponse)}");
            return Ok(new AddHPLCResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Download HPLC Graph  
        /// </summary>
        /// 
        [HttpGet]
        [Route("DownloadHPLCGraph")]
        public async Task<ActionResult> Download([FromQuery]string fileName)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Download the HPLC graph - {JsonConvert.SerializeObject(fileName)}");
            if (fileName.ToUpper() == "" || fileName.ToUpper() == null)
            {
                return BadRequest();
            }
            else
            {
                _logger.LogDebug($"Response  - Download the HPLC graph - {JsonConvert.SerializeObject(fileName)}");
                var hplcGraphLocation = _config.GetSection("Graph").GetSection("HPLCGraphFolder").Value;
                IFileProvider provider = new PhysicalFileProvider(_hostingEnvironment.WebRootPath + hplcGraphLocation);
                IFileInfo fileInfo = provider.GetFileInfo(fileName);
                var readStream = fileInfo.CreateReadStream();
                var mimeType = "application/pdf";
                return File(readStream, mimeType, fileName);
            }
        }

        /// <summary>
        /// Used to fetch subjects detail for central lab receipt reports
        /// </summary>
        [HttpPost]
        [Route("CLReceiptReportsDetail")]
        public async Task<IActionResult> RetrieveCLReceiptsReports(CLReportRequest rData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Retrieve subject detail for cl receipt report- {JsonConvert.SerializeObject(rData)}");
            var clReports = await _centralLabService.RetriveCLReciptReportsDetail(rData);
            _logger.LogInformation($"Fetch Subjects for cl receipt reports {clReports}");
            return Ok(new CLReportResponse
            {
                status = clReports.status,
                message = clReports.message,
                data = clReports.data,
            });
        }
    }
}