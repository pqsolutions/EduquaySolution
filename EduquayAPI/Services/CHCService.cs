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
        public string Add(CHCRequest cData)
        {
            try
            {
                if (cData.DistrictId <= 0)
                {
                    return "Invalid District Id";
                }
                if (cData.BlockId <= 0)
                {
                    return "Invalid Block Id";
                }
                if (cData.HNIN_ID <= 0)
                {
                    return "Invalid HNIN Id";
                }
                if (cData.IsActive.ToLower() != "true")
                {
                    cData.IsActive = "false";
                }
                if (cData.Istestingfacility.ToLower() != "true")
                {
                    cData.Istestingfacility = "false";
                }
                var result = _chcData.Add(cData);
                return string.IsNullOrEmpty(result) ? $"Unable to add CHC data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add CHC data - {e.Message}";
            }
        }

        public List<CHC> Retrieve(int code)
        {
            var chc = _chcData.Retrieve(code);
            return chc;
        }

        public List<CHC> Retrieve()
        {
            var allCHCs = _chcData.Retrieve();
            return allCHCs;
        }
    }
}
