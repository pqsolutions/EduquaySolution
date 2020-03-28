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

        public string Add(SCRequest sData)
        {
            try
            {
                if (sData.IsActive.ToLower() != "true")
                {
                    sData.IsActive = "false";
                }
                if (sData.CHCId <= 0)
                {
                    return "Invalid CHC Id";
                }
                if (sData.PHCId <= 0)
                {
                    return "Invalid PHC Id";
                }
                if (sData.HNIN_ID <= 0)
                {
                    return "Invalid HNIN Id";
                }
                var result = _scData.Add(sData);
                return string.IsNullOrEmpty(result) ? $"Unable to add SC data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add SC data - {e.Message}";
            }
        }

        public List<SC> Retrieve(int code)
        {
            var sc = _scData.Retrieve(code);
            return sc;
        }

        public List<SC> Retrieve()
        {
            var allSCs = _scData.Retrieve();
            return allSCs;
        }
    }
}
