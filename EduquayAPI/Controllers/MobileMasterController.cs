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

                return district.Count == 0 && chc.Count == 0 && phc.Count == 0 && sc.Count == 0 && ri.Count == 0 && religion.Count == 0 && caste.Count == 0 && community.Count == 0 && govIdType.Count == 0  ?
                    new MobileMasterResponse { Status = "true", Message = "No record found", Districts = new List<LoadDistricts>(), CHC = new List<LoadCHCs>(), PHC = new List<LoadPHCs>(), SC = new List<LoadSCs>(),
                        RI = new List<LoadRIs>(), Religion = new List<LoadReligion>(), Caste = new List<LoadCaste>(), Community = new List<LoadCommunity>(), GovIdType = new List<LoadGovIDType>()   }
                    : new MobileMasterResponse { Status = "true", Message = string.Empty, Districts = district, CHC = chc, PHC = phc, SC = sc, RI = ri, Religion = religion, Caste = caste, Community = community, GovIdType = govIdType };
            }
            catch (Exception e)
            {
                return new MobileMasterResponse { Status = "false", Message = e.Message, Districts = null, CHC = null, PHC = null, SC = null, RI = null, Religion = null, Caste = null, Community = null, GovIdType = null };
            }
        }

        [HttpGet]
        [Route("RetrieveCommunity/{code}")]
        public CommunityMasterResponse GetCommunity(int code)
        {
            try
            {
                var community = _mobileMasterService.RetrieveCommunity(code);


                return community.Count == 0 ?
                    new CommunityMasterResponse { Status = "true", Message = "No record found", Community = new List<LoadCommunity>()}
                    : new CommunityMasterResponse { Status = "true", Message = string.Empty, Community = community};
            }
            catch (Exception e)
            {
                return new CommunityMasterResponse { Status = "false", Message = e.Message, Community = null };
            }
        }

    }


}