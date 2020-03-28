using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class RIService : IRIService
    {

        private readonly IRIData _riData;

        public RIService(IRIDataFactory riDataFactory)
        {
            _riData = new RIDataFactory().Create();
        }
        public string Add(RIRequest rdata)
        {
            var result = _riData.Add(rdata);
            return result;
        }

        public List<RI> Retreive(int code)
        {
            var ri = _riData.Retreive(code);
            return ri;
        }

        public List<RI> Retreive()
        {
            var allRIs = _riData.Retreive();
            return allRIs;
        }
    }
}
