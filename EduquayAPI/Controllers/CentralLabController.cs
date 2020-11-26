using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        /// Used to fetch sample  for  HPLC Test  Old
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
                return hplc.Count == 0 ? new HPLCResponse { Status = "true", Message = "No sample found", HPLCDetail = new List<HPLCTest>() }
                : new HPLCResponse  { Status = "true", Message = string.Empty, HPLCDetail = hplc };
            }
            catch (Exception e)
            {
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
            _logger.LogDebug($"HPLC test for multiple samples - {JsonConvert.SerializeObject(hplcRequest)}");
            var rsResponse = await _centralLabService.AddHPLCTest(hplcRequest);

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
                _logger.LogDebug($"Test HPLC for received samples- {JsonConvert.SerializeObject(centralLabId)}");
                var hplc = _centralLabService.RetrieveSubjectForHPLCTest(centralLabId);
                return hplc.Count == 0 ? new HPLCTestResponse { Status = "true", Message = "No sample found", HPLCDetail = new List<HPLCTestSamples>() }
                : new HPLCTestResponse { Status = "true", Message = string.Empty, HPLCDetail = hplc };
            }
            catch (Exception e)
            {
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
            _logger.LogDebug($"HPLC test for particular samples - {JsonConvert.SerializeObject(hplcData)}");
            var rsResponse = await _centralLabService.AddHPLCTestResult(hplcData);

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
            _logger.LogDebug($"Update HPLC test for particular samples - {JsonConvert.SerializeObject(hplcData)}");
            var rsResponse = await _centralLabService.UpdateHPLCTestResult(hplcData);

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
                _logger.LogDebug($"Received hplc positive samples for pick and pack- {JsonConvert.SerializeObject(centralLabId)}");
                var pickpack = _centralLabService.RetrievePickandPack(centralLabId);
                return pickpack.Count == 0 ? new CentralLabPickPackResponse { Status = "true", Message = "No sample found", PickandPack = new List<CentralLabPickandPack>() }
                : new CentralLabPickPackResponse { Status = "true", Message = string.Empty, PickandPack = pickpack };
            }
            catch (Exception e)
            {
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
            _logger.LogDebug($"Adding central lab shipment data - {JsonConvert.SerializeObject(csData)}");
            var sampleShipment = await _centralLabService.AddCentralLabShipment(csData);
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
            var shipmentLogResponse = await _centralLabService.RetrieveCentralLabShipmentLog(centralLabId);

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
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Received subject for central lab test reports  - {JsonConvert.SerializeObject(mrData)}");
                var subjects = _centralLabService.RetriveCentralLabReports(mrData);
                return subjects.Count == 0 ? new CentralLabReportResponse { Status = "true", Message = "No subjects found", Subjects = new List<CentralLabReports>() }
                : new CentralLabReportResponse { Status = "true", Message = string.Empty, Subjects = subjects };
            }
            catch (Exception e)
            {
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
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                var sampleStatus = _centralLabService.RetrieveSampleStatus();
                return sampleStatus.Count == 0 ? new CentralLabSampleStatusResponse { Status = "true", Message = "No subjects found", sampleStatus = new List<CentralLabSampleStatus>() }
                : new CentralLabSampleStatusResponse { Status = "true", Message = string.Empty, sampleStatus = sampleStatus };
            }
            catch (Exception e)
            {
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
            _logger.LogDebug($"Update processed HPLC test results for particular samples - {JsonConvert.SerializeObject(hplcData)}");
            var rsResponse = await _centralLabService.UpdateProcessedHPLCTestResult(hplcData);

            return Ok(new AddHPLCResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
            });
        }

        /// <summary>
        /// Download HPLC Graph  
        /// </summary>

        [HttpPost]
        [Route("DownloadHPLCGraph")]
        public async Task<IActionResult> Download(string file)
        {
            var uploads = "";
            var hplcGraphLocation = _config.GetSection("Graph").GetSection("HPLCGraphFolder").Value;

            if (file.ToUpper() == "" || file.ToUpper() == null)
            {
                return BadRequest();
            }
            else
            {
                uploads = Path.Combine(_hostingEnvironment.WebRootPath + hplcGraphLocation);
                var filePath = Path.Combine(uploads, file);
                if (!System.IO.File.Exists(filePath))
                    return NotFound();

                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    await stream.CopyToAsync(memory);
                }
                memory.Position = 0;
                return File(memory, GetContentType(filePath), file);
            }
        }

        private string GetContentType(string path)
        {
            var provider = new FileExtensionContentTypeProvider();
            string contentType;
            if (!provider.TryGetContentType(path, out contentType))
            {
                contentType = "application/octet-stream";
            }
            return contentType;
        }
    }
}