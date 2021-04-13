using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Contracts.V1.Response.WebMaster;
using EduquayAPI.Models.LoadMasters;
using EduquayAPI.Services.WebMaster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

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
                    new LoadAVDResponse { Status = "true", Message = "No record found", AVD = new LoadAVD() }
                    : new LoadAVDResponse { Status = "true", Message = string.Empty, AVD = avd[0] };
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


        [HttpGet]
        [Route("RetrieveCentralLab/{chcId}")]
        public LoadCentralLabResponse GetCentralLab(int chcId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var centralLab = _webMasterService.RetrieveCentralLabbyCHC(chcId);

                _logger.LogInformation($"Received central lab master data by chc {centralLab}");
                return centralLab.Count == 0 ?
                    new LoadCentralLabResponse { Status = "true", Message = "No record found", CentalLab = new List<LoadCentralLab>() }
                    : new LoadCentralLabResponse { Status = "true", Message = string.Empty, CentalLab = centralLab };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving central lab master data by chc {e.StackTrace}");
                return new LoadCentralLabResponse { Status = "false", Message = e.Message, CentalLab = null };
            }
        }


        [HttpGet]
        [Route("RetrieveMolecularLab/{centralLabId}")]
        public LoadMolecularLabResponse GetMolecularLab(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var molecularLab = _webMasterService.RetrieveMolecularLabbyCentralLab(centralLabId);

                _logger.LogInformation($"Received molecular lab master data by central lab {molecularLab}");
                return molecularLab.Count == 0 ?
                    new LoadMolecularLabResponse { Status = "true", Message = "No record found", MolecularLab = new List<LoadMolecularLab>() }
                    : new LoadMolecularLabResponse { Status = "true", Message = string.Empty, MolecularLab = molecularLab };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving molecular lab master data by central lab {e.StackTrace}");
                return new LoadMolecularLabResponse { Status = "false", Message = e.Message, MolecularLab = null };
            }
        }

        [HttpGet]
        [Route("RetrieveMolecularResult")]
        public LoadMolecularResultResponse GetMolecularLResult()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var molecularResult = _webMasterService.RetrieveMolecularResult();

                _logger.LogInformation($"Received molecular result master data {molecularResult}");
                return molecularResult.Count == 0 ?
                    new LoadMolecularResultResponse { Status = "true", Message = "No record found", MolecularResults = new List<LoadMolecularResult>() }
                    : new LoadMolecularResultResponse { Status = "true", Message = string.Empty, MolecularResults = molecularResult };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving molecular result master data {e.StackTrace}");
                return new LoadMolecularResultResponse { Status = "false", Message = e.Message, MolecularResults = null };
            }
        }


        [HttpGet]
        [Route("RetrieveCHCByTestingCHC/{testingCHCId}")]
        public LoadCHCResponse GetCHCbyTestingCHC(int testingCHCId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var chc = _webMasterService.RetrieveCHCbyTestingCHC(testingCHCId);

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
        [Route("RetrieveCHCByCentralLab/{centralLabId}")]
        public LoadCHCResponse GetCHCbyCentralLab(int centralLabId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var chc = _webMasterService.RetrieveCHCbyCentralLab(centralLabId);

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
        [Route("RetrieveBlockByDistrict/{id}")]
        public LoadCommonResponse RetrieveBlockByDistrict(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch block by district - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _webMasterService.RetrieveBlocksByDistrict(id);

                _logger.LogInformation($"Received block master data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving block data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpGet]
        [Route("RetrieveCHCByBlock/{id}")]
        public LoadCommonResponse RetrieveCHCByBlock(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch chc by block - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _webMasterService.RetrieveCHCByBlock(id); 

                _logger.LogInformation($"Received chc master data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving chc data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpGet]
        [Route("RetrieveANMByCHC/{id}")]
        public LoadCommonResponse RetrieveANMByCHC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch anm by chc - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _webMasterService.RetrieveANMByCHC(id);

                _logger.LogInformation($"Received anm user data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving anm user data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpGet]
        [Route("RetrieveRIByCHC/{id}")]
        public LoadCommonResponse RetrieveRIByCHC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch ri by chc - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _webMasterService.RetrieveRIByCHC(id);

                _logger.LogInformation($"Received ri data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving ri data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpGet]
        [Route("RetrievePHCByCHC/{id}")]
        public LoadCommonResponse RetrievePHCByCHC(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch phc by chc - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _webMasterService.RetrievePHCByCHC(id);

                _logger.LogInformation($"Received phc data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving phc data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpGet]
        [Route("RetrieveAllPNDTLocation")]
        public LoadCommonResponse RetrieveAllPNDTLocation()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _webMasterService.GetAllPNDTLocation();

                _logger.LogInformation($"Received PNDT Location Master data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving pndt location data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpGet]
        [Route("RetrieveAllZygosity")]
        public LoadCommonResponse RetrieveAllZygosity()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _webMasterService.GetAllZygosity();

                _logger.LogInformation($"Received Zygosity master data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving zygosity data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }


        [HttpGet]
        [Route("RetrieveAllMutuation")]
        public LoadCommonResponse RetrieveAllMutuation()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var data = _webMasterService.GetAllMutuation();

                _logger.LogInformation($"Received mutuation master data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving mutuation data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }

        [HttpGet]
        [Route("RetrieveTestingCHCBydistrict/{id}")]
        public LoadCommonResponse RetrieveTestingCHCBydistrict(int id)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            _logger.LogDebug($"Fetch testing chc by district - {JsonConvert.SerializeObject(id)}");
            try
            {
                var data = _webMasterService.RetrieveTestingCHCByDistrict(id);

                _logger.LogInformation($"Received testing chc by district data {data}");
                return data.Count == 0 ?
                    new LoadCommonResponse { Status = "true", Message = "No record found", data = new List<LoadCommon>() }
                    : new LoadCommonResponse { Status = "true", Message = string.Empty, data = data };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving testing chc by district data {e.StackTrace}");
                return new LoadCommonResponse { Status = "false", Message = e.Message, data = null };
            }
        }
    }
}