using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.MolecularLab;
using EduquayAPI.Contracts.V1.Response.MolecularLab;
using EduquayAPI.Services.MolecularLab;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MolecularLabController : ControllerBase
    {
        private readonly IMolecularLabService _molecularLabService;
        private readonly ILogger<MolecularLabController> _logger;
        public MolecularLabController(IMolecularLabService molecularLabService, ILogger<MolecularLabController> logger)
        {
            _molecularLabService = molecularLabService;
            _logger = logger;
        }

        /// <summary>
        /// Used for get shipment list receipt  for processing 
        /// </summary>
        [HttpGet]
        [Route("RetrieveMolecularLabReceipt/{molecularLabId}")]
        public async Task<IActionResult> GetShipmentList(int molecularLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            var molecularLabReceiptResponse = await _molecularLabService.RetrieveMolecularLabReceipts(molecularLabId);

            return Ok(new MolecularLabReceiptResponse
            {
                Status = molecularLabReceiptResponse.Status,
                Message = molecularLabReceiptResponse.Message,
                MolecularLabReceipts = molecularLabReceiptResponse.MolecularLabReceipts,
            });
        }

        /// <summary>
        /// Used for add receipt  for processing 
        /// </summary>
        [HttpPost]
        [Route("AddReceivedShipments")]
        public async Task<IActionResult> AddMultipleSamples(AddMolecularLabReceiptRequest mlRequest)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Received shipments to add samples for verification  - {JsonConvert.SerializeObject(mlRequest)}");
            var rsResponse = await _molecularLabService.AddReceivedShipment(mlRequest);

            return Ok(new MolecularReceiptResponse
            {
                Status = rsResponse.Status,
                Message = rsResponse.Message,
                Barcodes = rsResponse.Barcodes,
            });
        }
    }
}