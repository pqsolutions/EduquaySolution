using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.Support;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Support;
using EduquayAPI.Models.Support;
using EduquayAPI.Services.Support;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class SupportController : ControllerBase
    {
        private readonly ISupportService _supportService;
        private readonly ILogger<SupportController> _logger;
        public SupportController(ISupportService supportService, ILogger<SupportController> logger)
        {
            _supportService = supportService;
            _logger = logger;
        }

        /// <summary>
        /// Used for fetch the error Barcodes detail for error correction
        /// </summary>
        [HttpGet]
        [Route("RetrieveErrorBarcodeDetails")]
        public ErrorBarcodeDetailResponse FetchErrorBarcodeDetail()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorBarcodes = _supportService.FetchErrorBarcodeDetails();

                _logger.LogInformation($"Received Error barcode data {errorBarcodes}");
                return errorBarcodes.Count == 0 ?
                    new ErrorBarcodeDetailResponse { status = "true", message = "No record found", data = new List<BarcodeErrorDetail>() }
                    : new ErrorBarcodeDetailResponse { status = "true", message = string.Empty, data = errorBarcodes };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error barcode data {e.StackTrace}");
                return new ErrorBarcodeDetailResponse { status = "false", message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used for fetch the Barcode detail for error correction
        /// </summary>

        [HttpGet]
        [Route("RetrieveBarcodeDetailsForErrorCorrection/{barcodeNo}")]
        public ErrorBarcodeDetailResponse FetchBarcodeDetailForCorrection(string barcodeNo)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorBarcodes = _supportService.FetchBarcodeDetailsForErrorCorrection(barcodeNo);

                _logger.LogInformation($"Received error barcode data {errorBarcodes}");
                return errorBarcodes.Count == 0 ?
                    new ErrorBarcodeDetailResponse { status = "true", message = "No record found", data = new List<BarcodeErrorDetail>() }
                    : new ErrorBarcodeDetailResponse { status = "true", message = string.Empty, data = errorBarcodes };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving error barcode data {e.StackTrace}");
                return new ErrorBarcodeDetailResponse { status = "false", message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for Check barcode exist
        /// </summary>
        [HttpPost]
        [Route("CheckBarcodeExist/{barcodeNo}")]
        public async Task<IActionResult> Checkbarcode(string barcodeNo)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var sample = await _supportService.CheckbarcodeExist(barcodeNo);
            return Ok(new CheckBarcodeResponse
            {
                status = sample.status,
                message = sample.message,
                barcodeExist = sample.barcodeExist,
                barcodeValid = sample.barcodeValid,
                data = sample.data
            });
        }

        /// <summary>
        /// Used for Update the Error Barcode into Revised Barcode
        /// </summary>
        [HttpPost]
        [Route("UpdateBarcodeError")]
        public async Task<IActionResult> UpdateErrorBarcode(UpdateBarcodeRequest bData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating the Error Barcode - {JsonConvert.SerializeObject(bData)}");
            var subjectSample = await _supportService.UpdateErrorBarcode(bData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }

        /// <summary>
        /// Used for fetch the  detail for RCH ID error correction
        /// </summary>

        [HttpGet]
        [Route("RetrieveDetailsForRCHIdErrorCorrection/{rchId}")]
        public ErrorBarcodeDetailResponse FetchDetailForRCHIdCorrection(string rchId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var errorRCHId = _supportService.FetchDetailsForRCHCorrection(rchId);

                _logger.LogInformation($"Received error rch id data {errorRCHId}");
                return errorRCHId.Count == 0 ?
                    new ErrorBarcodeDetailResponse { status = "true", message = "No record found", data = new List<BarcodeErrorDetail>() }
                    : new ErrorBarcodeDetailResponse { status = "true", message = string.Empty, data = errorRCHId };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving rch id error data {e.StackTrace}");
                return new ErrorBarcodeDetailResponse { status = "false", message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used for Check rchId exist
        /// </summary>
        [HttpPost]
        [Route("CheckRCHIDExist/{rchId}")]
        public async Task<IActionResult> CheckRchId(string rchId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var sample = await _supportService.CheckRCHIDExist(rchId);
            return Ok(new CheckRCHResponse
            {
                status = sample.status,
                message = sample.message,
                rchExist = sample.rchExist,
                rchValid = sample.rchValid,
                data = sample.data
            });
        }

        /// <summary>
        /// Used for Update the RCH ID into Revised RCHID
        /// </summary>
        [HttpPost]
        [Route("UpdateRCHIDError")]
        public async Task<IActionResult> UpdateErrorRCHID(UpdateRCHIDRequest rData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Updating the Error RCHID - {JsonConvert.SerializeObject(rData)}");
            var subjectSample = await _supportService.UpdateRCHId(rData);
            return Ok(new ServiceResponse
            {
                Status = subjectSample.Status,
                Message = subjectSample.Message,
            });
        }


    }
}
