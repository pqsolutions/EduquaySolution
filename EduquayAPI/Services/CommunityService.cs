using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EduquayAPI.Contracts.V1.Request;
using EduquayAPI.Contracts.V1.Response.Masters;
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

        public async Task<AddEditResponse> Add(CommunityRequest cData)
        {
            var response = new AddEditResponse();
            try
            {
                if (cData.isActive.ToLower() != "true")
                {
                    cData.isActive = "false";
                }
                if (string.IsNullOrEmpty(cData.communityName))
                {
                    response.Status = "false";
                    response.Message = "Please enter community name";
                }
                else if (cData.casteId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid caste id";
                }
                else
                {
                    var addEditResponse = _communityData.Add(cData);
                    response.Status = "true";
                    response.Message = addEditResponse.message;
                }
                return response;
            }
            catch (Exception e)
            {
                response.Status = "false";
                response.Message = $"Unable to process - {e.Message}";
                return response;
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
