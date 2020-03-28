using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class CHCService : ICHCService
    {

        private readonly ICHCData _chcData;

        public CHCService(ICHCDataFactory chcDataFactory)
        {
            _chcData = new CHCDataFactory().Create();
        }
        public string Add(CHCRequest cdata)
        {
            var result = _chcData.Add(cdata);
            return result;
        }

        public List<CHC> Retreive(int code)
        {
            var chc = _chcData.Retreive(code);
            return chc;
        }

        public List<CHC> Retreive()
        {
            var allCHCs = _chcData.Retreive();
            return allCHCs;
        }
    }
}
