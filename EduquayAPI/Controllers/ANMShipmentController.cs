using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models.ANMShipment;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using EduquayAPI.Contracts.V1.Request.ANMShipment;
using EduquayAPI.Contracts.V1.Response.ANMShipment;
using EduquayAPI.Contracts.V1;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class ANMShipmentController : ControllerBase
    {
        private readonly IANMShipmentService _anmShipmentService;
        private readonly ILogger<ANMShipmentController> _logger;

        public ANMShipmentController(IANMShipmentService anmShipmentService, ILogger<ANMShipmentController> logger)
        {
            _anmShipmentService = anmShipmentService;
            _logger = logger;
        }

       
        /// <summary>
        /// Used for add samples to ANM shipment
        /// </summary>
        [HttpPost]
        [Route("Add")]
        public ActionResult<ServiceResponse> AddShipment(AddANMShipmentRequest asData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Adding sample shipment data - {JsonConvert.SerializeObject(asData)}");
                var sampleShipment = _anmShipmentService.AddANMShipment(asData);
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
        /// Used for generate shipmentId to ANM shipment
        /// </summary>
        [HttpPost]
        [Route("GenerateANMShipmentId")]
        public ShipmentIDGenerateResponse GetShipmentID(GenerateShipmentIdRequest sgData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var shipmentID = _anmShipmentService.GenerateANMShipmentID(sgData);
                _logger.LogInformation($"Generated ANM ShipmentId {shipmentID}");
                return shipmentID.Count == 0 ? new ShipmentIDGenerateResponse { Status = "true", Message = "No Shipment Id found", ShipmentID = new List<ANMShipmentID>() } : new ShipmentIDGenerateResponse { Status = "true", Message = string.Empty, ShipmentID = shipmentID };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in generating ANM ShipmentId {e.StackTrace}");
                return new ShipmentIDGenerateResponse { Status = "false", Message = e.Message, ShipmentID = null };
            }
        }

        /// <summary>
        /// Used for get sample collection which are not generated the Shipment Id of particular ANM
        /// </summary>
        [HttpGet]
        [Route("Retrieve/{anmCode}")]
        public ANMPickandPackResponse GetSampleList(int anmCode)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var sampleList = _anmShipmentService.Retrieve(anmCode);
                _logger.LogInformation($"Received Sample Data {sampleList}");
                return sampleList.Count == 0 ? new ANMPickandPackResponse { Status = "true", Message = "No samples found", SampleList = new List<ANMPickandPackSamples>() } : new ANMPickandPackResponse { Status = "true", Message = string.Empty, SampleList = sampleList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving samples data {e.StackTrace}");
                return new ANMPickandPackResponse { Status = "false", Message = e.Message, SampleList = null };
            }
        }

        /// <summary>
        /// Used for get shipment list of particular ANM
        /// </summary>
        [HttpGet]
        [Route("RetrieveANMShipmentLog/{anmCode}")]
        public ShipmentLogResponse GetShipmentList(int anmCode)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var shipmentList = _anmShipmentService.RetrieveShipmentLog(anmCode);
                _logger.LogInformation($"Received ANM shipment Data {shipmentList}");
                return shipmentList.Count == 0 ? new ShipmentLogResponse { Status = "true", Message = "No shipment found", ShipmentList = new List<ANMShipmentLog>() } : new ShipmentLogResponse { Status = "true", Message = string.Empty, ShipmentList = shipmentList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving shipment data {e.StackTrace}");
                return new ShipmentLogResponse { Status = "false", Message = e.Message, ShipmentList = null };
            }
        }

        /// <summary>
        /// Used for view the particular shipmentId and their Samples
        /// </summary>
        [HttpGet]
        [Route("RetrieveANMShipmentDetail/{shipmentId}")]
        public ANMShipmentResponse GetShipmentDetail(string shipmentId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var shipmentDetail = _anmShipmentService.Retrieve(shipmentId);
                _logger.LogInformation($"Received ANM shipment Data {shipmentDetail}");
                return shipmentDetail.Count == 0 ? new ANMShipmentResponse { Status = "true", Message = "No shipment found", ShipmentDetail = new List<ANMShipments>() } : new ANMShipmentResponse { Status = "true", Message = string.Empty, ShipmentDetail = shipmentDetail };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving ANM shipment data {e.StackTrace}");
                return new ANMShipmentResponse { Status = "false", Message = e.Message, ShipmentDetail = null };
            }
        }


    }
}