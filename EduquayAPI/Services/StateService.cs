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

        public string AddState(StateRequest sdata)
        {
            var result = _stateData.Add(sdata);
            return result;
        }

        public List<State> Retreive(int code)
        {
            var state = _stateData.Retreive(code);
            return state;
        }

        public List<State> Retreive()
        {
            var allStates = _stateData.Retreive();
            return allStates;
        }
    }
}
