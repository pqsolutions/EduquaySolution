using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Response.WebMaster;
using EduquayAPI.Models.LoadMasters;
using EduquayAPI.Services.WebMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class WebMasterController : ControllerBase
    {

        private readonly IWebMasterService _webMasterService;
        private readonly ILogger<WebMasterController> _logger;

        public WebMasterController(IWebMasterService webMasterService, ILogger<WebMasterController> logger)
        {
            _webMasterService = webMasterService;
            _logger = logger;
        }


        [HttpGet]
        [Route("RetrieveDistrict/{userId}")]
        public LoadDistrictReponse GetDistrict(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var district = _webMasterService.RetrieveDistrict(userId);

                _logger.LogInformation($"Received district master data {district}");
                return district.Count == 0 ?
                    new LoadDistrictReponse { Status = "true", Message = "No record found", District = new List<LoadDistricts>() }
                    : new LoadDistrictReponse { Status = "true", Message = string.Empty, District = district };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving district data {e.StackTrace}");
                return new LoadDistrictReponse { Status = "false", Message = e.Message, District = null };
            }
        }

        [HttpGet]
        [Route("RetrieveCHC/{userId}")]
        public LoadCHCResponse GetCHC(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var chc = _webMasterService.RetrieveCHC(userId);

                _logger.LogInformation($"Received chc master data {chc}");
                return chc.Count == 0 ?
                    new LoadCHCResponse { Status = "true", Message = "No record found", CHC = new List<LoadCHCs>() }
                    : new LoadCHCResponse { Status = "true", Message = string.Empty, CHC = chc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving chc data {e.StackTrace}");
                return new LoadCHCResponse { Status = "false", Message = e.Message, CHC = null };
            }
        }

        [HttpGet]
        [Route("RetrieveConstantValues/{userId}")]
        public LoadConstantResponse GetConstantValues(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var constantValues = _webMasterService.RetrieveConstantValues(userId);

                _logger.LogInformation($"Received constant values data {constantValues}");
                return constantValues.Count == 0 ?
                    new LoadConstantResponse { Status = "true", Message = "No record found", ConstantValues = new List<LoadConstantValues>() }
                    : new LoadConstantResponse { Status = "true", Message = string.Empty, ConstantValues = constantValues };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving chc data {e.StackTrace}");
                return new LoadConstantResponse { Status = "false", Message = e.Message, ConstantValues = null };
            }
        }

        [HttpGet]
        [Route("RetrieveRI/{pincode}")]
        public LoadRIResponse GetRI(string pincode)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var ri = _webMasterService.RetrieveRI(pincode);

                _logger.LogInformation($"Received ri master data {ri}");
                return ri.Count == 0 ?
                    new LoadRIResponse { Status = "true", Message = "No record found", RI = new List<LoadRIs>() }
                    : new LoadRIResponse { Status = "true", Message = string.Empty, RI = ri };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving ri data {e.StackTrace}");
                return new LoadRIResponse { Status = "false", Message = e.Message, RI = null };
            }
        }


        [HttpGet]
        [Route("RetrieveReligion")]
        public LoadReligionResponse GetReligion()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var religion = _webMasterService.RetrieveReligion();

                _logger.LogInformation($"Received religion master data {religion}");
                return religion.Count == 0 ?
                    new LoadReligionResponse { Status = "true", Message = "No record found", Religion = new List<LoadReligion>() }
                    : new LoadReligionResponse { Status = "true", Message = string.Empty, Religion = religion };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving religion data {e.StackTrace}");
                return new LoadReligionResponse { Status = "false", Message = e.Message, Religion = null };
            }
        }

        [HttpGet]
        [Route("RetrieveCaste")]
        public LoadCasteResponse GetCaste()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var caste = _webMasterService.RetrieveCaste();

                _logger.LogInformation($"Received caste master data {caste}");
                return caste.Count == 0 ?
                    new LoadCasteResponse { Status = "true", Message = "No record found", Caste = new List<LoadCaste>() }
                    : new LoadCasteResponse { Status = "true", Message = string.Empty, Caste = caste };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving caste data {e.StackTrace}");
                return new LoadCasteResponse { Status = "false", Message = e.Message, Caste = null };
            }
        }


        [HttpGet]
        [Route("RetrieveCommunity")]
        public LoadCommunityResponse GetCommunity()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var community = _webMasterService.RetrieveCommunity();

                _logger.LogInformation($"Received community master data {community}");
                return community.Count == 0 ?
                    new LoadCommunityResponse { Status = "true", Message = "No record found", Community = new List<LoadCommunity>() }
                    : new LoadCommunityResponse { Status = "true", Message = string.Empty, Community = community };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving community data {e.StackTrace}");
                return new LoadCommunityResponse { Status = "false", Message = e.Message, Community = null };
            }
        }

        [HttpGet]
        [Route("RetrieveCommunity/{code}")]
        public LoadCommunityResponse GetCommunity(int code)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var community = _webMasterService.RetrieveCommunity(code);

                _logger.LogInformation($"Received community master data {community}");
                return community.Count == 0 ?
                    new LoadCommunityResponse { Status = "true", Message = "No record found", Community = new List<LoadCommunity>() }
                    : new LoadCommunityResponse { Status = "true", Message = string.Empty, Community = community };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving community data {e.StackTrace}");
                return new LoadCommunityResponse { Status = "false", Message = e.Message, Community = null };
            }
        }

        [HttpGet]
        [Route("RetrieveGovIdType")]
        public LoadGovIdTypeResponse GetGovIdType()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var govIdType = _webMasterService.RetrieveGovIDType();

                _logger.LogInformation($"Received gov id type master data {govIdType}");
                return govIdType.Count == 0 ?
                    new LoadGovIdTypeResponse { Status = "true", Message = "No record found", GovIdType = new List<LoadGovIDType>() }
                    : new LoadGovIdTypeResponse { Status = "true", Message = string.Empty, GovIdType = govIdType };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving gov id type data {e.StackTrace}");
                return new LoadGovIdTypeResponse { Status = "false", Message = e.Message, GovIdType = null };
            }
        }

        [HttpGet]
        [Route("RetrieveAssociatedANM/{code}")]
        public LoadAssociatedANMResponse GetAssociatedANM(int code)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var associatedANM = _webMasterService.RetrieveAssociatedANM(code);

                _logger.LogInformation($"Received Associated ANM master data {associatedANM}");
                return associatedANM.Count == 0 ?
                    new LoadAssociatedANMResponse { Status = "true", Message = "No record found", AssociatedANM = new List<LoadAssociatedANM>() }
                    : new LoadAssociatedANMResponse { Status = "true", Message = string.Empty, AssociatedANM = associatedANM };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving associated ANM data {e.StackTrace}");
                return new LoadAssociatedANMResponse { Status = "false", Message = e.Message, AssociatedANM = null };
            }
        }


    }
}