using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class PHCService : IPHCService
    {
        private readonly IPHCData _phcData;

        public PHCService(IPHCDataFactory phcDataFactory)
        {
            _phcData = new PHCDataFactory().Create();
        }
        public string Add(PHCRequest pdata)
        {
            var result = _phcData.Add(pdata);
            return result;
        }

        public List<PHC> Retreive(int code)
        {
            var phc = _phcData.Retreive(code);
            return phc;
        }

        public List<PHC> Retreive()
        {
            var allPHCs = _phcData.Retreive();
            return allPHCs;
        }
    }
}
