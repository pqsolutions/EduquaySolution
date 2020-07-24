using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Response.WebMaster;
using EduquayAPI.Models.LoadMasters;
using EduquayAPI.Services.WebMaster;
using Microsoft.AspNetCore.Authorization;
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
        [Route("RetrieveStates")]
        public LoadStateResponse  GetState()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var states = _webMasterService.RetrieveState();

                _logger.LogInformation($"Received state master data {states}");
                return states.Count == 0 ?
                    new LoadStateResponse  { Status = "true", Message = "No record found", State = new List<LoadState>() }
                    : new LoadStateResponse   { Status = "true", Message = string.Empty, State = states };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving state data {e.StackTrace}");
                return new LoadStateResponse  { Status = "false", Message = e.Message, State = null };
            }
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
        [Route("RetrievePHC/{userId}")]
        public LoadPHCResponse GetPHC(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var phc = _webMasterService.RetrievePHC(userId);

                _logger.LogInformation($"Received phc master data {phc}");
                return phc.Count == 0 ?
                    new LoadPHCResponse { Status = "true", Message = "No record found", PHC = new List<LoadPHCs>() }
                    : new LoadPHCResponse { Status = "true", Message = string.Empty, PHC = phc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving phc data {e.StackTrace}");
                return new LoadPHCResponse { Status = "false", Message = e.Message, PHC = null };
            }
        }

        [HttpGet]
        [Route("RetrieveSC/{userId}")]
        public LoadSCResponse GetSC(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var sc = _webMasterService.RetrieveSC(userId);

                _logger.LogInformation($"Received sc master data {sc}");
                return sc.Count == 0 ?
                    new LoadSCResponse { Status = "true", Message = "No record found", SC = new List<LoadSCs>() }
                    : new LoadSCResponse { Status = "true", Message = string.Empty, SC = sc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving sc data {e.StackTrace}");
                return new LoadSCResponse { Status = "false", Message = e.Message, SC = null };
            }
        }
        [HttpGet]
        [Route("RetrieveRI/{userId}")]
        public LoadRIResponse GetRI(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var ri = _webMasterService.RetrieveRI(userId);

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
        [Route("RetrieveTestingCHC/{riId}")]
        public LoadTestingCHCResponse GetTestingCHC(int riId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var chc = _webMasterService.RetrieveTestingCHC(riId);

                _logger.LogInformation($"Received chc master data {chc}");
                return chc.Count == 0 ?
                    new LoadTestingCHCResponse { Status = "true", Message = "No record found", TestingCHC = new List<LoadCHCs>() }
                    : new LoadTestingCHCResponse { Status = "true", Message = string.Empty, TestingCHC = chc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving chc data {e.StackTrace}");
                return new LoadTestingCHCResponse { Status = "false", Message = e.Message, TestingCHC = null };
            }
        }

        [HttpGet]
        [Route("RetrieveTestingCHCByCollectionCHC/{chcId}")]
        public LoadTestingCHCResponse GetTestingCHCbyCHC(int chcId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var chc = _webMasterService.RetrieveTestingCHCbyCHC(chcId);

                _logger.LogInformation($"Received chc master data {chc}");
                return chc.Count == 0 ?
                    new LoadTestingCHCResponse { Status = "true", Message = "No record found", TestingCHC = new List<LoadCHCs>() }
                    : new LoadTestingCHCResponse { Status = "true", Message = string.Empty, TestingCHC = chc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving chc data {e.StackTrace}");
                return new LoadTestingCHCResponse { Status = "false", Message = e.Message, TestingCHC = null };
            }
        }

        [HttpGet]
        [Route("RetrieveANM/{riId}")]
        public LoadAssociatedANMResponse GetANM(int riId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var associatedANM = _webMasterService.RetrieveAssociatedANM(riId);

                _logger.LogInformation($"Received associated ANM master data by ri {associatedANM}");
                return associatedANM.Count == 0 ?
                    new LoadAssociatedANMResponse { Status = "true", Message = "No record found", AssociatedANM = new List<LoadAssociatedANM>() }
                    : new LoadAssociatedANMResponse { Status = "true", Message = string.Empty, AssociatedANM = associatedANM };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving associated ANM data by ri {e.StackTrace}");
                return new LoadAssociatedANMResponse { Status = "false", Message = e.Message, AssociatedANM = null };
            }
        }

        [HttpGet]
        [Route("RetrieveAssociatedANM/{chcId}")]
        public SCRIANMResponse GetAssociatedANM(int chcId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var associatedANM = _webMasterService.RetrieveAssociatedANMByCHC(chcId);

                _logger.LogInformation($"Received associated ANM master data by chc {associatedANM}");
                return associatedANM.Count == 0 ?
                    new SCRIANMResponse { Status = "true", Message = "No record found", AssociatedANMDetail = new List<AssociatedSCRIANM>() }
                    : new SCRIANMResponse { Status = "true", Message = string.Empty, AssociatedANMDetail = associatedANM };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving associated ANM data by chc {e.StackTrace}");
                return new SCRIANMResponse { Status = "false", Message = e.Message, AssociatedANMDetail = null };
            }
        }

        [HttpGet]
        [Route("RetrieveILR/{riId}")]
        public LoadILRResponse GetILRByRI(int riId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var ilr = _webMasterService.RetrieveILR(riId);

                _logger.LogInformation($"Received ILR master data {ilr}");
                return ilr.Count == 0 ?
                    new LoadILRResponse { Status = "true", Message = "No record found", ILR = new List<LoadILR>() }
                    : new LoadILRResponse { Status = "true", Message = string.Empty, ILR = ilr };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving ILR data {e.StackTrace}");
                return new LoadILRResponse { Status = "false", Message = e.Message, ILR = null };
            }
        }

        [HttpGet]
        [Route("RetrieveAVD/{riId}")]
        public LoadAVDResponse GetAVDByRI(int riId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var avd = _webMasterService.RetrieveAVD(riId);

                _logger.LogInformation($"Received AVD master data {avd}");
                return avd.Count == 0 ?
                    new LoadAVDResponse { Status = "true", Message = "No record found", AVD = new List<LoadAVD>() }
                    : new LoadAVDResponse { Status = "true", Message = string.Empty, AVD = avd };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving AVD data {e.StackTrace}");
                return new LoadAVDResponse { Status = "false", Message = e.Message, AVD = null };
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
        [Route("RetrieveLogisticsProvider")]
        public LoadProviderResponse GetLogisticsProvider()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var provider = _webMasterService.RetrieveLogisticsProvider();

                _logger.LogInformation($"Received Logistics Provider master data {provider}");
                return provider.Count == 0 ?
                    new LoadProviderResponse { Status = "true", Message = "No record found", LogisticsProvider = new List<LoadLogisticsProvider >() }
                    : new LoadProviderResponse { Status = "true", Message = string.Empty, LogisticsProvider = provider };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving state data {e.StackTrace}");
                return new LoadProviderResponse { Status = "false", Message = e.Message, LogisticsProvider = null };
            }
        }
    }
}