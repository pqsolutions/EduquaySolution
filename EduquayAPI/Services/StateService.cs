using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;


namespace EduquayAPI.Services
{
    public class StateService : IStateService
    {
        private readonly IStateData _stateData;

        public StateService(IStateDataFactory stateDataFactory)
        {
            _stateData = new StateDataFactory().Create();
        }

        public async Task<AddEditResponse> AddState(StateRequest sData)
        {
            var response = new AddEditResponse();
            try
            {
                if (string.IsNullOrEmpty(sData.stateGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter state gov code";
                }
                else
                {
                    var addEditResponse = _stateData.Add(sData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
            }
        }
        
        public List<State> Retrieve(int code)
        {
            var state = _stateData.Retrieve(code);
            return state;
        }

        public List<State> Retrieve()
        {
            var allStates = _stateData.Retrieve();
            return allStates;
        }

       
    }
}
