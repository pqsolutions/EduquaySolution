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
using EduquayAPI.Services.ANMCHCPickandPack;
using EduquayAPI.Contracts.V1.Response.ANMCHCPickandPack;
using EduquayAPI.Models.ANMCHCPickandPack;
using EduquayAPI.Contracts.V1.Request.ANMCHCPickandPack;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class ANMCHCPickandPackController : ControllerBase
    {
        private readonly IANMCHCPickandPackService _anmchcPickandPackService;
        private readonly ILogger<ANMCHCPickandPackController> _logger;
        public ANMCHCPickandPackController(IANMCHCPickandPackService anmchcPickandPackService, ILogger<ANMCHCPickandPackController> logger)
        {
            _anmchcPickandPackService = anmchcPickandPackService;
            _logger = logger;
        }

         /// <summary>
        /// Used for get sample collection which are not generated the Shipment Id of particular ANM user / CHC
        /// </summary>
        [HttpPost]
        [Route("Retrieve")]
        public ANMCHCPickandPackResponse GetSampleList(ANMCHCPickandPackRequest acppData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var sampleList = _anmchcPickandPackService.Retrieve(acppData);
                _logger.LogInformation($"Received Sample Data {sampleList}");
                return sampleList.Count == 0 ? new ANMCHCPickandPackResponse { Status = "true", Message = "No samples found", SampleList = new List<ANMCHCPickandPackSamples>() } : new ANMCHCPickandPackResponse { Status = "true", Message = string.Empty, SampleList = sampleList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving samples data {e.StackTrace}");
                return new ANMCHCPickandPackResponse { Status = "false", Message = e.Message, SampleList = null };
            }
        }
    }

}