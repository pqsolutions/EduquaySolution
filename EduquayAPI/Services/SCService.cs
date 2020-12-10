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
    public class SCService : ISCService
    {

        private readonly ISCData _scData;

        public SCService(ISCDataFactory scDataFactory)
        {
            _scData = new SCDataFactory().Create();
        }

        public async Task<AddEditResponse> Add(SCRequest sData)
        {
            var response = new AddEditResponse();
            try
            {
                if (sData.isActive.ToLower() != "true")
                {
                    sData.isActive = "false";
                }
                if (string.IsNullOrEmpty(sData.scGovCode))
                {
                    response.Status = "false";
                    response.Message = "Please enter sc gov code";
                }
                else if (sData.chcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid CHC id";
                }
                else if (sData.phcId <= 0)
                {
                    response.Status = "false";
                    response.Message = "Invalid PHC id";
                }
                else
                {
                    var addEditResponse =  _scData.Add(sData);
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
