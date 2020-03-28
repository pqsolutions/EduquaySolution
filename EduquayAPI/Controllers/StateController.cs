using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
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
        public ActionResult<string> AddState(StateRequest sdata)
        {
            var state = _stateService.AddState(sdata);
            if (state == null)
            {
                return NotFound();
            }
            return state;
        }

        [HttpGet]
        [Route("Retreive")]
        public StateResponse GetStates()
        {
            try
            {
                var states = _stateService.Retreive();
                return states.Count == 0 ? new StateResponse { Status = "true", Message = "No states found", States = new List<State>() } : new StateResponse { Status = "true", Message = string.Empty, States = states };
            }
            catch (Exception e)
            {
                return new StateResponse { Status = "false", Message = e.Message, States = null };
            }
        }

        [HttpGet]
        [Route("Retreive/{code}")]
        public StateResponse GetState(int code)
        {
            try
            {
                var states = _stateService.Retreive(code);
                return states.Count == 0 ? new StateResponse { Status = "true", Message = "No state found", States = new List<State>() } : new StateResponse { Status = "true", Message = string.Empty, States = states };
            }
            catch (Exception e)
            {
                return new StateResponse { Status = "false", Message = e.Message, States = null };
            }
        }
    }  
}