using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Request.PNDTC;
using EduquayAPI.Contracts.V1.Response.PNDT;
using EduquayAPI.Models.PNDT;
using EduquayAPI.Services.PNDT;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class PNDTCController : ControllerBase
    {
        private readonly IPNDTService _pndtService;
        private readonly ILogger<PNDTCController> _logger;
        private readonly IConfiguration _config;
        public readonly IHostingEnvironment _hostingEnvironment;


        public PNDTCController(IPNDTService pndtService, ILogger<PNDTCController> logger, IHostingEnvironment hostingEnvironment, IConfiguration config)
        {
            _pndtService = pndtService;
            _logger = logger;
            _hostingEnvironment = hostingEnvironment;
            _config = config;
        }

        /// <summary>
        /// Used to retrieve positive couple subjects for schedule the counselling
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTScheduling")]
        public PrePNDTSchedulingResponse GetPositiveSubjectsScheduling(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve positive couple subjects for schedule the counselling - {JsonConvert.SerializeObject(psData)}");
                var prePNDTScheduling = _pndtService.GetPositiveSubjectsScheduling(psData);
                return prePNDTScheduling.Count == 0 ? new PrePNDTSchedulingResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTScheduling>() } : new PrePNDTSchedulingResponse { Status = "true", Message = string.Empty, data = prePNDTScheduling };
            }
            catch (Exception e)
            {
                return new PrePNDTSchedulingResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to add subjects for schedule the counselling
        /// </summary>
        [HttpPost]
        [Route("ADDPrePNDTScheduling")]
        public async Task<IActionResult> AddScheduling(AddSchedulingRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var counselling = await _pndtService.AddScheduling(asData);
            _logger.LogInformation($"Add Scheduling the counselling for positive subjects {counselling}");
            return Ok(new AddSchedulingResponse
            {
                Status = counselling.Status,
                Message = counselling.Message,
                data = counselling.data,
            });
        }


        /// <summary>
        /// Used to retrieve positive couple subjects for scheduled the counselling
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTScheduled")]
        public PrePNDTScheduledResponse GetSubjectsScheduled(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve positive couple subjects for scheduled the counselling - {JsonConvert.SerializeObject(psData)}");
                var prePNDTScheduling = _pndtService.GetSubjectsScheduled(psData);
                return prePNDTScheduling.Count == 0 ? new PrePNDTScheduledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTScheduled>() } : new PrePNDTScheduledResponse { Status = "true", Message = string.Empty, data = prePNDTScheduling };
            }
            catch (Exception e)
            {
                return new PrePNDTScheduledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve positive couple subjects for scheduled the counselling
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselling")]
        public PrePNDTCounsellingResponse GetScheduledForCounselling(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselling - {JsonConvert.SerializeObject(psData)}");
                var prePNDTCounselling = _pndtService.GetScheduledForCounselling(psData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounsellingResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselling>() } : new PrePNDTCounsellingResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounsellingResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to add subjects for counselling for the PrePNDT
        /// </summary>
        [HttpPost]
        [Route("TestingPurpose")]

        public async Task<IActionResult> TestingPurpose([FromForm]object formdata)
        {

            try
            {
                IFormFile file = HttpContext.Request.Form.Files[0];
                if (file.Length > 0)
                {
                    var nameOfFile = DateTime.Now.Ticks + "_" + file.FileName;
                    if (!Directory.Exists(_hostingEnvironment.WebRootPath + "\\UPLOADSDATA\\"))
                    {
                        Directory.CreateDirectory(_hostingEnvironment.WebRootPath + "\\UPLOADSDATA\\");
                    }
                    using (FileStream stream = System.IO.File.Create(_hostingEnvironment.WebRootPath + "\\UPLOADSDATA\\" + nameOfFile))
                    {
                        file.CopyTo(stream);
                        stream.Flush();
                    }
                    return Ok();
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //return Ok();
        }


        [HttpGet]
        [Route("DownloadFile")]
        public async Task<IActionResult> Download(string file, string counsellingType)
        {
            var uploads = "";
            var prePNDTFileLocation = _config.GetSection("Key").GetSection("PrePNDTFileFolder").Value;
            var postPNDTFileLocation = _config.GetSection("Key").GetSection("PostPNDTFileFolder").Value;

            if (counsellingType.ToUpper() == "" || counsellingType.ToUpper() == null)
            {
                return BadRequest();
            }
            else if (counsellingType.ToUpper() == "PREPNDT")
            {
                uploads = Path.Combine(_hostingEnvironment.WebRootPath + prePNDTFileLocation);
            }
            else if (counsellingType.ToUpper() == "POSTPNDT")
            {
                uploads = Path.Combine(_hostingEnvironment.WebRootPath + postPNDTFileLocation);
            }

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
        /// <summary>
        /// Used to add the consent form file the PrePNDT in server Location
        /// </summary>
        [HttpPost]//
        [Route("PrePNDTFileUpload")]
        public async Task<IActionResult> UploadPNDT([FromForm]object formdata)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                IFormFile file = HttpContext.Request.Form.Files[0];
                var counselling = await _pndtService.GetPrePNDTFileDetails(file);
                _logger.LogInformation($"Add Consent form for who agreed PNDT  - {counselling}");
                return Ok(new FileResponse
                {
                    Status = counselling.Status,
                    Message = counselling.Message,
                    data = counselling.data,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Used to add subjects for counselling for the PrePNDT
        /// </summary>
        [HttpPost]
        [Route("ADDPrePNDTCounselling")]
        public async Task<IActionResult> AddCounselling(AddPrePNDTCounsellingRequest acData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                // IFormFile file = HttpContext.Request.Form.Files[0];
                var counselling = await _pndtService.AddCounselling(acData);
                _logger.LogInformation($"Add  counselling for positive subjects for PNDT - {counselling}");
                return Ok(new AddCounsellingResponse
                {
                    Status = counselling.Status,
                    Message = counselling.Message,
                    data = counselling.data,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Used to retrieve positive couple subjects  counseled for PNDT agreed yes
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselledYes")]
        public PrePNDTCounselledResponse GetScheduledForCounseledYes(PNDTSchedulingRequest pcData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselled PNDT agree yes - {JsonConvert.SerializeObject(pcData)}");
                var prePNDTCounselling = _pndtService.GetSubjectsCounselledYes(pcData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounselledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselled>() } : new PrePNDTCounselledResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounselledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve positive couple subjects  counseled for PNDT agreed no
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselledNo")]
        public PrePNDTCounselledResponse GetScheduledForCounseledNo(PNDTSchedulingRequest pcData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselled PNDT agree no - {JsonConvert.SerializeObject(pcData)}");
                var prePNDTCounselling = _pndtService.GetSubjectsCounselledNo(pcData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounselledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselled>() } : new PrePNDTCounselledResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounselledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to retrieve positive couple subjects  counseled for PNDT agreed pending
        /// </summary>
        [HttpPost]
        [Route("RetrievePrePNDTCounselledPending")]
        public PrePNDTCounselledResponse GetScheduledForCounseledPending(PNDTSchedulingRequest pcData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve subjects for the counselled PNDT agree pending - {JsonConvert.SerializeObject(pcData)}");
                var prePNDTCounselling = _pndtService.GetSubjectsCounselledPending(pcData);
                return prePNDTCounselling.Count == 0 ? new PrePNDTCounselledResponse { Status = "true", Message = "No subjects found", data = new List<PrePNDTCounselled>() } : new PrePNDTCounselledResponse { Status = "true", Message = string.Empty, data = prePNDTCounselling };
            }
            catch (Exception e)
            {
                return new PrePNDTCounselledResponse { Status = "false", Message = e.Message, data = null };
            }
        }


        /// <summary>
        /// Used to retrieve schedule for the counselling POST PNDT
        /// </summary>
        [HttpPost]
        [Route("RetrievePostPNDTScheduling")]
        public PostPNDTSchedulingResponse GetPostPNDTScheduling(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve schedule for the counselling POST PNDT - {JsonConvert.SerializeObject(psData)}");
                var postPNDTScheduling = _pndtService.GetPostPNDTScheduling(psData);
                return postPNDTScheduling.Count == 0 ? new PostPNDTSchedulingResponse { Status = "true", Message = "No subjects found", data = new List<PostPNDTScheduling>() } : new PostPNDTSchedulingResponse { Status = "true", Message = string.Empty, data = postPNDTScheduling };
            }
            catch (Exception e)
            {
                return new PostPNDTSchedulingResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to add subjects  Post PNDT schedule for the counselling
        /// </summary>
        [HttpPost]
        [Route("ADDPostPNDTScheduling")]
        public async Task<IActionResult> AddPostPNDTScheduling(AddSchedulingRequest asData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var counselling = await _pndtService.AddPostPNDTScheduling(asData);
            _logger.LogInformation($"Add Scheduling the counselling for Post PNDT  {counselling}");
            return Ok(new AddSchedulingResponse
            {
                Status = counselling.Status,
                Message = counselling.Message,
                data = counselling.data,
            });
        }
        /// <summary>
        /// Used to retrieve Post PNDT  scheduled for the  counselling
        /// </summary>
        [HttpPost]
        [Route("RetrievePostPNDTScheduled")]
        public PostPNDTScheduledResponse GetSubjectsPostPNDTScheduled(PNDTSchedulingRequest psData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve post PNDT  scheduled for the  counselling - {JsonConvert.SerializeObject(psData)}");
                var postPNDTScheduling = _pndtService.GetSubjectsPostPNDTScheduled(psData);
                return postPNDTScheduling.Count == 0 ? new PostPNDTScheduledResponse { Status = "true", Message = "No subjects found", data = new List<PostPNDTScheduled>() } : new PostPNDTScheduledResponse { Status = "true", Message = string.Empty, data = postPNDTScheduling };
            }
            catch (Exception e)
            {
                return new PostPNDTScheduledResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used to  scheduled the counselling for Post PNDT
        /// </summary>

        [HttpPost]
        [Route("RetrievePostPNDTCounselling")]
        public async Task<IActionResult> GetScheduledForPostPNDTCounselling(PNDTSchedulingRequest psData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var postPNDTCounselling = await _pndtService.GetScheduledForPostPNDTCounselling(psData);
            _logger.LogInformation($"Retrieve subjects for the post PNDT counselling {postPNDTCounselling}");
            _logger.LogDebug($"Retrieve subjects for the post PNDT counselling - {JsonConvert.SerializeObject(postPNDTCounselling)}");

            return Ok(new PostPNDTCounsellingResponse
            {
                Status = postPNDTCounselling.Status,
                Message = postPNDTCounselling.Message,
                data = postPNDTCounselling.data,
            });
        }

        /// <summary>
        /// Used to add the consent form file the PrePNDT in server Location
        /// </summary>
        [HttpPost]
        [Route("PostPNDTFileUpload")]
        public async Task<IActionResult> UploadMTP([FromForm]object formdata)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                IFormFile file = HttpContext.Request.Form.Files[0];
                var counselling = await _pndtService.GetPostPNDTFileDetails(file);
                _logger.LogInformation($"Add Consent form for who agreed MTP - {counselling}");
                return Ok(new FileResponse
                {
                    Status = counselling.Status,
                    Message = counselling.Message,
                    data = counselling.data,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        /// <summary>
        /// Used to add subjects for counselling for the Post PNDT
        /// </summary>
        [HttpPost]
        [Route("ADDPostPNDTCounselling")]
        public async Task<IActionResult> AddPostPNDTCounselling(AddPostPNDTCounsellingRequest acData)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                //   IFormFile file = Request.Form.Files.Count > 0 ? Request.Form.Files[0] : null;
                var counselling = await _pndtService.AddPostPNDTCounselling(acData);
                _logger.LogInformation($"Add  counselling the positive subjects for MTP - {counselling}");
                return Ok(new AddPostCounsellingResponse
                {
                    Status = counselling.Status,
                    Message = counselling.Message,
                    data = counselling.data,
                });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Used to retrieve subjects for the counselled MTP agree yes
        /// </summary>
        [HttpPost]
        [Route("RetrievePostPNDTCounselledYes")]
        public async Task<IActionResult> GetScheduledForPostPNDTCounselledPYes(PNDTSchedulingRequest pcData)
        {

            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var postPNDTCounselled = await _pndtService.GetSubjectsPostPNDTCounselledYes(pcData);
            _logger.LogInformation($"Retrieve subjects for the counselled MTP agree yes {postPNDTCounselled}");
            _logger.LogDebug($"Retrieve subjects for the counselled MTP agree yes - {JsonConvert.SerializeObject(postPNDTCounselled)}");

            return Ok(new PostPNDTCounselledResponse
            {
                Status = postPNDTCounselled.Status,
                Message = postPNDTCounselled.Message,
                data = postPNDTCounselled.data,
            });
        }

        /// <summary>
        /// Used to retrieve subjects for the counselled MTP agree No
        /// </summary>
        [HttpPost]
        [Route("RetrievePostPNDTCounselledNo")]
        public async Task<IActionResult> GetScheduledForPostPNDTCounselledNo(PNDTSchedulingRequest pcData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var postPNDTCounselled = await _pndtService.GetSubjectsPostPNDTCounselledNo(pcData);
            _logger.LogInformation($"Retrieve subjects for the counselled MTP agree no {postPNDTCounselled}");
            _logger.LogDebug($"Retrieve subjects for the counselled MTP agree no - {JsonConvert.SerializeObject(postPNDTCounselled)}");

            return Ok(new PostPNDTCounselledResponse
            {
                Status = postPNDTCounselled.Status,
                Message = postPNDTCounselled.Message,
                data = postPNDTCounselled.data,
            });
        }

        /// <summary>
        /// Used to retrieve subjects for the counselled MTP agree pending
        /// </summary>
        [HttpPost]
        [Route("RetrievePostPNDTCounselledPending")]
        public async Task<IActionResult> GetScheduledForPostPNDTCounselledPending(PNDTSchedulingRequest pcData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");

            var postPNDTCounselled = await _pndtService.GetSubjectsPostPNDTCounselledPending(pcData);
            _logger.LogInformation($"Retrieve subjects for the counselled MTP agree pending {postPNDTCounselled}");
            _logger.LogDebug($"Retrieve subjects for the counselled MTP agree pending - {JsonConvert.SerializeObject(postPNDTCounselled)}");

            return Ok(new PostPNDTCounselledResponse
            {
                Status = postPNDTCounselled.Status,
                Message = postPNDTCounselled.Message,
                data = postPNDTCounselled.data,
            });
        }

        /// <summary>
        /// Used to retrieve PNDT Pick and Pack details
        /// </summary>
        [HttpGet]
        [Route("RetrievePNDTPickAndPack/{pndtLocationId}")]
        public PNDTPickandPackResponse RetrievePNDTPickAndPack(int pndtLocationId)
        {
            try
            {
                _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
                _logger.LogDebug($"Retrieve PNDT Specimen samples for pick and pack - {JsonConvert.SerializeObject(pndtLocationId)}");
                var pndtPickandPack = _pndtService.RetrievePickAndPack(pndtLocationId);
                return pndtPickandPack.Count == 0 ? new PNDTPickandPackResponse { Status = "true", Message = "No subjects found", data = new List<PNDTPickAndPack>() } 
                : new PNDTPickandPackResponse { Status = "true", Message = string.Empty, data = pndtPickandPack };
            }
            catch (Exception e)
            {
                return new PNDTPickandPackResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        /// <summary>
        /// Used for add samples to shipment for PNDT Specimen
        /// </summary>
        [HttpPost]
        [Route("AddPNDTShipment")]
        public async Task<IActionResult> AddShipment(AddPNDTShipmentRequest sData)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - Adding PNDT shipment data - {JsonConvert.SerializeObject(sData)}");
            var sampleShipment = await _pndtService.AddPNDTShipment(sData);
            _logger.LogInformation($"add samples to shipment for PNDT Specimen {sampleShipment}");
            _logger.LogDebug($"Response - Adding PNDT shipment data - {JsonConvert.SerializeObject(sampleShipment)}");
            return Ok(new AddPNDTShipmentResponse
            {
                Status = sampleShipment.Status,
                Message = sampleShipment.Message,
                Shipment = sampleShipment.Shipment,
            });
        }

        /// <summary>
        /// Used for get shipment list of particular PNDT Location 
        [HttpGet]
        [Route("RetrievePNDTShipmentLog/{pndtLocationId}")]
        public async Task<IActionResult> GetShipmentList(int pndtLocationId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Request - {JsonConvert.SerializeObject(pndtLocationId)}");
            var shipmentLogResponse = await _pndtService.RetrieveShipmentLogs(pndtLocationId);
            _logger.LogInformation($"get shipment list of particular PNDT location {shipmentLogResponse}");
            _logger.LogDebug($"Response - {JsonConvert.SerializeObject(shipmentLogResponse)}");

            return Ok(new PNDTShipmentLogsResponse
            {
                Status = shipmentLogResponse.Status,
                Message = shipmentLogResponse.Message,
                ShipmentLogs = shipmentLogResponse.ShipmentLogs,
            });
        }
    }
}