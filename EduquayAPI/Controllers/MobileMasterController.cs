using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1;
using EduquayAPI.Services;
using EduquayAPI.Services.MobileMaster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http.Extensions;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using EduquayAPI.Contracts.V1.Response.MobileMster;
using EduquayAPI.Models.LoadMasters;

namespace EduquayAPI.Controllers
{
    [Route(ApiRoutes.Base + "/[controller]")]
    [ApiController]
    public class MobileMasterController : ControllerBase
    {
        private readonly IMobileMasterService _mobileMasterService;
        private readonly ILogger<MobileMasterController> _logger;

        public MobileMasterController(IMobileMasterService mobileMasterService, ILogger<MobileMasterController> logger)
        {
            _mobileMasterService = mobileMasterService;
            _logger = logger;
        }



        [HttpGet]
        [Route("Retrieve/{userId}")]
        public MobileMasterResponse GetSubject(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var district = _mobileMasterService.RetrieveDistrict(userId);
                var chc = _mobileMasterService.RetrieveCHC(userId);
                var phc = _mobileMasterService.RetrievePHC(userId);
                var sc = _mobileMasterService.RetrieveSC(userId);
                var ri = _mobileMasterService.RetrieveRI(userId);
                var religion = _mobileMasterService.RetrieveReligion();
                var caste = _mobileMasterService.RetrieveCaste();
                var community = _mobileMasterService.RetrieveCommunity();
                var govIdType = _mobileMasterService.RetrieveGovIDType();
                var constantValues = _mobileMasterService.RetrieveConstantValues();
                _logger.LogInformation($"Received master data {district},{chc}, {phc},{sc},{ri},{religion},{caste},{community},{govIdType},{constantValues}");
                return district.Count == 0 && chc.Count == 0 && phc.Count == 0 && sc.Count == 0 && ri.Count == 0 && religion.Count == 0 && caste.Count == 0 && community.Count == 0 && govIdType.Count == 0 && constantValues.Count == 0 ?
                    new MobileMasterResponse { Status = "true", Message = "No record found", Districts = new List<LoadDistricts>(), CHC = new List<LoadCHCs>(), PHC = new List<LoadPHCs>(), SC = new List<LoadSCs>(),
                        RI = new List<LoadRIs>(), Religion = new List<LoadReligion>(), Caste = new List<LoadCaste>(), Community = new List<LoadCommunity>(), GovIdType = new List<LoadGovIDType>() , ConstantValues = new List<LoadConstantValues>()   }
                    : new MobileMasterResponse { Status = "true", Message = string.Empty, Districts = district, CHC = chc, PHC = phc, SC = sc, RI = ri, Religion = religion, Caste = caste, Community = community, GovIdType = govIdType, ConstantValues = constantValues  };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving master data {e.StackTrace}");
                return new MobileMasterResponse { Status = "false", Message = e.Message, Districts = null, CHC = null, PHC = null, SC = null, RI = null, Religion = null, Caste = null, Community = null, GovIdType = null,  ConstantValues = null };
            }
        }

        [HttpGet]
        [Route("RetrieveCommunity/{code}")]
        public CommunityMasterResponse GetCommunity(int code)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var community = _mobileMasterService.RetrieveCommunity(code);

                _logger.LogInformation($"Received community master data {community}");
                return community.Count == 0 ?
                    new CommunityMasterResponse { Status = "true", Message = "No record found", Community = new List<LoadCommunity>()}
                    : new CommunityMasterResponse { Status = "true", Message = string.Empty, Community = community};
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving community data {e.StackTrace}");
                return new CommunityMasterResponse { Status = "false", Message = e.Message, Community = null };
            }
        }

        [HttpGet]
        [Route("RetrieveAVD/{riId}")]
        public MobileAVDMasterResponse GetAVDByRI(int riId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var avd = _mobileMasterService.RetrieveAVD(riId);

                _logger.LogInformation($"Received AVD master data {avd}");
                return avd.Count == 0 ?
                    new MobileAVDMasterResponse { Status = "true", Message = "No record found", AVD = new List<LoadAVD>() }
                    : new MobileAVDMasterResponse { Status = "true", Message = string.Empty, AVD = avd };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving AVD data {e.StackTrace}");
                return new MobileAVDMasterResponse { Status = "false", Message = e.Message, AVD = null };
            }
        }

        [HttpGet]
        [Route("RetrieveTestingCHC/{riId}")]
        public MobileTestingCHCResponse GetTestingCHC(int riId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var chc = _mobileMasterService.RetrieveTestingCHC(riId);

                _logger.LogInformation($"Received chc master data {chc}");
                return chc.Count == 0 ?
                    new MobileTestingCHCResponse { Status = "true", Message = "No record found", TestingCHC = new List<LoadCHCs>() }
                    : new MobileTestingCHCResponse { Status = "true", Message = string.Empty, TestingCHC = chc };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving chc data {e.StackTrace}");
                return new MobileTestingCHCResponse { Status = "false", Message = e.Message, TestingCHC = null };
            }
        }

        [HttpGet]
        [Route("RetrieveILR/{riId}")]
        public MobileILRMasterResponse GetILRByRI(int riId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var ilr = _mobileMasterService.RetrieveILR(riId);

                _logger.LogInformation($"Received ILR master data {ilr}");
                return ilr.Count == 0 ?
                    new MobileILRMasterResponse { Status = "true", Message = "No record found", ILR = new List<LoadILR>() }
                    : new MobileILRMasterResponse { Status = "true", Message = string.Empty, ILR = ilr };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving ILR data {e.StackTrace}");
                return new MobileILRMasterResponse { Status = "false", Message = e.Message, ILR = null };
            }
        }


    }
}