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
        public string Add(PHCRequest pData)
        {
            try
            {
                if (pData.IsActive.ToLower() != "true")
                {
                    pData.IsActive = "false";
                }
                if (pData.CHCId <= 0)
                {
                    return "Invalid CHC Id";
                }
                if (pData.HNIN_ID <= 0)
                {
                    return "Invalid HNIN Id";
                }
                var result = _phcData.Add(pData);
                return string.IsNullOrEmpty(result) ? $"Unable to add PHC data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add PHC data - {e.Message}";
            }
        }

        public List<PHC> Retrieve(int code)
        {
            var phc = _phcData.Retrieve(code);
            return phc;
        }

        public List<PHC> Retrieve()
        {
            var allPHCs = _phcData.Retrieve();
            return allPHCs;
        }
    }
}
