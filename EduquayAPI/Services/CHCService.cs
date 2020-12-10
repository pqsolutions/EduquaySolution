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
    public class CHCService : ICHCService
    {

        private readonly ICHCData _chcData;

        public CHCService(ICHCDataFactory chcDataFactory)
        {
            _chcData = new CHCDataFactory().Create();
        }
        public async Task<AddEditResponse> Add(CHCRequest cData)
        {
            var response = new AddEditResponse();
            try
            {
                if (cData.isActive.ToLower() != "true")
                {
                    cData.isActive = "false";
                }
                if (cData.isTestingFacility.ToLower() != "true")
                {
                    cData.isTestingFacility = "false";
                }

                if (string.IsNullOrEmpty(cData.chcGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter chc gov code";
                }
                else if (cData.districtId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid district id";
                }
                else if (cData.blockId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid block id";
                }               
                else
                {
                    var addEditResponse = _chcData.Add(cData);
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
