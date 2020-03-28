using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class SCService : ISCService
    {

        private readonly ISCData _scData;

        public SCService(ISCDataFactory scDataFactory)
        {
            _scData = new SCDataFactory().Create();
        }

        public string Add(SCRequest sdata)
        {
            var result = _scData.Add(sdata);
            return result;
        }

        public List<SC> Retreive(int code)
        {
            var sc = _scData.Retreive(code);
            return sc;
        }

        public List<SC> Retreive()
        {
            var allSCs = _scData.Retreive();
            return allSCs;
        }
    }
}
