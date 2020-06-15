using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Models.ANMShipment;
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
        /// Used for add samples to shipment for ANM user / CHC 
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public ActionResult<ServiceResponse> AddShipment(AddANMCHCShipmentRequest asData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Adding sample shipment data - {JsonConvert.SerializeObject(asData)}");
                var sampleShipment = _anmchcShipmentService.AddANMCHCShipment(asData);
                if (sampleShipment == null)
                {
                    return NotFound();
                }
                _logger.LogInformation($"Sample shipment data added successfully - {asData}");
                return new ServiceResponse { Status = "true", Message = string.Empty, Result = sampleShipment };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Failed to add sample shipment data - {ex.StackTrace}");
                return new ServiceResponse { Status = "true", Message = ex.Message, Result = "Failed to add sample shipment data" };
            }
        }



        /// <summary>
        /// Used for generate shipmentId to ANM / CHC shipment
        /// </summary>
        [HttpPost]
        [Route("GenerateANMCHCShipmentId")]
        public GenerateANMCHCShipmentIdResponse GetANMCHCShipmentID(ShipmentIdGenerateRequest sgData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var shipmentID = _anmchcShipmentService.ANMCHCGenerateShipmentId(sgData);
                _logger.LogInformation($"Generated ShipmentId {shipmentID}");
                return shipmentID.Count == 0 ? new GenerateANMCHCShipmentIdResponse { Status = "true", Message = "No Shipment Id found", ShipmentID = new List<ANMCHCShipmentID>() } : new GenerateANMCHCShipmentIdResponse { Status = "true", Message = string.Empty, ShipmentID = shipmentID };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in generating ShipmentId {e.StackTrace}");
                return new GenerateANMCHCShipmentIdResponse { Status = "false", Message = e.Message, ShipmentID = null };
            }
        }

        /// <summary>
        /// Used for get shipment list of particular ANM user / CHC
        /// </summary>
        [HttpPost]
        [Route("RetrieveANMCHCShipmentLog")]
        public ANMCHCShipmentLogResponse GetShipmentList(ANMCHCShipmentLogRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var shipmentList = _anmchcShipmentService.RetrieveShipmentLog(asData);
                _logger.LogInformation($"Received shipment log data {shipmentList}");
                return shipmentList.Count == 0 ? new ANMCHCShipmentLogResponse { Status = "true", Message = "No shipment found", ShipmentList = new List<ANMCHCShipmentLogs>() } : new ANMCHCShipmentLogResponse { Status = "true", Message = string.Empty, ShipmentList = shipmentList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving shipment log data {e.StackTrace}");
                return new ANMCHCShipmentLogResponse { Status = "false", Message = e.Message, ShipmentList = null };
            }
        }

        /// <summary>
        /// Used for view the particular shipmentId and their Samples of Particular ANM user / CHC
        /// </summary>
        [HttpPost]
        [Route("RetrieveANMCHCShipmentDetail")]
        public ANMCHCShipmentDetialResponse GetShipmentDetail(ANMCHCShipmentDetailRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var shipmentDetail = _anmchcShipmentService.RetrieveShipmentDetail(asData);
                _logger.LogInformation($"Received shipment detail data {shipmentDetail}");
                return shipmentDetail.Count == 0 ? new ANMCHCShipmentDetialResponse { Status = "true", Message = "No shipment found", ShipmentDetail = new List<ANMCHCShipmentDetail>() } : new ANMCHCShipmentDetialResponse { Status = "true", Message = string.Empty, ShipmentDetail = shipmentDetail };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving shipment detail data {e.StackTrace}");
                return new ANMCHCShipmentDetialResponse { Status = "false", Message = e.Message, ShipmentDetail = null };
            }
        }


    }
}