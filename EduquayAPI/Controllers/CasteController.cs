using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.Models;
using EduquayAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduquayAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CasteController : ControllerBase
    {
        private readonly ICasteService _casteService;

        public CasteController(ICasteService casteService)
        {
            _casteService = casteService;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<ActionResult> Add(CasteRequest cData)
        {
            var addEditResponse = await _casteService.Add(cData);
            return Ok(new AddEditResponse 
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
           
        }

        [HttpGet]
        [Route("Retrieve")]
        public CasteResponse GeCastes()
        {
            try
            {
                var castes = _casteService.Retrieve();
                return castes.Count == 0 ? new CasteResponse { Status = "true", Message = "No caste found", Caste = new List<Caste>() } : new CasteResponse { Status = "true", Message = string.Empty, Caste = castes };
            }
            catch (Exception e)
            {
                return new CasteResponse { Status = "false", Message = e.Message, Caste = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public CasteResponse GetCaste(int code)
        {
            try
            {
                var castes = _casteService.Retrieve(code);
                return castes.Count == 0 ? new CasteResponse { Status = "true", Message = "No caste found", Caste = new List<Caste>() } : new CasteResponse { Status = "true", Message = string.Empty, Caste = castes };
            }
            catch (Exception e)
            {
                return new CasteResponse { Status = "false", Message = e.Message, Caste = null };
            }
        }
    }
}