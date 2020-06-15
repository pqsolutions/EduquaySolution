using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class ThresholdService : IThresholdService
    {

        private readonly IThresholdData _thresholdData;

        public ThresholdService(IThresholdDataFactory thresholdDataFactory)
        {
            _thresholdData = new ThresholdDataFactory().Create();
        }
        public string Add(ThresholdRequest tData)
        {
            try
            {
                if (tData.isActive.ToLower() != "true")
                {
                    tData.isActive = "false";
                }
                if (tData.testTypeID <= 0)
                {
                    return "Invalid Test Type Id";
                }

                var result = _thresholdData.Add(tData);
                return string.IsNullOrEmpty(result) ? $"Unable to add threshold data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add threshold data - {e.Message}";
            }
        }

        public List<Threshold> Retrieve(int code)
        {
            var threshold = _thresholdData.Retrieve(code);
            return threshold;
        }

        public List<Threshold> Retrieve()
        {
            var threshold = _thresholdData.Retrieve();
            return threshold;
        }
    }
}
