using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
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

        public string AddState(StateRequest sData)
        {

            try
            {
                if (sData.isActive.ToLower() != "true")
                {
                    sData.isActive = "false";
                }
                var result = _stateData.Add(sData);
                return string.IsNullOrEmpty(result) ? $"Unable to add state data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add state data - {e.Message}";
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
