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
    public class StateController : ControllerBase
    {
        private readonly IStateService _stateService;

        public StateController(IStateService stateService)
        {
            _stateService = stateService;
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddState(StateRequest sData)
        {
            var addEditResponse = await _stateService.AddState(sData);
            return Ok(new AddEditResponse
            {
                Status = addEditResponse.Status,
                Message = addEditResponse.Message,
            });
        }

        [HttpGet]
        [Route("Retrieve")]
        public StateResponse GetStates()
        {
            try
            {
                var states = _stateService.Retrieve();
                return states.Count == 0 ? new StateResponse { Status = "true", Message = "No states found", States = new List<State>() } : new StateResponse { Status = "true", Message = string.Empty, States = states };
            }
            catch (Exception e)
            {
                return new StateResponse { Status = "false", Message = e.Message, States = null };
            }
        }

        [HttpGet]
        [Route("Retrieve/{code}")]
        public StateResponse GetState(int code)
        {
            try
            {
                var states = _stateService.Retrieve(code);
                return states.Count == 0 ? new StateResponse { Status = "true", Message = "No state found", States = new List<State>() } : new StateResponse { Status = "true", Message = string.Empty, States = states };
            }
            catch (Exception e)
            {
                return new StateResponse { Status = "false", Message = e.Message, States = null };
            }
        }
    }
}