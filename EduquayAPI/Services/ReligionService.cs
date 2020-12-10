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
    public class ReligionService : IReligionService
    {
        private readonly IReligionData _religionData;

        public ReligionService(IReligionDataFactory religionDataFactory)
        {
            _religionData = new ReligionDataFactory().Create();
        }

        public async Task<AddEditResponse> Add(ReligionRequest rData)
        {
            var response = new AddEditResponse();
            try
            {
                if (rData .isActive.ToLower() != "true")
                {
                    rData.isActive = "false";
                }
                if (string.IsNullOrEmpty(rData.religionName))
                {
                    response.Status = "false";
                    response.Message = "Please enter religion name";
                }
                else
                {
                    var addEditResponse = _religionData.Add(rData);
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
