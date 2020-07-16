using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.DataLayer;
using EduquayAPI.Models;

namespace EduquayAPI.Services
{
    public class CommunityService : ICommunityService
    {

        private readonly ICommunityData _communityData;

        public CommunityService(ICommunityDataFactory communityDataFactory)
        {
            _communityData = new CommunityDataFactory().Create();
        }

        public string Add(CommunityRequest cData)
        {
            try
            {
                if (cData.isActive.ToLower() != "true")
                {
                    cData.isActive = "false";
                }
                if (cData.casteId <= 0)
                {
                    return "Invalid caste id";
                }
                var result = _communityData.Add(cData);
                return string.IsNullOrEmpty(result) ? $"Unable to add community data" : result;
            }
            catch (Exception e)
            {
                return $"Unable to add community data - {e.Message}";
            }

        }

        public List<Community> Retrieve(int code)
        {
            var community = _communityData.Retrieve(code);
            return community;
        }

        public List<Community> Retrieve()
        {
            var community = _communityData.Retrieve();
            return community;
        }
    }
}
