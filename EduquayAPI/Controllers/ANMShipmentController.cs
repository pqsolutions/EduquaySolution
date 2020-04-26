using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
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

        [HttpGet]
        [Route("Retrieve")]
        public ANMShipmentResponse GetSampleList(int anmCode)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var sampleList = _anmShipmentService.Retrieve(anmCode);
                _logger.LogInformation($"Received Sample Data {sampleList}");
                return sampleList.Count == 0 ? new ANMShipmentResponse { Status = "true", Message = "No samples found", SampleList = new List<ANMPickandPackSamples>() } : new ANMShipmentResponse { Status = "true", Message = string.Empty, SampleList = sampleList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving samples data {e.StackTrace}");
                return new ANMShipmentResponse { Status = "false", Message = e.Message, SampleList = null };
            }
        }

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
    }
}