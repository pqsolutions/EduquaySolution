using EduquayAPI.Models;
using EduquayAPI.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;

namespace EduquayAPI.Services
{
    public class HNINService : IHNINService
    {
        private readonly IHNINData _hninData;

        public HNINService(IHNINDataFactory hninDataFactory)
        {
            _hninData = new HNINDataFactory().Create();
        }
        public string Add(HNINRequest hData)
        {
            try
            {
                if (hData.IsActive.ToLower() != "true")
                {
                    hData.IsActive = "false";
                }
                if (hData.Facilitytype_ID <= 0)
                {
                    return "Invalid Facility Type Id";
                }
                if (hData.StateId <= 0)
                {
                    return "Invalid State Id";
                }
                if (hData.DistrictId <= 0)
                {
                    return "Invalid District Id";
                }
                if (hData.BlockId <= 0)
                {
                    return "Invalid Block Id";
                }

                var result = _hninData.Add(hData);
                return string.IsNullOrEmpty(result) ? $"Unable to add HNIN data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add HNIN data - {e.Message}";
            }
        }

        public List<HNIN> Retrieve(int code)
        {
            var hnin = _hninData.Retrieve(code);
            return hnin;
        }

        public List<HNIN> Retrieve()
        {
            var allHNIN = _hninData.Retrieve();
            return allHNIN;
        }
    }
}
