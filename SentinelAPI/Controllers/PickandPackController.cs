using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SentinelAPI.Contracts.V1.Response.PickandPack;
using SentinelAPI.Models.PickandPack;
using SentinelAPI.Services.PickandPack;

namespace SentinelAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickandPackController : ControllerBase
    {
        private readonly IPickandPackService _pickandPackService;
        private readonly ILogger<PickandPackController> _logger;

        public PickandPackController(IPickandPackService pickandPackService, ILogger<PickandPackController> logger)
        {
            _pickandPackService = pickandPackService;
            _logger = logger;
        }

        /// <summary>
        /// Used for fetch infant subjects sample collection list not shiped
        /// </summary>
        [HttpGet]
        [Route("RetrievePickandPack/{hospitalId}")]
        public PickandPackResponse GetSampleCollectionList(int hospitalId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var samplesList = _pickandPackService.RetrivePickandPackSamples(hospitalId);
                _logger.LogInformation($"Received infant subject Data {samplesList}");
                return samplesList.Count == 0 ?
                    new PickandPackResponse { status = "true", message = "No subjects found",   pickandPackList = new List<PickandPackDetails>() }
                    : new PickandPackResponse { status = "true", message = string.Empty, pickandPackList = samplesList };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving infant subject data {e.StackTrace}");
                return new PickandPackResponse { status = "false", message = e.Message, pickandPackList = null };
            }
        }


    }
}