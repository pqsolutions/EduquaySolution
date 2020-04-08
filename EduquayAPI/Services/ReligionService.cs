using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class ReligionService : IReligionService
    {
        private readonly IReligionData _religionData;

        public ReligionService(IReligionDataFactory religionDataFactory)
        {
            _religionData = new ReligionDataFactory().Create();
        }

        public string Add(ReligionRequest rData)
        {
            try
            {
                if (rData .IsActive.ToLower() != "true")
                {
                    rData.IsActive = "false";
                }
                var result = _religionData.Add(rData);
                return string.IsNullOrEmpty(result) ? $"Unable to add religion data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add religion data - {e.Message}";
            }
        }

        public List<Religion> Retrieve(int code)
        {
            var religion = _religionData.Retrieve(code);
            return religion;
        }

        public List<Religion> Retrieve()
        {
            var religion = _religionData.Retrieve();
            return religion;
        }
    }
}
