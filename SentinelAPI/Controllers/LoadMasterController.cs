using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SentinelAPI.Contracts.V1.Response.LoadMaster;
using SentinelAPI.Models.Masters.LoadMasters;
using SentinelAPI.Services.Master.LoadMaster;

namespace SentinelAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LoadMasterController : ControllerBase
    {
        private readonly ILoadMasterService _loadMasterService;
        private readonly ILogger<LoadMasterController> _logger;

        public LoadMasterController(ILoadMasterService loadMasterService, ILogger<LoadMasterController> logger)
        {
            _loadMasterService = loadMasterService;
            _logger = logger;
        }

        [HttpGet]
        [Route("RetrieveBirthStatus")]
        public LoadBirthStatusResponse GetBirthSatus()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var birthStatus = _loadMasterService.RetrieveBirthStatus();

                _logger.LogInformation($"Received birth status  master data {birthStatus}");
                return birthStatus.Count == 0 ?
                    new LoadBirthStatusResponse { Status = "true", Message = "No record found", BirthStatus = new List<LoadBirthStatus>() }
                    : new LoadBirthStatusResponse { Status = "true", Message = string.Empty, BirthStatus = birthStatus };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving birth status data {e.StackTrace}");
                return new LoadBirthStatusResponse { Status = "false", Message = e.Message, BirthStatus = null };
            }
        }

        [HttpGet]
        [Route("RetrieveDistrict/{userId}")]
        public LoadDistrictResponse GetDistrict(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var district = _loadMasterService.RetrieveDistrict(userId);

                _logger.LogInformation($"Received district master data {district}");
                return district.Count == 0 ?
                    new LoadDistrictResponse { Status = "true", Message = "No record found", District = new List<LoadDistricts>() }
                    : new LoadDistrictResponse { Status = "true", Message = string.Empty, District = district };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving district data {e.StackTrace}");
                return new LoadDistrictResponse { Status = "false", Message = e.Message, District = null };
            }
        }

        [HttpGet]
        [Route("RetrieveHospital/{userId}")]
        public LoadHospitalResponse GetHospital(int userId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var hospital = _loadMasterService.RetrieveHospital(userId);

                _logger.LogInformation($"Received hospital master data {hospital}");
                return hospital.Count == 0 ?
                    new LoadHospitalResponse { Status = "true", Message = "No record found", Hospital = new List<LoadHospitals>() }
                    : new LoadHospitalResponse { Status = "true", Message = string.Empty, Hospital = hospital };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving district data {e.StackTrace}");
                return new LoadHospitalResponse { Status = "false", Message = e.Message, Hospital = null };
            }
        }

        [HttpGet]
        [Route("RetrieveHospitalByDistrict/{districtId}")]
        public LoadHospitalResponse GetHospitalByDistrict(int districtId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var hospital = _loadMasterService.RetrieveHospitalByDistrict(districtId);

                _logger.LogInformation($"Received hospital master data {hospital}");
                return hospital.Count == 0 ?
                    new LoadHospitalResponse { Status = "true", Message = "No record found", Hospital = new List<LoadHospitals>() }
                    : new LoadHospitalResponse { Status = "true", Message = string.Empty, Hospital = hospital };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving district data {e.StackTrace}");
                return new LoadHospitalResponse { Status = "false", Message = e.Message, Hospital = null };
            }
        }

        [HttpGet]
        [Route("RetrieveReligion")]
        public LoadReligionResponse GetReligion()
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var religion = _loadMasterService.RetrieveReligion();

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
                var caste = _loadMasterService.RetrieveCaste();

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
                var community = _loadMasterService.RetrieveCommunity();

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
        [Route("RetrieveCommunity/{casteId}")]
        public LoadCommunityResponse GetCommunity(int casteId)
        {
            _logger.LogInformation($"Invoking endpoint: {this.HttpContext.Request.GetDisplayUrl()}");
            try
            {
                var community = _loadMasterService.RetrieveCommunity(casteId);

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
                var govIdType = _loadMasterService.RetrieveGovIDType();

                _logger.LogInformation($"Received gov id type master data {govIdType}");
                return govIdType.Count == 0 ?
                    new LoadGovIdTypeResponse { Status = "true", Message = "No record found", GovIdType = new List<LoadGovIdType>() }
                    : new LoadGovIdTypeResponse { Status = "true", Message = string.Empty, GovIdType = govIdType };
            }
            catch (Exception e)
            {
                _logger.LogError($"Error in receiving gov id type data {e.StackTrace}");
                return new LoadGovIdTypeResponse { Status = "false", Message = e.Message, GovIdType = null };
            }
        }

    }
}